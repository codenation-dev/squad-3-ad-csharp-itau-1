using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TryLog.Core.Model;
using TryLog.Services.Email;
using TryLog.Services.SettingObjects;
using TryLog.Services.ViewModel;

namespace TryLog.Services
{
    public class UserManagerService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptions<TokenSettings> _options;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly AuthenticatedUser _authenticatedUser;

        public UserManagerService(UserManager<User> userManager, SignInManager<User> signInManager,
            IOptions<TokenSettings> options, IMapper mapper, EmailService emailService, AuthenticatedUser authenticatedUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options;
            _mapper = mapper;
            _emailService = emailService;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<UserCreateOutView> Create(UserCreateView userCreateInView, string linkCallback)
        {
            User user = _mapper.Map<User>(userCreateInView);

            IdentityResult result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                return new UserCreateOutView(400, result.ToString());

            var code = await CreateTokenEmailConfirmation(user);

            string callBack = string.Format("{0}?email={1}&token={2}", linkCallback, user.Email, code);
            string bodyMessage = string.Format(Messages.AccountEmailActivation, user.FullName, callBack);

            _emailService.SendAsync(user.FullName, user.Email, "Account activation.", bodyMessage);

            return new UserCreateOutView(201, "Waiting for activation.");
        }

        public async Task<bool> Update(UserUpdateView userUpdate)
        {
            var email =  _authenticatedUser.GetEmail();
            var user = await _userManager.FindByEmailAsync(email);

            user.FullName = userUpdate.FullName;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<UserGetView> Get()
        {
            var mail =_authenticatedUser.GetEmail();
            User user = await _userManager.FindByEmailAsync(mail);
            return _mapper.Map<UserGetView>(user);
        }

        public async Task<bool> ConfirmTokenPasswordReset(string id, string token)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user is null) return false;
            string tokenDecoded = DecodeFromWeb(token);
            string newPassword = RandomPassword();
            var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, newPassword);
            if (result.Succeeded) {
                string body = string.Format(Messages.PasswordChangeConfirmation, user.UserName, user.CreatedAt.ToLocalTime(),newPassword);
                _emailService.SendAsync(user.FullName, user.Email, "Password change confirmation", body);
            }
            return result.Succeeded;
        }

        private string RandomPassword(int max=8)
        {
            List<int> maiusculas = new List<int>(26);
            List<int> minusculas = new List<int>(26);
            List<int> numeros = new List<int>(10);
            List<int> especiais = new List<int>(31);

            for (int i = 65; i <= 90; i++) maiusculas.Add(i);
            for (int i = 97; i <= 122; i++) minusculas.Add(i);
            for (int i = 48; i <= 57; i++) numeros.Add(i);

            especiais.Add(33);
            for (int i = 35; i <= 47; i++) especiais.Add(i);
            for (int i = 58; i <= 64; i++) especiais.Add(i);
            for (int i = 91; i <= 96; i++) especiais.Add(i);
            for (int i = 123; i <= 126; i++) especiais.Add(i);

            StringBuilder strB = new StringBuilder(max);
            for (int i = 0; i < max-1; i++)
            {
                strB.Append(Convert.ToChar(RandomDrop(ref maiusculas)));
                strB.Append(Convert.ToChar(RandomDrop(ref minusculas)));
                strB.Append(Convert.ToChar(RandomDrop(ref especiais)));
                strB.Append(Convert.ToChar(RandomDrop(ref numeros)));
            }
            return strB.ToString();
        }

        private int RandomDrop(ref List<int> list)
        {
            var letra = list[new Random().Next(list.Count)];
            list.Remove(letra);
            return letra;
        }

        public async Task<bool> Activate(string email, string code)
        {
            User user = await _userManager.FindByEmailAsync(email);
            
            if (user is null) return false;
            if (await _userManager.IsEmailConfirmedAsync(user)) return true;
            string token = DecodeFromWeb(code);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded;
        }

        public async Task<bool> ResetPassword(string email, string linkCallback)
        {
            User user = await _userManager.FindByEmailAsync(email);

            if (user is null) return false;
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string tokenEncoded = EncodeForWeb(token);
            string link = string.Format("{0}?id={1}&token={2}", linkCallback, user.Id, tokenEncoded);
            string body = string.Format(Messages.PasswordResetConfirmation, link, user.UserName, user.CreatedAt.ToLocalTime());

            _emailService.SendAsync(user.FullName, email, "Password Reset Confirmation", body);

            return true;
        }

        public async Task<UserLoginOutViewModel> Login(UserLoginViewModel userLoginInView)
        {
            if (_authenticatedUser.IsAuthenticated())
                return new UserLoginOutViewModel("Sucess", "User already authenticated.");

            User user = await _userManager.FindByEmailAsync(userLoginInView.Email);            

            if (user?.Deleted is true) 
                return new UserLoginOutViewModel("Failed", "Inactive status account.");
            
            var signInResult =
                await _signInManager.PasswordSignInAsync(userLoginInView.Email,
                                                            userLoginInView.Password,
                                                            false, true);
            if (!signInResult.Succeeded || user is null)
                return new UserLoginOutViewModel("Failed", "Wrong email or password.");

            return CreateToken(user);
        }

        public async Task<string> Delete(UserDeleteViewModel userDelete)
        {
            var email = _authenticatedUser.GetEmail();
            User user = await _userManager.FindByEmailAsync(email);

            var confirmPass = await _userManager.CheckPasswordAsync(user, userDelete.Password);
            if (!confirmPass) return null;
            
            user.Deleted = true;
            user.EmailConfirmed = false;

            var result= await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();

            return result.ToString();
        }

        private UserLoginOutViewModel CreateToken(User userLogin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_options.Value.SecretKey);

            var expiration = DateTime.UtcNow.AddHours(_options.Value.Hours);

            var signinKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userLogin.UserName.ToString()),
                    new Claim(ClaimTypes.Role, "user_default"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, userLogin.FullName)
                }),
                Expires = expiration,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserLoginOutViewModel(
                result: tokenHandler.WriteToken(token),
                message: "Token will expire on: " + expiration.ToLocalTime()
            );
        }

        private async Task<string> CreateTokenEmailConfirmation(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return EncodeForWeb(token);
        }

        private string EncodeForWeb(string code)
        {
            var encoded = Encoding.UTF8.GetBytes(code);
            return WebEncoders.Base64UrlEncode(encoded);
        }

        private static string DecodeFromWeb(string code)
        {
            byte[] decode = WebEncoders.Base64UrlDecode(code);
            return Encoding.UTF8.GetString(decode);
        }
    }

}




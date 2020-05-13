using AutoMapper;
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

        /// <summary>
        /// Gera uma nova conta de usuário.
        /// E envia email de confirmação.
        /// </summary>
        /// <param name="userCreate"></param>
        /// <param name="callback"></param>
        /// <returns>O resultado do comando.</returns>
        public async Task<UserCreateOutView> Create(UserCreateView userCreate, string callback)
        {
            User user = _mapper.Map<User>(userCreate);

            IdentityResult result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                return new UserCreateOutView(400, result.ToString());

            StayEmptyPasswordField(user);
            var token= await CreateTokenEmailConfirmation(user);
            string bodyMessage = CreateBodyEmail(callback, user, token);

            _emailService.Send(user.FullName, user.Email, "Account activation.", bodyMessage);

            return new UserCreateOutView(201, "Waiting for activation.");
        }

        /// <summary>
        /// Cria o corpo de uma mensagem de email com link de confirmação.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private string CreateBodyEmail(string callback, User user, string token)
        {
            string linkCallBack = string.Format("{0}?email={1}&token={2}", callback, user.Email, token);
            string bodyMessage = string.Format(Messages.AccountEmailActivation, user.FullName, linkCallBack);
            return bodyMessage;
        }

        /// <summary>
        /// Envia token de confirmação para reset de senha.
        /// </summary>
        /// <param name="userReactive"></param>
        /// <param name="callback"></param>
        public async void ReActivate(UserReactivateAccountView userReactive, string callback)
        {
            if (_authenticatedUser.IsAuthenticated()) return;
            User user = await _userManager.FindByEmailAsync(userReactive.Email);
            bool checkPass =
                await _userManager.CheckPasswordAsync(user, userReactive.Password);
            if (checkPass){
                var code = await CreateTokenEmailConfirmation(user);
                string linkCallBack = string.Format("{0}?email={1}&token={2}", callback, user.Email, code);
                string bodyMessage = string.Format(Messages.AccountReActivation, user.FullName, linkCallBack);

                _emailService.Send(user.FullName, user.Email, "Account Re-activation.", bodyMessage);
            }

        }

        /// <summary>
        /// Atribui novos valores para as propriedades do usuário.
        /// </summary>
        /// <param name="userUpdate"></param>
        /// <returns>Valor booleano que representa o resultado do comando.</returns>
        public async Task<bool> Update(UserUpdateView userUpdate)
        {
            var email =  _authenticatedUser.GetEmail();
            var user = await _userManager.FindByEmailAsync(email);

            user.FullName = userUpdate.FullName;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        /// <summary>
        /// Atribui uma cadeia de caracter vazia para a propriedade User.Password.
        /// </summary>
        /// <param name="user"></param>
        private async void StayEmptyPasswordField(User user)
        {
            user.Password = "";
            await _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// Retorna os dados do usuário logado.
        /// </summary>
        /// <returns></returns>
        public async Task<UserGetView> Get()
        {
            var mail =_authenticatedUser.GetEmail();
            User user = await _userManager.FindByEmailAsync(mail);
            return _mapper.Map<UserGetView>(user);
        }

        /// <summary>
        /// Confirma token de reset de senha. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>        
        /// <returns>Valor booleano que representa o resultado do comando.</returns>
        public async Task<bool> ConfirmTokenPasswordReset(string id, string token)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user is null) return false;
            string tokenDecoded = DecodeFromWeb(token);
            string newPassword = RandomPassword();
            var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, newPassword);
            if (result.Succeeded) {
                string body = string.Format(Messages.PasswordChangeConfirmation, user.UserName, user.CreatedAt.ToLocalTime(),newPassword);
                _emailService.Send(user.FullName, user.Email, "Password change confirmation", body);
                StayEmptyPasswordField(user);
            }
            return result.Succeeded;
        }

        /// <summary>
        /// Cria um senha pseudoaleatória.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>Retorna um cadeia de caracteres contendo numéricos, letras e especiais.</returns>
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
            especiais.Add(91);
            for (int i = 93; i <= 96; i++) especiais.Add(i);
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

        /// <summary>
        /// Remove um item da lista e retorna.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Retorna um inteiro aleatório da lista.</returns>
        private int RandomDrop(ref List<int> list)
        {
            var letra = list[new Random().Next(list.Count)];
            list.Remove(letra);
            return letra;
        }

        /// <summary>
        /// Confirma a conta de usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns>Valor booleano que representa o resultado do comando.</returns>
        public async Task<bool> Activate(string email, string code)
        {
            User user = await _userManager.FindByEmailAsync(email);
            
            if (user is null) return false;
            if (await _userManager.IsEmailConfirmedAsync(user)) return true;
            string token = DecodeFromWeb(code);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                user.Deleted = false;
                _ = await _userManager.UpdateAsync(user);
            }

            return result.Succeeded;
        }

        /// <summary>
        /// Envia um token de confirmação do reset de senha do usuário.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="linkCallback"></param>
        /// <returns>Valor booleano que representa o resultado do comando.</returns>
        /// 
        public async Task<bool> ResetPassword(string email, string callback)
        {
            User user = await _userManager.FindByEmailAsync(email);

            if (user is null) return false;
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string tokenEncoded = EncodeForWeb(token);
            string linkCallback = string.Format("{0}?id={1}&token={2}", callback, user.Id, tokenEncoded);
            string body = string.Format(Messages.PasswordResetConfirmation, linkCallback, user.UserName, user.CreatedAt.ToLocalTime());
            
            _emailService.Send(user.FullName, email, "Password Reset Confirmation", body);

            return true;
        }

        /// <summary>
        /// Permite o Login com email e senha do usuário.
        /// </summary>
        /// <param name="userLoginInView"></param>
        /// <returns>Um token de autenticação válido.</returns>
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

        /// <summary>
        /// Atribui o valor booleano true à propriedade User.Delete.
        /// Tem como efeito a alteração da propriedade User.UpdateAt.
        /// </summary>
        /// <param name="userDelete"></param>
        /// <returns>Retorna um texto contendo o resultado do comando.</returns>
        public async Task<string> Delete(UserDeleteViewModel userDelete)
        {
            var email = _authenticatedUser.GetEmail();
            User user = await _userManager.FindByEmailAsync(email);

            var confirmPass = await _userManager.CheckPasswordAsync(user, userDelete.Password);
            if (!confirmPass) return null;
            
            user.Deleted = true;
            user.EmailConfirmed = false;
            user.UpdatedAt = DateTime.UtcNow;

            var result= await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();

            return result.ToString();
        }

        /// <summary>
        /// Gera um token de autenticação de usuário.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>
        /// Retorna a cadeia de caracteres do token e a data/hora de sua expiração.
        /// </returns>
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

        /// <summary>
        /// Gera um token de confirmação de email/conta do usuário.
        /// O token gerado é codificado para envio web.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna a cadeia de caracteres que compõem o token.</returns>
        private async Task<string> CreateTokenEmailConfirmation(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return EncodeForWeb(token);
        }

        /// <summary>
        /// Codifica uma string para tráfego web.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Retorna a string codifcada.</returns>
        private string EncodeForWeb(string code)
        {
            var encoded = Encoding.UTF8.GetBytes(code);
            return WebEncoders.Base64UrlEncode(encoded);
        }

        /// <summary>
        /// Decodifica uma string da web.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Retorna a string decodifcada.</returns>
        private static string DecodeFromWeb(string code)
        {
            byte[] decode = WebEncoders.Base64UrlDecode(code);
            return Encoding.UTF8.GetString(decode);
        }
    }

}




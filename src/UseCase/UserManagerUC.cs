using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using TryLog.Core.Model.DTO;
using TryLog.Core.Model;
using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TryLog.UseCase
{
    public class UserManagerUC
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IConfiguration _configuration { get; set; }

        public UserManagerUC(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager= signInManager;
            _configuration = _configuration;
        }
        public async Task<UserLoginDTO> Create(User user)
        {

            User newUser = new User(user.FullName, user.Nickname,
                                    user.Email,user.Password,
                                    DateTime.Now,DateTime.Now);

            IdentityResult result = await _userManager.CreateAsync(newUser, newUser.Password);
            

            if (result.Succeeded)
            {
                var token = CreateToken(user);
                var userLogin = new UserLoginDTO(email: newUser.Email,
                                                password: newUser.Password,
                                                token: token);
                return userLogin;
            }
            return null;
        }
        private string CreateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetSection("SecretKey").ToString());
            
            double expireTime = double.Parse(_configuration.GetSection("TokenConfigurations:Hours").ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "default_user")
                }),
                Expires = DateTime.UtcNow.AddHours(expireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
        };
            var token= tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}


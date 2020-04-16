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
        private readonly IConfiguration _configuration;

        public UserManagerUC(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager= signInManager;
            _configuration = configuration;
        }
        public async Task<dynamic> Create(User user)
        {

            IdentityResult result = await _userManager.CreateAsync(user, user.Password);
            

            if (result.Succeeded)
            {
                var token = CreateToken(user);
                var userLogin = new UserLoginDTO(email: user.Email,
                                                password: string.Empty,
                                                token: token);
                return userLogin;
            }
            return result;
        }
        private string CreateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);


            double expireTime = double.Parse(_configuration["TokenConfigurations:Hours"]);

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


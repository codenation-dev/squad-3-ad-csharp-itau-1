using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;

namespace TryLog.Services
{
    public class UserManagerService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserManagerService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;

            _signInManager = signInManager;
            _configuration = configuration;
        }
        public TokenViewModel Create(User user)
        {
            IdentityResult result = _userManager.CreateAsync(user, user.Password).Result;

            if (result.Succeeded)
                return CreateToken(new UserAuthViewModel(user.Email,null, null));
            return new TokenViewModel(result.ToString());
        }

        public TokenViewModel Login(UserAuthViewModel userAuth)
        {
            var result = _signInManager.PasswordSignInAsync(userAuth.UserName,
                                                            userAuth.Password,
                                                            false, false).Result;
            if (result.Succeeded)
            {
                userAuth.FullName = userAuth.Password = null;
                return CreateToken(userAuth);
            }
                

            return new TokenViewModel(result.ToString());
        }

        private TokenViewModel CreateToken(UserAuthViewModel userAuth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["SecretKey"]);
            var expiration = DateTime.UtcNow.AddHours(double.Parse(_configuration["TokenConfigurations:Hours"]));
            var signinKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userAuth.UserName),
                    new Claim(ClaimTypes.Role, "user_default")
                }),
                Expires = expiration,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenViewModel(
                token: tokenHandler.WriteToken(token),
                expiration: expiration
            );
        }
    }

}


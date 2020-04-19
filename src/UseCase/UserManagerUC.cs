using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TryLog.Core.Model;
using TryLog.Core.Model.DTO;

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

            _signInManager = signInManager;
            _configuration = configuration;
        }
        public TokenDTO Create(User user)
        {
            IdentityResult result = _userManager.CreateAsync(user, user.Password).Result;

            if (result.Succeeded)
                return CreateToken(new UserAuthDTO(user.Email,null, null));
            return new TokenDTO(result.ToString());
        }

        public TokenDTO Login(UserAuthDTO userAuth)
        {
            var result = _signInManager.PasswordSignInAsync(userAuth.UserName,
                                                            userAuth.Password,
                                                            false, false).Result;
            if (result.Succeeded)
            {
                userAuth.FullName = userAuth.Password = null;
                return CreateToken(userAuth);
            }
                

            return new TokenDTO(result.ToString());
        }

        private TokenDTO CreateToken(UserAuthDTO userAuth)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
            var expiration = DateTime.UtcNow.AddHours(double.Parse(_configuration["TokenConfigurations:Hours"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userAuth.UserName),
                    new Claim(ClaimTypes.Role, "user_default")
                }),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDTO(
                token: tokenHandler.WriteToken(token),
                expiration: expiration
            );
        }
    }

}


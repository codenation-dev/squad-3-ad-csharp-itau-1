using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;

namespace TryLog.WebApi.Controllers.V1
{

    public class VersionController : Controller
    {
        private readonly IUserRepository _userRepository;

        public VersionController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public string Get()
        {
            var user = new User(
                "Pedro","pe","pedro@gmail.com","123456", DateTime.Now, DateTime.Now
                );

            _userRepository.Add(user);
            var userSearch = _userRepository.Find(u=>u.FullName.Equals("Pedro"));
            //Aquela nossa dúvida se fucnionaria
            var teste = _userRepository.Get(1);
            return userSearch[0].Email;
        }
    }
}

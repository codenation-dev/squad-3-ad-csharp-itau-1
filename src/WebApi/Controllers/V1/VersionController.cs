using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;

namespace TryLog.WebApi.Controllers.V1
{

    public class VersionController : Controller
    {
        private readonly UserRepository _userRepository;

        public VersionController(UserRepository userRepository)
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
            _userRepository.Create(user);
            var userSearch = _userRepository.Find(u=>u.FullName.Equals("Pedro"));
            
            return userSearch[0].Email;
        }
    }
}

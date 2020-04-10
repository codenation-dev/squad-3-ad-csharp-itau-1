using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;
using TryLog.UseCase;

namespace TryLog.WebApi.Controllers.V1
{

    public class VersionController : Controller
    {
        private readonly UserManagerUC _userUC;

        public VersionController(UserManagerUC userUC)
        {
            _userUC = userUC;
        }

        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public string Get()
        {
            _userUC.CreateNew(new User("Pedro", "pe", "pedro@gmail.com", "Pedro12!", DateTime.Now, DateTime.Now));

            return "Tudo Certo!";
            //var user = new User(
            //    "Pedro","pe","pedro@gmail.com","123456", DateTime.Now, DateTime.Now
            //    );

            //_userUC.Add(user);
            //var userSearch = _userUC.Find(u=>u.FullName.Equals("Pedro"));
            ////Aquela nossa dúvida se fucnionaria
            //var teste = _userUC.Get(1);
            //return userSearch.Email;
        }
    }
}

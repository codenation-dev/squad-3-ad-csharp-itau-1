using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace TryLog.Services
{
    public class AuthenticatedUser
    {
		private readonly IHttpContextAccessor _accessor;

		public AuthenticatedUser(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public string GetEmail()
		{
			return GetClaimsIdentity().FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
		}

		public string GetName()
		{
			return GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
		}

		public bool IsAuthenticated()
		{
			return _accessor.HttpContext.User.Identity.IsAuthenticated;
		}
		private IEnumerable<Claim> GetClaimsIdentity()
		{
			return _accessor.HttpContext.User.Claims;
		}
	}

}

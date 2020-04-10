using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;

namespace TryLog.UseCase
{
    public class UserManagerUC
    {
        private readonly TryLogContext _context;
        public UserRepository repository;
        public UserManagerUC(TryLogContext context)
        {
            _context = context;
            repository = new UserRepository(_context);
        }

        
        public void CreateNew(User user)
        {
            ExistsOnDb(x => x.Nickname.ToLower() == user.Nickname.ToLower(), nameof(User.Nickname));
            ExistsOnDb(x => x.Email.ToLower() == user.Email.ToLower(), nameof(User.Email));
            VerifyPassword(user.Password);
            repository.Add(user);
        }


        private void ExistsOnDb(Expression<Func<User,bool>> expression, string propertyName)
        {
            var checkProperty = repository.Find(expression);
            if (checkProperty != null)
            {
                throw new Exception($"{propertyName} already exists");
            }
        }
        public void VerifyPassword(string password)
        {
            int minLength = 8;
            int numUpper = 1;
            int numLower = 1;
            int numNumbers = 1;
            int numSpecial = 1;
            var upper = new Regex("[A-Z]");
            var lower = new Regex("[a-z]");
            var number = new Regex("[0-9]");
            var special = new Regex("[^a-zA-Z0-9]");

            if (password.Length < minLength)
            {
                throw new Exception($"Minimum of {minLength} characters");
            }
            if (upper.Match(password).Length < numUpper)
            {
                throw new Exception($"Minimum of {numUpper} capital letter(s)");
            }
            if (lower.Match(password).Length < numLower)
            {
                throw new Exception($"Minimum of {numLower} lowercase letter(s)");
            }
            if (number.Match(password).Length < numNumbers)
            {
                throw new Exception($"Minimum of {numNumbers} number(s)");
            }
            if (special.Match(password).Length < numSpecial)
            {
                throw new Exception($"Minimum of {numSpecial} special character(s)");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;

namespace TryLog.UseCase
{
    public class UserManager
    {
        private readonly TryLogContext _context;
        public UserRepository repository;
        public UserManager(TryLogContext context)
        {
            _context = context;
            repository = new UserRepository(_context);
        }

        
        public void CreateNew(User user)
        {
            repository.Add(user);
        }
    }
}

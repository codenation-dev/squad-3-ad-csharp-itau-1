using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(TryLogContext context) : base(context)
        {
        }        
    }
}

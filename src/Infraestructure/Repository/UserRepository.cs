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
        private readonly TryLogContext _context;

        public UserRepository(TryLogContext context) : base(context){
        
        }
        public void Create(User user)
        {
            Add(user);
        }
        public User Read(long userId)
        {
            return Get(userId);
        }
        public List<User> Filter(Expression<Func<User, bool>> predicate)
        {
            return Find(predicate);
        }
        public void Remove(Expression<Func<User, bool>> predicate)
        {
            Delete(predicate);
        }
        public void Update(User user)
        {
            SaveOrUpdate(user);
        }
    }
}

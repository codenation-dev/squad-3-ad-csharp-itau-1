using System;
using System.Collections.Generic;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Repositories
{
    class UserRepository
    {
        private List<User> _Users;
        private int index;
        public UserRepository()
        {
            _Users = new List<User>();
        }
        public long Add(User user)
        {
            index = _Users.FindIndex(u => u.Id.Equals(user.Id));
            if (index.Equals(-1))
            {
                _Users.Add(user);
                return user.Id;
            }
            else throw new Exception("Id must be unique.");
        }

        public void Update(User user)
        {
            index = _Users.FindIndex(u => u.Id.Equals(user.Id));
            if (!index.Equals(-1))
            {
                _Users[index].FullName = user.FullName;
                _Users[index].Nickname = user.Nickname;
                _Users[index].Email = user.Email;
                _Users[index].Password = user.Password;
                _Users[index].UpdatedAt = DateTime.Now;
            }
            else throw new Exception("User not found.");
        }

        public void Remove(int id)
        {
            index = _Users.FindIndex(u => u.Id.Equals(id));
            if (!index.Equals(-1))
                _Users.RemoveAt(index);
            else
                throw new Exception("User not found.");
        }

        public User GetUser(int id)
        {
            var user = _Users.Find(u => u.Id.Equals(id));
            if (!user.Equals(null))
            {
                return user;
            }
            else
                throw new Exception("User not found.");
        }
    }
}


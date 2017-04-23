﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MemoryUserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>
        {
            new User("login1", "qwer123", "43248932", "1@example.com"),
            new User("login2", "qwer123", "43248932", "2@example.com"),
            new User("login3", "qwer123", "43248932", "3@example.com")
        };


        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(o => o.ID == id));

        public async Task<User> GetAsync(string login)
            => await Task.FromResult(_users.SingleOrDefault(o => o.Login == login));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            User user = await GetAsync(id);
            _users.Remove(user);
        }

        public async Task UpdateAsync(User user)
        {
            //throw new NotImplementedException();
            await Task.CompletedTask;
        }
    }
}
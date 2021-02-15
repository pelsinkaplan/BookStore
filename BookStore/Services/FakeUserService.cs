using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class FakeUserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User{Email = "pelsinkaplan@gmail.com",Name="Pelşin", Password = "123456"},
            new User{Email = "cankaplan@gmail.com", Name = "Can",Password = "456789"},
        };
        public User ValidUser(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Token_2.API.Data;
using Token_2.Models;

namespace Token_2.UserRepository
{
    
        public class UserRepo : IDisposable
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            public User ValidateUser(string username, string password)
            {
                return dbContext.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
            }

            public void Dispose()
            {
                dbContext.Dispose();
            }
        }
}
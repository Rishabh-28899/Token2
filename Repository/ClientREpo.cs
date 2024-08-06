using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Token_2.API.Data;
using Token_2.Models;

namespace Token_2.Repository
{
    public class ClientREpo : IDisposable
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        public Clientdetail ValidateClient(string Clientid,  string Clientsecret)
        {
            return dbContext.ClientDetails.FirstOrDefault(user => user.ClientId == Clientid && user.ClientSecret == Clientsecret);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Linq;
using System.Security.Authentication;
using WcfSimpleTokenExample.Database;
using WcfSimpleTokenExample.Interfaces;

namespace WcfSimpleTokenExample.Business
{
    public class DatabaseTokenBuilder : ITokenBuilder
    {
        private readonly BasicTokenDbContext _DbContext;

        public DatabaseTokenBuilder(BasicTokenDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public string Build(Model.Credentials creds)
        {
            if (!new DatabaseCredentialsValidator(_DbContext).IsValid(creds))
            {
                throw new AuthenticationException();
            }
            var token = Guid.NewGuid().ToString();
            var user = _DbContext.Users.SingleOrDefault(u => u.Username.Equals(creds.User, StringComparison.CurrentCultureIgnoreCase));
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _DbContext.Tokens.Add(new Token { Text = token, User = user, CreateDate = DateTime.Now });
            _DbContext.SaveChanges();
            return token;
        }
    }
}
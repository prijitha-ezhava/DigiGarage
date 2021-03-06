using Digigarage.BusinessEntities;
using Digigarage.Data.Models;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DigiGarageEntities _dbContext;
        public LoginRepository()
        {
            _dbContext = new DigiGarageEntities();
        }

        public string getRole(LoginViewModel objuser)
        {
            var obj = _dbContext.Logins.Where(a => a.emailid.Equals(objuser.emailid)).FirstOrDefault();
            string role = _dbContext.Roles.Find(obj.Id).UserRole;
            return role;
        }

        public string validAdmin(LoginViewModel objUser)
        {
            var obj = _dbContext.Logins.Where(a => a.emailid.Equals(objUser.emailid) && a.password.Equals(objUser.password)).FirstOrDefault();
            if (obj != null) 
            {
                return obj.emailid.ToString();
            }
            return null;
        }
    }
}

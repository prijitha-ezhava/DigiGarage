using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using Digigarage.Data.Repository;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Business
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginRepository _AdminLoginRepository;

        public LoginManager(ILoginRepository AdminLoginRepository)
        {
            _AdminLoginRepository = AdminLoginRepository;
        }

        public string getRole(LoginViewModel objUser)
        {
            return _AdminLoginRepository.getRole(objUser);
        }

        public string validAdmin(LoginViewModel objUser)
        {
            return _AdminLoginRepository.validAdmin(objUser);
        }
    }
}

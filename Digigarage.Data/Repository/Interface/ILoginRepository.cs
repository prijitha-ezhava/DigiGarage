using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository.Interface
{
    public interface ILoginRepository
    {
        string validAdmin(LoginViewModel objUser);
        string getRole(LoginViewModel objuser);
    }
}

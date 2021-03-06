using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository.Interface
{
    public interface IServiceRepository
    {
        ServiceViewModel GetService(int? Id);
        IEnumerable<ServiceViewModel> GetAllService();
        string CreateService(ServiceViewModel model);
        string UpdateService(ServiceViewModel model);
        string DeleteService(int? Id);
        IEnumerable<StatusOfBookingViewModel> GetAllServiceStatus();
    }
}

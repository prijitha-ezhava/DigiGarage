using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Data.Repository.Interface
{
    public interface IMechanicRepository
    {
        MechanicViewModel GetMechanic(int Id);
        IEnumerable<MechanicViewModel> GetAllMechanic();
        IEnumerable<MechanicViewModel> GetMechanicOfWashing();
        IEnumerable<MechanicViewModel> GetMechanicOfRepairing();
        IEnumerable<MechanicViewModel> GetMechanicOfMaintainance();
        string CreateMechanic(MechanicViewModel model);
        string UpdateMechanic(MechanicViewModel model);
        string DeleteMechanic(int Id);
    }
}

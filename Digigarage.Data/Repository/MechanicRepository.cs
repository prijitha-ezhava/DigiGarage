using Digigarage.BusinessEntities;
using Digigarage.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using Digigarage.Data.Models;
using AutoMapper;
using System.Data.Entity;
using System.Linq;

namespace Digigarage.Data.Repository
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly DigiGarageEntities _dbContext;

        public MechanicRepository()
        {
            _dbContext = new DigiGarageEntities();
        }
        public string CreateMechanic(MechanicViewModel model)
        {
            if (model != null)
            {
                Mechanic entity = Mapper.Map<MechanicViewModel, Mechanic>(model);
                _dbContext.Mechanics.Add(entity);
                _dbContext.SaveChanges();
                return "Mechanic added";
            }

            return "Model is null";
        }

        public string DeleteMechanic(int Id)
        {
            Mechanic entity = _dbContext.Mechanics.Find(Id);
            _dbContext.Mechanics.Remove(entity);
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public IEnumerable<MechanicViewModel> GetAllMechanic()
        {
            IEnumerable<MechanicViewModel> mechanicsEntities =
                Mapper.Map<IEnumerable<MechanicViewModel>>(_dbContext.Mechanics);
            return mechanicsEntities;
        }

        public MechanicViewModel GetMechanic(int Id)
        {
            MechanicViewModel mechanicsEntities = Mapper.Map<MechanicViewModel>(_dbContext.Mechanics.Find(Id));
            return mechanicsEntities;
        }

        public IEnumerable<MechanicViewModel> GetMechanicOfMaintainance()
        {
            IEnumerable<MechanicViewModel> mechanicsEntities =
                Mapper.Map<IEnumerable<MechanicViewModel>>(_dbContext.Mechanics.Where(a => a.DeptId == 3));
            return mechanicsEntities;
        }

        public IEnumerable<MechanicViewModel> GetMechanicOfRepairing()
        {
            IEnumerable<MechanicViewModel> mechanicsEntities =
                Mapper.Map<IEnumerable<MechanicViewModel>>(_dbContext.Mechanics.Where(a => a.DeptId == 2));
            return mechanicsEntities;
        }

        public IEnumerable<MechanicViewModel> GetMechanicOfWashing()
        {
            IEnumerable<MechanicViewModel> mechanicsEntities =
                Mapper.Map<IEnumerable<MechanicViewModel>>(_dbContext.Mechanics.Where(a => a.DeptId == 1));
            return mechanicsEntities;
        }

        public string UpdateMechanic(MechanicViewModel model)
        {
            if (model != null)
            {
                Mechanic entity = _dbContext.Mechanics.Find(model.MechanicId);
                Mapper.Map(model, entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "Mechanic updated";
            }

            return "Model is null";
        }
    }
}

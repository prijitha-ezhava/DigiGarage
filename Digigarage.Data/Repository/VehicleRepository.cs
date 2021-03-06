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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DigiGarageEntities _dbContext;

        public VehicleRepository()
        {
            _dbContext = new DigiGarageEntities();
        }
        public string CreateVehicle(VehicleViewModel model)
        {
            if (model != null)
            {
                int vehicle = _dbContext.Vehicles.Where(a => a.LicencePlate == model.LicencePlate).Count();
                if (vehicle != 0)
                {
                    return "Exist";
                }
                else {
                    Vehicle entity = Mapper.Map<VehicleViewModel, Vehicle>(model);
                    _dbContext.Vehicles.Add(entity);
                    _dbContext.SaveChanges();
                    return "Vehicle added";
                }
            }

            return "Model is null";
        }

        public string DeleteVehicle(int? Id)
        {
            Vehicle entity = _dbContext.Vehicles.Find(Id);
            _dbContext.Vehicles.Remove(entity);
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public IEnumerable<VehicleViewModel> GetAllVehicle()
        {
            IEnumerable<VehicleViewModel> DigigarageEntities =
                Mapper.Map<IEnumerable<VehicleViewModel>>(_dbContext.Vehicles);
            return DigigarageEntities;
        }

        public IEnumerable<VehicleViewModel> GetAllVehicleByCustomer(int id)
        {
            IEnumerable<Vehicle> vehicle = _dbContext.Vehicles.Where(a => a.CustomerId == id);
            IEnumerable<VehicleViewModel> DigigarageEntities =
                Mapper.Map<IEnumerable<VehicleViewModel>>(vehicle);
            return DigigarageEntities;
        }

        public VehicleViewModel GetVehicle(int? Id)
        {
            VehicleViewModel DigigarageEntities = Mapper.Map<VehicleViewModel>(_dbContext.Vehicles.Find(Id));
            return DigigarageEntities;
        }

       
        public string UpdateVehicle(VehicleViewModel model)
        {
            if (model != null)
            {
                Vehicle entity = _dbContext.Vehicles.Find(model.VehicleId);
                Mapper.Map(model, entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "Vehicle updated";
            }

            return "Model is null";
        }
    }
}

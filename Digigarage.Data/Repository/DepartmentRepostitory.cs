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
    public class DepartmentRepostitory : IDepartmentRepostitory
    {
        private readonly DigiGarageEntities _dbContext;

        public DepartmentRepostitory()
        {
            _dbContext = new DigiGarageEntities();
        }

        public IEnumerable<DepartmentViewModel> GetAllDepartment()
        {
            IEnumerable<Department> Department = _dbContext.Departments;
            IEnumerable<DepartmentViewModel> DepartmentsEntities =
                Mapper.Map<IEnumerable<DepartmentViewModel>>(Department);
            return DepartmentsEntities;
        }
    }
}

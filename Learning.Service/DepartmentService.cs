using Learning.Core.Entities;
using Learning.Repositories.Repositories.IRepositories;
using Learning.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    public class DepartmentService : IDepartmentsService
    {
        private readonly IDepartmentsRepositories _repo;

        public DepartmentService(IDepartmentsRepositories repo) { 
            _repo = repo;
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            return _repo.GetAllDepartments();
        }
    }
}

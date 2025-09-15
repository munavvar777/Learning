using Learning.Core.Entities;
using Learning.Data;
using Learning.Repositories.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Repositories.Repositories
{
    public class DepartmentsRepositories : IDepartmentsRepositories
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}

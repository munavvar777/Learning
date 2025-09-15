using Learning.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Repositories.Repositories.IRepositories
{
    public interface IDepartmentsRepositories
    {
        Task<IEnumerable<Department>> GetAllDepartments();

    }
}

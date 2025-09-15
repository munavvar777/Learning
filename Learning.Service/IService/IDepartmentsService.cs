using Learning.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.IService
{
    public interface IDepartmentsService
    {
        Task<IEnumerable<Department>> GetAllDepartments();

    }
}

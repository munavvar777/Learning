using Learning.Core.Entities;
using Learning.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Repositories.Repositories.IRepositories
{
    public interface IStudentRepositories
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);

    }
}

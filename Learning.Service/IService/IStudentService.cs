using Learning.Core.Entities;
using Learning.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service.IService
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetByIdAsync(int id);
        Task AddStudent(StudentsViewModel student);
        Task UpdateStudent(StudentsViewModel student);
        Task DeleteAsync(int id);

    }
}

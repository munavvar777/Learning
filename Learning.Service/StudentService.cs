using Learning.Core.Entities;
using Learning.Core.ViewModels;
using Learning.Repositories.Repositories;
using Learning.Repositories.Repositories.IRepositories;
using Learning.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepositories _repo;

        public StudentService(IStudentRepositories repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _repo.GetAllStudents();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public async Task AddStudent(StudentsViewModel student)
        {
            var entity = new Student
            {
                RollNumber = student.RollNumber,
                FullName = student.FullName,
                DateOfBirth = DateTime.SpecifyKind(student.DateOfBirth, DateTimeKind.Utc),
                Email = student.Email,
                Phone = student.Phone,
                DepartmentId = student.DepartmentId
            };

            await _repo.AddAsync(entity);

                student.Id = entity.Id;
        }

        public async Task UpdateStudent(StudentsViewModel student)
        {
            var entity = await _repo.GetByIdAsync(student.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            // Map fields from ViewModel → Entity
            entity.RollNumber = student.RollNumber;
            entity.FullName = student.FullName;
            entity.DateOfBirth = DateTime.SpecifyKind(student.DateOfBirth, DateTimeKind.Utc);
            entity.Email = student.Email;
            entity.Phone = student.Phone;
            entity.DepartmentId = student.DepartmentId;

            await _repo.UpdateAsync(entity);

            // Sync back Id
            student.Id = entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            await _repo.DeleteAsync(id);
        }

    }
}

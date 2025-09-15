using Learning.Core.Entities;
using Learning.Data;
using Learning.Repositories.Repositories.IRepositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace Learning.Repositories.Repositories
{
    public class StudentRepositories : IStudentRepositories
    {
        private readonly ApplicationDbContext  _context;

        public StudentRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.Include(s=>s.Department).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with Id {id} was not found.");
            }
            return student;
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)        
            {   
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with Id {id} was not found.");
            }
        }

    }
}

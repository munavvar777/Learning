

using Learning.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data
{
        public class ApplicationUser : IdentityUser
        {
            public string FullName { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<Student> Students { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }
            public DbSet<Exam> Exams { get; set; }
            public DbSet<Result> Results { get; set; }
            public DbSet<TeacherCourse> TeacherCourses { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);
            // 🔹 Configure the TeacherCourse entity
            // This is a "join table" for the many-to-many relationship
            // between Teacher and Course.
            //
            // We define a COMPOSITE KEY using TeacherId + CourseId
            // so EF Core knows that this pair must be unique.
            // Example: Teacher(1) teaching Course(101) cannot be duplicated.
            //
            // Without this configuration, EF would try to create a new
            // surrogate primary key column (like TeacherCourseId),
            // which is unnecessary for a pure join table.

            builder.Entity<TeacherCourse>()
                    .HasKey(tc => new { tc.TeacherId, tc.CourseId });
            }
    }
    }

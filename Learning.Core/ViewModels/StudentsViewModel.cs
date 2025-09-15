using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Core.ViewModels
{
    public class StudentsViewModel
    {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Roll Number")]
            public string RollNumber { get; set; }

            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Phone]
            public string Phone { get; set; }

            [Required]
            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            public string? DepartmentName { get; set; }
        }

}

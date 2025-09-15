using Learning.Core.Entities;
using Learning.Core.ViewModels;
using Learning.Service;
using Learning.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Learning.Web.Controllers.Admin.Students
{
    [Route("Admin/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;
        private readonly IDepartmentsService _departmentsService;

        public StudentsController(IStudentService service, IDepartmentsService departmentService)
        {
            _service = service;
            _departmentsService = departmentService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var students = await _service.GetAllStudents();
            return View(students);
        }

        [HttpGet("CreateStudent")]
        public async Task<IActionResult> CreatePartial()
        {
            var departments = await _departmentsService.GetAllDepartments();
            ViewBag.Departments = new SelectList((System.Collections.IEnumerable)departments, "Id", "DepartmentName");
            return PartialView("_StudentForm", new Student());
        }

        [HttpGet("EditStudent/{id}")]
        public async Task<IActionResult> EditPartial(int id)
        {
            var student = await _service.GetByIdAsync(id);
            var departments = await _departmentsService.GetAllDepartments();

            ViewBag.Departments = new SelectList(departments, "Id", "DepartmentName", student.DepartmentId);

            return PartialView("_StudentForm", student);
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreatePartial(StudentsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(await _departmentsService.GetAllDepartments(), "Id", "DepartmentName", vm.DepartmentId);
                return PartialView("_StudentPartial", vm); // return form with validation errors
            }

            await _service.AddStudent(vm);

            return Json(new
            {
                success = true,
                isNew = true, // indicate it’s a new student
                student = new
                {
                    id = vm.Id, // if service sets Id, make sure to return it
                    rollNumber = vm.RollNumber,
                    fullName = vm.FullName,
                    dateOfBirth = vm.DateOfBirth.ToString("dd-MMM-yyyy"),
                    email = vm.Email,
                    phone = vm.Phone,
                    departmentId = vm.DepartmentId
                }
            });
        }

        [HttpPost("EditStudent")]
        public async Task<IActionResult> EditPartial(StudentsViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_StudentFormPartial", student);
            }

            try
            {
                await _service.UpdateStudent(student);
                return Json(new
                {
                    success = true,
                    student = new
                    {
                        student.Id,
                        student.RollNumber,
                        student.FullName,
                        DateOfBirth = student.DateOfBirth.ToString("dd-MMM-yyyy"),
                        student.Email,
                        student.Phone,
                        student.DepartmentId
                    }
                });
            }
            catch (KeyNotFoundException)
            {
                return Json(new { success = false, message = "Student not found" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Error while updating student" });
            }
        }

        [HttpPost("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Json(new { success = true, id = id });

            }
            catch (KeyNotFoundException)
            {
                return Json(new { success = false, message = "Student not found" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Error while updating student" });
            }
        }

    }
}

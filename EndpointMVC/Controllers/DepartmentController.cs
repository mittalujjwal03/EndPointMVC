using Microsoft.AspNetCore.Mvc;
using EmployeeDepartmentMVC.Services;
using EndpointMVC.IServices;
using EndpointMVC.Models;

namespace EmployeeDepartmentMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.CreateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

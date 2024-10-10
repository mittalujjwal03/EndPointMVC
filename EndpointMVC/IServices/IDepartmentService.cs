using EndpointMVC.Models;

namespace EndpointMVC.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}

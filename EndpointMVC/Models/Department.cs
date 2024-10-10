using System.ComponentModel.DataAnnotations;

namespace EndpointMVC.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string? DepartmentName { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        public int EmployeeCount => Employees?.Count ?? 0;
    }
}

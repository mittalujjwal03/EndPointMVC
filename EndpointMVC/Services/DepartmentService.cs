using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using EndpointMVC.IServices;
using EndpointMVC.Models;

namespace EmployeeDepartmentMVC.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeDepartmentAPI");
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Department>>("Departments").Result;
        }

        public Department GetDepartmentById(int id)
        {
            return _httpClient.GetFromJsonAsync<Department>($"Departments/{id}").Result;
        }

        public Department CreateDepartment(Department department)
        {
            var response = _httpClient.PostAsJsonAsync("Departments", department).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<Department>().Result;
        }

        public void UpdateDepartment(Department department)
        {
            var response = _httpClient.PutAsJsonAsync($"Departments/{department.DepartmentId}", department).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteDepartment(int id)
        {
            var response = _httpClient.DeleteAsync($"Departments/{id}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}

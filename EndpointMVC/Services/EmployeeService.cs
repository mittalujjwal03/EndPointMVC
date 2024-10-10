using EndpointMVC.IServices;
using EndpointMVC.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeDepartmentMVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IHttpClientFactory httpClientFactory, ILogger<EmployeeService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeDepartmentAPI");
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("Employees");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all employees");
                throw; // Rethrow to let calling code handle the error
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Employee>($"Employees/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching employee with ID {id}");
                throw;
            }
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Employees", employee);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Employee>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Employees/{employee.EmployeeId}", employee);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating employee with ID {employee.EmployeeId}");
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Employees/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting employee with ID {id}");
                throw;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.EmployeeDtos;
using RealEstate.API.Repositories.EmployeeRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employees: {ex.Message}");
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployee(employeeId);
                return Ok(employee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                _employeeRepository.DeleteEmployee(employeeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting employee: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data is null.");
            }
            try
            {
                _employeeRepository.CreateEmployee(employeeDto);
                return Ok("Employee added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding employee: {ex.Message}");
            }
        }
    }
}

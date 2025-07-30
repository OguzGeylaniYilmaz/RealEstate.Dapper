using RealEstate.API.Dtos.EmployeeDtos;

namespace RealEstate.API.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetEmployeesAsync();
        Task<GetEmployeeByIdDto> GetEmployee(int employeeId);
        void DeleteEmployee(int employeeId);
        void CreateEmployee(CreateEmployeeDto createEmployee);
        void UpdateEmployee(UpdateEmployeeDto updateEmployee);
    }
}

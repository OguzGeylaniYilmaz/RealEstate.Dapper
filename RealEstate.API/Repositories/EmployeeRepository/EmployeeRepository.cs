using Dapper;
using RealEstate.API.Dtos.EmployeeDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployee)
        {
            var query = "INSERT INTO Employees (Name, Title, Mail, PhoneNumber, ImageUrl, Status) VALUES (@Name, @Title, @Mail, @PhoneNumber, @ImageUrl, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", createEmployee.Name);
            parameters.Add("Title", createEmployee.Title);
            parameters.Add("Mail", createEmployee.Mail);
            parameters.Add("PhoneNumber", createEmployee.PhoneNumber);
            parameters.Add("ImageUrl", createEmployee.ImageUrl);
            parameters.Add("Status", true);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async void DeleteEmployee(int employeeId)
        {
            var query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employeeId);
            using var connection = _context.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(query, parameters);
            if (rowsAffected == 0)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }
        }

        public async Task<GetEmployeeByIdDto> GetEmployee(int employeeId)
        {
            string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", employeeId);
            using var connection = _context.CreateConnection();
            var employee = await connection.QueryFirstOrDefaultAsync<GetEmployeeByIdDto>(query, parameters);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }
            return employee;
        }

        public async Task<List<ResultEmployeeDto>> GetEmployeesAsync()
        {
            var query = "SELECT * FROM Employee";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultEmployeeDto>(query);
            return values.ToList();

        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            var query = "UPDATE Employees SET Name = @Name, Title = @Title, Mail = @Mail, PhoneNumber = @PhoneNumber, ImageUrl = @ImageUrl, Status = @Status WHERE EmployeeID = @EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeID", updateEmployee.EmployeeID);
            parameters.Add("Name", updateEmployee.Name);
            parameters.Add("Title", updateEmployee.Title);
            parameters.Add("Mail", updateEmployee.Mail);
            parameters.Add("PhoneNumber", updateEmployee.PhoneNumber);
            parameters.Add("ImageUrl", updateEmployee.ImageUrl);
            parameters.Add("Status", true);
            using var connection = _context.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(query, parameters);
        }
    }
}

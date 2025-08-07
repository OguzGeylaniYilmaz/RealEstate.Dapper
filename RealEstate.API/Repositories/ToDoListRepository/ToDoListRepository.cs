using Dapper;
using RealEstate.API.Dtos.ToDoListDtos;
using RealEstate.API.Models.DapperContext;

namespace RealEstate.API.Repositories.ToDoListRepository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDo(CreateToDoListDto createToDoListDto)
        {
            string query = "INSERT INTO ToDoList (Description, Status) VALUES (@Description, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", createToDoListDto.Description);
            parameters.Add("Status", createToDoListDto.Status);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }


        public async Task<List<ResultToDoListDto>> GetAllToDosAsync()
        {
            string query = "SELECT * From ToDoList";
            using var connection = _context.CreateConnection();
            var toDoList = await connection.QueryAsync<ResultToDoListDto>(query);
            return toDoList.ToList();
        }

        public async void UpdateToDo(UpdateToDoListDto updateToDoList)
        {
            string query = "UPDATE ToDoList SET Description = @Description, Status = @Status WHERE ToDoListID = @ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("ToDoListID", updateToDoList.ToDoListID);
            parameters.Add("Description", updateToDoList.Description);
            parameters.Add("Status", true);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async void DeleteToDo(int id)
        {
            string query = "DELETE FROM ToDoList WHERE ToDoListID = @ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("ToDoListID", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

    }
}

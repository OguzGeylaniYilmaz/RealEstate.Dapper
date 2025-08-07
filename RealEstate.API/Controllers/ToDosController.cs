using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.ToDoListDtos;
using RealEstate.API.Repositories.ToDoListRepository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDosController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDos()
        {
            var toDoList = await _toDoListRepository.GetAllToDosAsync();
            return Ok(toDoList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoListDto createToDoListDto)
        {
            if (createToDoListDto == null)
            {
                return BadRequest("Invalid ToDo data.");
            }
            _toDoListRepository.CreateToDo(createToDoListDto);
            return Ok("ToDo created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(UpdateToDoListDto updateToDoListDto)
        {
            if (updateToDoListDto == null)
            {
                return BadRequest("Invalid ToDo data.");
            }
            _toDoListRepository.UpdateToDo(updateToDoListDto);
            return Ok("ToDo updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ToDo ID.");
            }
            _toDoListRepository.DeleteToDo(id);
            return Ok("ToDo deleted successfully.");
        }

    }
}

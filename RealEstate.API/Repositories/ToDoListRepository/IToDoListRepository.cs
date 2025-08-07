using RealEstate.API.Dtos.ToDoListDtos;

namespace RealEstate.API.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDosAsync();
        void CreateToDo(CreateToDoListDto createToDoListDto);
        void UpdateToDo(UpdateToDoListDto updateToDoList);
        void DeleteToDo(int id);
    }
}

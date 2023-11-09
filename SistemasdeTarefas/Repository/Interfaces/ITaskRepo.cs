using SistemasdeTarefas.Models;

namespace SistemasdeTarefas.Repository.Interfaces
{
    public interface ITaskRepo
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);

    }
}

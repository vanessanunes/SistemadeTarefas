using SistemasdeTarefas.Models;

namespace SistemasdeTarefas.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using SistemasdeTarefas.Data;
using SistemasdeTarefas.Models;
using SistemasdeTarefas.Repository.Interfaces;

namespace SistemasdeTarefas.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly TasksDBContext _dbContext;
        public UserRepo(TasksDBContext tasksDBContext) {
            _dbContext = tasksDBContext;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID {id}: não foi encontrado no banco de dados.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasdeTarefas.Models;
using SistemasdeTarefas.Repository.Interfaces;

namespace SistemasdeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo) 
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUser()
        {
            List<UserModel> users = await _userRepo.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepo.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel newUser)
        {
            UserModel user = await _userRepo.Add(newUser);
            return Ok(user);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel updateUser, int id)
        {
            UserModel user = await _userRepo.Update(updateUser, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool deleted = await _userRepo.Delete(id);
            return Ok(deleted);
        }
    }
}

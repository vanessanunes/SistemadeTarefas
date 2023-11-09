using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasdeTarefas.Models;
using SistemasdeTarefas.Repository.Interfaces;

namespace SistemasdeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo _taskRepo;

        public TaskController(ITaskRepo taskRepo) 
        {
            _taskRepo = taskRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepo.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetById(int id)
        {
            TaskModel task = await _taskRepo.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel newTask)
        {
            TaskModel task = await _taskRepo.Add(newTask);
            return Ok(task);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel updateTask, int id)
        {
            TaskModel task = await _taskRepo.Update(updateTask, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool deleted = await _taskRepo.Delete(id);
            return Ok(deleted);
        }
    }
}

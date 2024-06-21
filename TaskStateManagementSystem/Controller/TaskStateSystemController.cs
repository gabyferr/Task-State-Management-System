using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStateManagementSystem.Data;
using TaskStateManagementSystem.State.Enum;

namespace TaskStateManagementSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStateSystemController : Controller
    {
        //Conecta com o banco
        private readonly StateDBContext _context;
        public TaskStateSystemController(StateDBContext context)
        {
            _context = context;
        }

        //Envia para / criar uma tarefa

        [HttpPost]
        public async Task<ActionResult<State.TaskStateSystemModel>> PostTask(State.TaskStateSystemModel taskStateSystemModel)
        {
            taskStateSystemModel.State = StateTask.Created;
            _context.TaskStateSystemModel.Add(taskStateSystemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = taskStateSystemModel.Id }, taskStateSystemModel);
        }

        //Buscar uma tarefa.

        [HttpGet("{id}")]
        public async Task<ActionResult<State.TaskStateSystemModel>> GetTask(int id)
        {
            var tasks = await _context.TaskStateSystemModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        // Edita uma tarefa.
        [HttpPut("{id}/start")]
        public async Task<ActionResult<State.TaskStateSystemModel>> StartTask(int id)
        {
            var tasks = await _context.TaskStateSystemModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // Só realiza a altera se a tarefa estiver criada
            if (tasks.State == StateTask.Created)
            {
                tasks.State = StateTask.InProgress;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser iniciada!");
            }

            return tasks;
        }
        // Edita uma tarefa para completada
        [HttpPut("{id}/complete")]
        public async Task<ActionResult<State.TaskStateSystemModel>> CompleteTask(int id)
        {
            var tasks = await _context.TaskStateSystemModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            // Só altera se a tarefa estiver em progresso.
            if (tasks.State == StateTask.InProgress)
            {
                tasks.State = StateTask.Completed;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser completada!");
            }

            return tasks;
        }

        // Edita e coloca como tarefa cancelada.

        [HttpPut("{id}/cancel")]
        public async Task<ActionResult<State.TaskStateSystemModel>> CancelTask(int id)
        {
            var tasks = await _context.TaskStateSystemModel.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            // Realiza o cancelamento da tarefa criada ou em progresso
            if (tasks.State == StateTask.Created || tasks.State == StateTask.InProgress)
            {
                tasks.State = StateTask.Canceled;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("A tarefa não pode ser cancelada!");
            }

            return tasks;
        }
    }
}

using AngularPractice.DBContext;
using AngularPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly MyDBContext _dBContext;

        public TodoController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpPost]
        [Route("AddTodo")]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            try
            {
                todo.Id = Guid.NewGuid();
                _dBContext.Add(todo);
                await _dBContext.SaveChangesAsync();

                return Ok(new { Message = "Todo added successfully", Todo = todo });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllTodos")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result =  _dBContext.Todos.ToList();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTodo/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var existingTodo = _dBContext.Todos.FirstOrDefault(x => x.Id == Id);

            if (existingTodo != null)
            {
                _dBContext.Todos.Remove(existingTodo);
                await _dBContext.SaveChangesAsync();
                return Ok(existingTodo);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}

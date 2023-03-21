using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Repository.InMemory;

namespace TodoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        TodoInMemoryRepository _repo = new TodoInMemoryRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            // status - http responce
            // ok 200 status code - json 
            return Ok(_repo.GetAllTodos()); // json or xml
        }

        [HttpGet("todoId")]
        public IActionResult GetById([FromRoute] int todoId) // model binding 
        {
            var todo = _repo.GetTodoById(todoId);
            if (todo == null)
                return BadRequest("No resource found");
            return Ok(todo); // json or xml
        }

        [HttpDelete("todoId")]
        public IActionResult Delete([FromRoute] int todoId) // model binding 
        {
            var todo = _repo.GetTodoById(todoId);
            if (todo == null)
                return BadRequest("No resource found");
            return Ok(_repo.DeleteTodo(todoId)); // json or xml
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] Todo todo) // model binding // validation
        {
            if (todo == null)
                return BadRequest("No resource found");
            if (ModelState.IsValid)
            {
                return Ok(_repo.AddTodo(todo)); // json or xml
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{todoId}")]
        public IActionResult UpdateTodo([FromBody] Todo todo, [FromRoute] int todoId) // model binding // validation
        {
            if (todo == null)
                return BadRequest("No resource found");
            if (ModelState.IsValid)
            {
                return Ok(_repo.UpdateTodo(todoId, todo)); // json or xml
            }
            return BadRequest(ModelState);
        }
    }
}

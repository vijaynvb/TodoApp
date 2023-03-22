using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Repository.InMemory;

namespace TodoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase // json xml, controllers views
    {
        TodoInMemoryRepository _repo = new TodoInMemoryRepository();
        [HttpGet]
        public IActionResult GetAll()
        {
            // status - http responce
            // ok 200 status code - json 
            return Ok(_repo.GetAllTodos()); // json or xml
        }

        [HttpGet("{todoId}")]
        public IActionResult GetById([FromRoute] int todoId) // model binding 
        {
            Todo todo;
            try
            {
                todo = _repo.GetTodoById(todoId);
                if (todo == null)
                    return NotFound("No resource found"); // 404
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(todo); // json or xml 200 ok
        }

        [HttpDelete("{todoId}")]
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
                var newtodo = _repo.AddTodo(todo);
                // return the url for it
                return Ok(newtodo);
                //return CreatedAtAction("GetById",new { todoId = newtodo.Id },null); // json or xml
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

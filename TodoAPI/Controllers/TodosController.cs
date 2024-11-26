using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTO;
using TodoAPI.Models;
using TodoAPI.Repository;
using TodoAPI.Repository.InMemory;
using TestSelenium;

namespace TodoAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase // json xml, controllers views
    {
        ITodoRepository _repo;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository todoRepository,
                               IMapper mapper)
        {
            string str = "Hello World";
           
            _repo = todoRepository;
            _mapper = mapper;
        }

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
            if (todoId == 0)
                return BadRequest();
            Todo todo;
            try
            {
                todo = _repo.GetTodoById(todoId);
                if (todo == null)
                    return NoContent(); // 404 NotFound, NoContent 204 -> success message with no content 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(todo); // json or xml 200 ok
        }

        [HttpDelete("{todoId}")]
        public IActionResult Delete([FromRoute] int todoId) // model binding 
        {
            if (todoId == 0)
                return BadRequest();
            var todo = _repo.GetTodoById(todoId);
            if (todo == null)
                return NotFound("No resource found");
            return Accepted(_repo.DeleteTodo(todoId)); // json or xml
        }

        [HttpPost]
        // model binding 
        // todoDTO? -> asp.net framework, model binding -> validation of your data against the model
        // data transfer object Client to server -> database -> model
        public IActionResult AddTodo([FromBody] TodoDTO todoDTO) // model binding // validation
        {
            if (todoDTO == null)
                return BadRequest("No data provided");
            if (ModelState.IsValid)
            {
                /*var todo = new Todo()
                {
                    Title=todoDTO.Title,
                    Description=todoDTO.Description,
                    Status=todoDTO.Status,
                    DueDate=todoDTO.DueDate
                };*/

                var todo = _mapper.Map<Todo>(todoDTO);

                var newtodo = _repo.AddTodo(todo);
                // return the url for it
                return CreatedAtAction("GetById", new { todoId = newtodo.Id }, newtodo);
                //return CreatedAtAction("GetById",new { todoId = newtodo.Id },null); // json or xml
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{todoId}")]
        public IActionResult UpdateTodo([FromBody] Todo todo, [FromRoute] int todoId) // model binding // validation
        {
            if (todo == null)
                return BadRequest("No data provided");
            if (ModelState.IsValid)
            {
                var updatedTodo = _repo.UpdateTodo(todoId, todo);
                return AcceptedAtAction("GetById", new { todoId = updatedTodo.Id }, updatedTodo); // json or xml
            }
            return BadRequest(ModelState);
        }
    }
}

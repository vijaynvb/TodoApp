using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Repository.MsSQL
{
    public class TodoDBRepository : ITodoRepository
    {
        // interact with database and perform CRUD 

        TodoDbContext _dbContext;

        public TodoDBRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Todo AddTodo(Todo newTodo)
        {
            // stored procedure to insert the data into todo table 
            _dbContext.Add(newTodo);
            // CUD operation you need to save the details -> Commit
            _dbContext.SaveChanges();
            return newTodo;
        }

        public Todo DeleteTodo(int todoId)
        {
            var todo = GetTodoById(todoId);
            if (todo != null)
            {
                _dbContext.Todos.Remove(todo);
                _dbContext.SaveChanges();
            }
            return todo;
        }

        public List<Todo> GetAllTodos()
        {

            // fetch via using entity framework core db context models  
            //return _dbContext.Todos.AsNoTracking().ToList();

            // fetch the data from stored procedure
            return _dbContext.Todos.FromSqlRaw($"exec getalltodos").ToList();
        }

        public Todo GetTodoById(int Id)
        {
            // keeps track of it, if any changes happen to the object we can save it automatically
            // discard the default behaviour of EF not to track
             return _dbContext.Todos.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);

            // fetch the data from stored procedure
            
             //   var todos = _dbContext.Todos.FromSqlRaw($"exec gettodobyid {0}", Id).ToList();
           
            //return todos.FirstOrDefault();
        }

        public Todo UpdateTodo(int todoId, Todo newTodo)
        {
            //_dbContext.Todos.Attach(newTodo);
            _dbContext.Todos.Update(newTodo);
            _dbContext.SaveChanges();
            return newTodo;
        }
    }
}

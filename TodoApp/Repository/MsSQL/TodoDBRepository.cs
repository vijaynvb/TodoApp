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
            return _dbContext.Todos.AsNoTracking().ToList();
        }

        public Todo GetTodoById(int Id)
        {
            // keeps track of it, if any changes happen to the object we can save it automatically
            // discard the default behaviour of EF not to track
            return _dbContext.Todos.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
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

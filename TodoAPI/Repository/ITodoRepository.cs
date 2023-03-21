using TodoAPI.Models;

namespace TodoAPI.Repository
{
    public interface ITodoRepository // contract 
    {
        List<Todo> GetAllTodos();

        // get any specific todo
        Todo GetTodoById(int Id);

        // add todo into the list
        Todo AddTodo(Todo newTodo);

        // update todo in the list
        Todo UpdateTodo(int todoId, Todo newTodo);

        // delete 
        Todo DeleteTodo(int todoId);
    }
}

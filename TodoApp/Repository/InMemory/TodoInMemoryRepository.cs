using TodoApp.Models;

namespace TodoApp.Repository.InMemory
{
    public class TodoInMemoryRepository : ITodoRepository // Datastore
    {
        // it will hold the data in runtime and allow to perfrom crud operations

        static List<Todo> todoList = new List<Todo>();

        static TodoInMemoryRepository()
        {
            todoList.Add(new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1)));
            todoList.Add(new Todo(2, "Learn C#", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
            todoList.Add(new Todo(3, "Learn MSSQL", "In Jump Trainin", false, DateTime.Now.AddDays(2)));
        }
        public List<Todo> GetAllTodos()
        {
            return todoList;
        }

        // get any specific todo
        public Todo GetTodoById(int Id)
        {
            return todoList.FirstOrDefault(x => x.Id == Id);
        }

        // add todo into the list
        public Todo AddTodo(Todo newTodo)
        {
            newTodo.Id = todoList.Max(x => x.Id)+1; // max id of your list
            todoList.Add(newTodo);
            return newTodo;
        }

        // update todo in the list
        public Todo UpdateTodo(int todoId, Todo newTodo)
        {
            var oldTodo = todoList.Find(x => x.Id == todoId);
            if (oldTodo == null)
                return null;
            todoList.Remove(oldTodo) ;
            todoList.Add(newTodo);
            return newTodo;
        }

        // delete 
        public Todo DeleteTodo(int todoId)
        {
            var oldTodo = todoList.Find(x => x.Id == todoId);
            if (oldTodo == null)
                return null;
            todoList.Remove(oldTodo);
            return oldTodo;
        }
    }
}

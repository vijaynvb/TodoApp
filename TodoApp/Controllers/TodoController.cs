using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Repository;
using TodoApp.Repository.InMemory;
using TodoApp.Repository.MsSQL;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        // inmemory
        // database
        // RDBMS
        // NoSQL
        // Files

        ITodoRepository _repo;

        // tightly coupled object 
        //ITodoRepository _repo = new InMemoryRepository();
        //ITodoRepository _repo1 = new DBRepository();

        // lossely coupled implementation
        public TodoController(ITodoRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllTodos()
        {
            var todolist = _repo.GetAllTodos();
            return View(todolist);
        }
        public IActionResult Details(int todoId)
        {
            var todo = _repo.GetTodoById(todoId);
            return View(todo);
        }
        public IActionResult Delete(int todoId)
        {
            var todolist = _repo.DeleteTodo(todoId);
            return RedirectToAction(controllerName: "Todo", actionName: "GetAllTodos"); // reload the getall page it self
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Todo newTodo) // model binded this where the views data is accepted 
        {
            if (ModelState.IsValid){
                var todo = _repo.AddTodo(newTodo);
                return RedirectToAction("GetAllTodos");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int todoId)
        {
            var oldTodo = _repo.GetTodoById(todoId);
            return View(oldTodo);
        }
        [HttpPost]
        public IActionResult Update(Todo newTodo)
        {
            var todo = _repo.UpdateTodo(newTodo.Id, newTodo);
            return RedirectToAction("GetAllTodos");
        }

        #region :: Razor views examples ::
        public IActionResult someAction()
        {
            // server has to respond with http response
            // 4 properties of http reponse will be set 
            //return View("/Views/Home/Index.cshtml"); // invoking razor engine to generate html contente defined in views folder
            // how all we can pass data to views
            /*
             * 1. viewdata
             * 2. viewbag
             * 3. strongly types - 
             */
            // its are getting resolved in runtime only
            ViewData["Name"] = "Vijay";
            ViewBag.Department = "IT Team";
            var todo = _repo.GetTodoById(1);
            // viewmodel
            SomeActionViewModel smvm = new SomeActionViewModel();
            smvm.user = "vijay";
            smvm.todo = todo;
            return View(smvm);
        }

        public IActionResult FormsExample()
        {
            //Todo newTodo = new Todo(); // empty object
            Todo newTodo = new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1));
            return View(newTodo);
        }


        public IActionResult Add(Todo updatedTodo) // model binding 
        {
            return Json(updatedTodo);
        }

        #endregion
    }
}

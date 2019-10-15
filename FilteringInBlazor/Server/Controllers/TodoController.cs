using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilteringInBlazor.Database.Repositories;
using FilteringInBlazor.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FilteringInBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoItemsRepository _todoItemsRepository;

        public TodoController(TodoItemsRepository todoItemsRepository)
        {
            _todoItemsRepository = todoItemsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoItem todoItem)
        {
            var item = new Database.Models.TodoItem
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsDone = todoItem.IsDone
            };
            _todoItemsRepository.SaveOrUpdateTodoItem(item);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TodoItem todoItem)
        {
            var item = new Database.Models.TodoItem
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsDone = todoItem.IsDone
            };
            _todoItemsRepository.SaveOrUpdateTodoItem(item);

            return Ok();
        }

        [HttpGet("{getCompletedTasks?}")]
        public IEnumerable<TodoItem> Get(bool? getCompletedTasks)
        {
            return _todoItemsRepository.GetTodoItems(getCompletedTasks ?? true)
                .Select(x => new TodoItem
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDone = x.IsDone
                }).ToList();
        }

        [HttpGet("tasks/{searchText}")]
        public IEnumerable<TodoItem> SearchTasks(string searchText)
        {
            return _todoItemsRepository.SearchTodoItems(searchText)
                .Select(x => new TodoItem
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDone = x.IsDone
                }).ToList();
        }

    }
}
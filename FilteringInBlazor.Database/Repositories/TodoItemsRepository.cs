using System.Collections.Generic;
using System.Linq;
using FilteringInBlazor.Database.Models;

namespace FilteringInBlazor.Database.Repositories
{
    public class TodoItemsRepository : BaseRepository
    {
        public TodoItemsRepository(SqlDbContext context) : base(context)
        {
        }

        public void SaveOrUpdateTodoItem(TodoItem todoItem)
        {
            Context.TodoItems.Update(todoItem);
            Context.SaveChanges();
        }

        public IList<TodoItem> GetTodoItems(bool getDoneTasks = false)
        {
            if (getDoneTasks)
            {
                return Context.TodoItems.ToList();
            }
            return Context.TodoItems.Where(x => !x.IsDone).ToList();
        }

        public IList<TodoItem> SearchTodoItems(string searchTask)
        {
            if (!string.IsNullOrEmpty(searchTask))
            {
                return Context.TodoItems.Where(x=>x.Title.Contains(searchTask)).ToList();
            }
            return new List<TodoItem>();
        }
    }
}
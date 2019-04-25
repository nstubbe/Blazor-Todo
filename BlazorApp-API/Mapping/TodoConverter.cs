using BlazorApp_API.Core.Entities;
using BlazorApp_API.Models;

namespace BlazorApp_API.Mapping
{
    public class TodoConverter : IConverter<TodoModel, Todo>
    {
        public Todo Convert(TodoModel sourceObject)
        {
            return new Todo
            {
                DeadLine = sourceObject.DeadLine,
                Description = sourceObject.Description,
                IsCompleted = sourceObject.IsCompleted
            };
        }

        public TodoModel Convert(Todo sourceObject)
        {
            return new TodoModel
            {
                Id = sourceObject.Id,
                DeadLine = sourceObject.DeadLine,
                Description = sourceObject.Description,
                IsCompleted = sourceObject.IsCompleted
            };
        }
    }
}

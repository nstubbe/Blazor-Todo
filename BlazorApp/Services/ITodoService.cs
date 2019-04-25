using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetTodos();
        Task<TodoModel> GetTodoById(int id);
        Task<TodoModel> UpdateTodo(TodoModel model);
        Task<TodoModel> CreateTodo(TodoModel model);
        Task<bool> DeleteTodo(int id);
    }
}
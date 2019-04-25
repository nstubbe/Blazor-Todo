using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_API.Models;

namespace BlazorApp_API.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetAll();
        Task<TodoModel> GetById(int id);
        Task<TodoModel> Update(int id, TodoModel model);
        Task<TodoModel> Create(TodoModel model);
        Task Delete(int id);
    }
}
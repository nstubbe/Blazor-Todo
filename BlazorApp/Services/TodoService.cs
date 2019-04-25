using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BlazorApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly string _conn;

        public TodoService(IConfiguration config)
        {
            _conn = $"{config["ApiConnectionString"]}/todo";
        }
        public async Task<List<TodoModel>> GetTodos()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_conn);
                var json = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<List<TodoModel>>(json);
            }
        }

        public async Task<TodoModel> GetTodoById(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_conn}/{id}");
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TodoModel>(json);
            }
        }

        public async Task<TodoModel> UpdateTodo(TodoModel model)
        {
            using (var client = new HttpClient())
            {
                return await client.PutJsonAsync<TodoModel>($"{_conn}/{model.Id}", model);
            }
        }

        public async Task<TodoModel> CreateTodo(TodoModel model)
        {
            using (var client = new HttpClient())
            {
                return await client.PostJsonAsync<TodoModel>($"{_conn}", model);
            }
        }

        public async Task<bool> DeleteTodo(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{_conn}/{id}");
                return response.IsSuccessStatusCode;
            }
        }
    }
}

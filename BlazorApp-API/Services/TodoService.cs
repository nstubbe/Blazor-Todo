using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp_API.Core;
using BlazorApp_API.Core.Entities;
using BlazorApp_API.Mapping;
using BlazorApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_API.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;
        private readonly IConverter<TodoModel, Todo> _converter;

        public TodoService(TodoContext context, IConverter<TodoModel, Todo> converter)
        {
            _context = context;
            _converter = converter;
        }
        public async Task<List<TodoModel>> GetAll()
        {
            var entities = await _context.Todos.ToListAsync();
            return entities.Select(t => _converter.Convert(t)).ToList();
        }

        public async Task<TodoModel> GetById(int id)
        {
            var entity = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

            if (entity == null)
                return null;

            return _converter.Convert(entity);
        }

        public async Task<TodoModel> Update(int id, TodoModel model)
        {
            var entity = await _context.Todos.FindAsync(id);
            if (entity == null)
                return null;

            entity.DeadLine = model.DeadLine;
            entity.Description = model.Description;
            entity.IsCompleted = model.IsCompleted;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await GetById(id);
        }

        public async Task<TodoModel> Create(TodoModel model)
        {
            var entity = _converter.Convert(model);

            await _context.Todos.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _converter.Convert(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Todos.FindAsync(id);

            if (entity == null)
                return;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

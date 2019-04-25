using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp_API.Core;
using BlazorApp_API.Core.Entities;
using BlazorApp_API.Models;
using BlazorApp_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace BlazorApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoModel>>> Get()
        {
            var result = await _todoService.GetAll();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> Get(int id)
        {
            var result = await _todoService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> Post ([FromBody] TodoModel model)
        {
            var result = await _todoService.Create(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoModel>> Put(int id, [FromBody] TodoModel model)
        {
            var result = await _todoService.Update(id, model);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoService.Delete(id);
            return Ok();
        }
    }
}

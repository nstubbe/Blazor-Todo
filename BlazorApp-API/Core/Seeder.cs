using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_API.Core
{
    public static class Seeder
    {
        private static readonly string[] TodoDescriptions =
        {
            "Do the dishes",
            "Take out the garbage",
            "Create a blazor app"
        };

        public static async Task ResetDatabase(TodoContext context)
        {
            await Clear(context);
            await Seed(context);
        }

        private static async Task Seed(TodoContext context)
        {
            if (await context.Todos.AnyAsync())
                return;

            for (int i = 0; i < TodoDescriptions.Length; i++)
            {
                await context.Todos.AddAsync(new Todo
                {
                    DeadLine = DateTime.Now.AddDays(i),
                    Description = TodoDescriptions[i],
                    IsCompleted = i != 0
                });
            }

            await context.SaveChangesAsync();
        }

        private static async Task Clear(TodoContext context)
        {
            var todos = await context.Todos.ToListAsync();
            context.RemoveRange(todos);
            await context.SaveChangesAsync();
        }
    }
}

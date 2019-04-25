using System;

namespace BlazorApp.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsCompleted { get; set; }
    }
}

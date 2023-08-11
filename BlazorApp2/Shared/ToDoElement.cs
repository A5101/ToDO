using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class ToDoElement
    {
        [Required]
        public Guid Id { get; set; }
        public ToDoElement() => DateStarted = DateTime.Now;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime DatePlannedEnd { get; set; }
    }
}

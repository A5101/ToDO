using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Domain.Repositories.EntityFramework
{
    public class EFToDoElementRepository : IToDoElementRepository
    {
        private readonly AppDbContext context;

        public EFToDoElementRepository(AppDbContext context)
        {
            this.context = context;
            if (!context.ToDoElements.Any())
            {
                context.ToDoElements.AddRange(new List<ToDoElement>()
                {
                    new ToDoElement(){Title = "Задача1", Description = "Сделать задачу когда нибудь", IsComplete = false, Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eab"), DateStarted = DateTime.Now.AddDays(-4).Date, DatePlannedEnd = DateTime.Now.AddDays(3).Date},
                    new ToDoElement(){Title = "Задача2", Description = "Сделать как нибудь задачу", IsComplete = false, Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eac"), DateStarted = DateTime.Now.AddDays(-2).Date, DatePlannedEnd = DateTime.Now.AddDays(2).Date},
                    new ToDoElement(){Title = "Задача3", Description = "Сделать как нибудь задачу", IsComplete = false, Id = new Guid("44546e06-8719-4ad8-b88a-f271ae9d6eaa"), DateStarted = DateTime.Now.AddDays(-1).Date, DatePlannedEnd = DateTime.Now.AddDays(1).Date},
                });
                context.SaveChanges();
            }
        }

        public void Add(ToDoElement toDoElement)
        {
            context.ToDoElements.Add(toDoElement);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.ToDoElements.Remove(context.ToDoElements.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public List<ToDoElement> FetchTasks(List<DateTime> dates)
        {
            var dateDates = dates.Select(x => x.Date);
            return context.ToDoElements.Where(x => x.DateStarted >= dateDates.Min() && x.DateStarted <= dateDates.Max()
            || x.DatePlannedEnd >= dateDates.Min() && x.DatePlannedEnd <= dateDates.Max()
            || x.DateStarted <= dateDates.Min() && x.DatePlannedEnd >= dateDates.Max()).ToList();
        }

        public List<ToDoElement> Get()
        {
            return context.ToDoElements.ToList();
        }

        public void Update(ToDoElement toDoElement)
        {
            context.ToDoElements.Entry(toDoElement).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

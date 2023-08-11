using BlazorApp2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface IToDoElementRepository
    {
        public void Add(ToDoElement toDoElement);
        public void Delete(Guid id);
        public List<ToDoElement> Get();
        public void Update(ToDoElement toDoElement);
        public List<ToDoElement> FetchTasks(List<DateTime> dates);
    }
}

using BlazorApp2.Server.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Domain
{
    public class DataManager
    {
        public IToDoElementRepository toDoElementRepository { get; set; }

        public DataManager(IToDoElementRepository toDoElementRepository)
        {
            this.toDoElementRepository = toDoElementRepository;
        }
    }
}

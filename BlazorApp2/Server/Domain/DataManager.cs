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
        public IElementRepository ElementRepository { get; set; }

        public DataManager(IElementRepository elementRepository)
        {
            this.ElementRepository = elementRepository;
        }
    }
}

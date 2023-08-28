using BlazorApp2.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface IElementRepository
    {
        public void Add(Element element);
        public void Delete(Guid id);
        public List<Element> Get();
        public void Update(Element element);
    }
}

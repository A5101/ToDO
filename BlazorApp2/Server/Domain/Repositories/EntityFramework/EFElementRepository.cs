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
    public class EFElementRepository : IElementRepository
    {
        private readonly AppDbContext context;

        public EFElementRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Element element)
        {
            context.Elements.Add(element);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.Elements.Remove(context.Elements.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public List<Element> Get()
        {
            return context.Elements.ToList();
        }

        public void Update(Element element)
        {
            context.Elements.Entry(element).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

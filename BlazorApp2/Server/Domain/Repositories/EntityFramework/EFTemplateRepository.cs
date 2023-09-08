using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Domain.Repositories.EntityFramework
{
    public class EFTemplateRepository:ITemplateRepository
    {
        private readonly AppDbContext context;

        public EFTemplateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Template element)
        {
            context.Templates.Add(element);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.Templates.Remove(context.Templates.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public List<Template> Get()
        {
            return context.Templates.ToList();
        }

        public void Update(Template element)
        {
            context.Templates.Entry(element).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

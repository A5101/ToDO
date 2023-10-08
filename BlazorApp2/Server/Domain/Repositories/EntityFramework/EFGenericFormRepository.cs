using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlazorApp2.Server.Domain.Repositories.EntityFramework
{
    public class EFGenericFormRepository : IGenericFormRepository
    {
        private readonly AppDbContext context;

        public EFGenericFormRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(GenericForm genericForm)
        {
            context.GenericForms.Add(genericForm);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {

            context.GenericForms.Remove(context.GenericForms.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public List<GenericForm> Get()
        {
            return context.GenericForms.ToList();
        }

        public GenericForm GetFormById(Guid id)
        {
            return context.GenericForms.FirstOrDefault(x => x.Id == id);
        }

        public void Update(GenericForm genericForm)
        {
            if (!context.GenericForms.Contains(genericForm))
            {
                context.GenericForms.Entry(genericForm).State = EntityState.Added;
            }
            else
                context.GenericForms.Entry(genericForm).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

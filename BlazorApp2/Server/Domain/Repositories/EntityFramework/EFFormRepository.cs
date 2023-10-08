using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Shared;

namespace BlazorApp2.Server.Domain.Repositories.EntityFramework
{
    public class EFFormRepository : IFormRepository
    {
        private readonly AppDbContext context;

        public EFFormRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Form form)
        {
            context.Forms.Add(form);
            context.SaveChanges();
        }

        public List<Form> GetForms()
        {
            return context.Forms.ToList();
        }

        public void Delete(Guid id)
        {
            context.Forms.Remove(context.Forms.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}

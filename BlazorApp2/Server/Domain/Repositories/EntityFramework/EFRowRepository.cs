using BlazorApp2.Server.Domain.Repositories.Abstract;
using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Domain.Repositories.EntityFramework
{
    public class EFRowRepository : IRowRepository
    {
        private readonly AppDbContext context;

        public EFRowRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Row row)
        {
            context.Rows.Add(row);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            context.Rows.Remove(context.Rows.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public List<Row> Get(Guid id)
        {
            return context.Rows.Where(x => x.IdForm == id).ToList();
        }

        public void Update(Row row)
        {
            context.Rows.Entry(row).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

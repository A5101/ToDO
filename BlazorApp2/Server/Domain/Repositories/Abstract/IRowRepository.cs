using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface IRowRepository
    {
        public void Add(Row element);

        public void Delete(Guid id);

        public List<Row> Get(Guid id);

        public void Update(Row element);
    }
}

using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface ITemplateRepository
    {
        public void Add(Template element);

        public void Delete(Guid id);

        public List<Template> Get();

        public void Update(Template element);
    }
}

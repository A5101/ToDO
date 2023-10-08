using BlazorApp2.Shared;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface IGenericFormRepository
    {

        public List<GenericForm> Get();

        public void Add(GenericForm genericForm);

        public void Delete(Guid id);
        public void Update(GenericForm genericForm);
      
        public GenericForm GetFormById(Guid id);
    }
}

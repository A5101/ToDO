using BlazorApp2.Shared;

namespace BlazorApp2.Server.Domain.Repositories.Abstract
{
    public interface IFormRepository
    {
        public List<FormTemplateViewModel> GetFormsTemplates();
        public List<Form> GetForms();

        public void Add(Form form);
    }
}

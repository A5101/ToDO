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
            context.Add(form);
            context.SaveChanges();
        }

        public List<FormTemplateViewModel> GetFormsTemplates()
        {
            var list = new List<FormTemplateViewModel>();
            var formList = context.Forms.ToList();
            foreach (var form in formList)
            {
                list.Add(new FormTemplateViewModel()
                {
                    Templates = context.Templates.Where(x => x.IdForm == form.Id).ToList(),
                    Form = form
                });
            }
            return list;
        }

        public List<Form> GetForms()
        {
            return context.Forms.ToList();
        }
    }
}

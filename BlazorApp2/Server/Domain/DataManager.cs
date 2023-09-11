using BlazorApp2.Server.Domain.Repositories.Abstract;

namespace BlazorApp2.Server.Domain
{
    public class DataManager
    {
        public IElementRepository ElementRepository { get; set; }

        public ITemplateRepository TemplateRepository { get; set; }
        public IFormRepository FormRepository { get; set; }

        public DataManager(IElementRepository elementRepository, ITemplateRepository templateRepository, IFormRepository formRepository)
        {
            this.ElementRepository = elementRepository;
            this.TemplateRepository = templateRepository;
            this.FormRepository = formRepository;
        }
    }
}

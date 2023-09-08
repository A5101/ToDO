using BlazorApp2.Server.Domain.Repositories.Abstract;

namespace BlazorApp2.Server.Domain
{
    public class DataManager
    {
        public IElementRepository ElementRepository { get; set; }

        public ITemplateRepository TemplateRepository { get; set; }

        public DataManager(IElementRepository elementRepository, ITemplateRepository templateRepository)
        {
            this.ElementRepository = elementRepository;
            this.TemplateRepository = templateRepository;
        }
    }
}

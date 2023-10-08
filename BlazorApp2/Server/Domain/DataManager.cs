using BlazorApp2.Server.Domain.Repositories.Abstract;

namespace BlazorApp2.Server.Domain
{
    public class DataManager
    {
        public IElementRepository ElementRepository { get; set; }

        public IRowRepository RowRepository { get; set; }
        public IFormRepository FormRepository { get; set; }

        public IGenericFormRepository GenericFormRepository { get; set; }

        public DataManager(IElementRepository elementRepository, IRowRepository rowRepository, IFormRepository formRepository, IGenericFormRepository genericFormRepository)
        {
            this.ElementRepository = elementRepository;
            this.RowRepository = rowRepository;
            this.FormRepository = formRepository;
            this.GenericFormRepository = genericFormRepository;
        }
    }
}

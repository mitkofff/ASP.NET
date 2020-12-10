namespace StructuralDesign.Web.ViewModels.Book
{
    using AutoMapper;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class BookReadModeViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NamePartial { get; set; }

        public string FilePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookInListViewModel>()
                .ForMember(x => x.NamePartial, opt =>
                    opt.MapFrom(x => x.Name.Length > 40 ? (x.Name.Substring(0, 40) + "...") : x.Name));
        }
    }
}

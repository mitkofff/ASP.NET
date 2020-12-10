namespace StructuralDesign.Web.ViewModels.Book
{
    using AutoMapper;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class BookInListViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NamePartial { get; set; }

        public string Description { get; set; }

        public string DescriptionPartial { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookInListViewModel>()
                .ForMember(x => x.NamePartial, opt =>
                    opt.MapFrom(x => x.Name.Length > 40 ? (x.Name.Substring(0, 40) + "...") : x.Name))
                .ForMember(x => x.DescriptionPartial, opt =>
                    opt.MapFrom(x => x.Description.Length > 40 ? (x.Description.Substring(0, 40) + "...") : x.Description));
        }
    }
}

namespace StructuralDesign.Web.ViewModels.Administration
{
    using System;

    using AutoMapper;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class AdmDeleteViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string FilePath { get; set; }

        public string NamePartial { get; set; }

        public string Description { get; set; }

        public string DescriptionPartial { get; set; }

        public string OwnerName { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, AdmBookViewModel>()
                 .ForMember(x => x.NamePartial, opt =>
                    opt.MapFrom(x => x.Name.Length > 40 ? (x.Name.Substring(0, 40) + "...") : x.Name))
                .ForMember(x => x.DescriptionPartial, opt =>
                    opt.MapFrom(x => x.Description.Length > 40 ? (x.Description.Substring(0, 40) + "...") : x.Description))
                .ForMember(x => x.OwnerName, opt =>
                    opt.MapFrom(x => x.Owner.UserName));
        }
    }
}

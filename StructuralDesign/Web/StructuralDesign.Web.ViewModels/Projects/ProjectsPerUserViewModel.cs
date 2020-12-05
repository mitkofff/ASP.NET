namespace StructuralDesign.Web.ViewModels.Projects
{
    using AutoMapper;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Mapping;

    public class ProjectsPerUserViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string OwnerId { get; set; }

        public int NumberOfElements { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Project, ProjectsPerUserViewModel>()
                .ForMember(x => x.NumberOfElements, opt =>
                opt.MapFrom(p => p.Foundations.Count + p.ConcreteElements.Count + p.SteelElements.Count));
        }
    }
}

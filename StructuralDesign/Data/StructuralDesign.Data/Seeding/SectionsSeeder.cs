namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class SectionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sections.Any())
            {
                return;
            }

            await dbContext.Sections.AddAsync(new Section { Type = SectionType.IPE, Name = "IPE220", Height = 220, Width = 110, FlangeThickness = 9.2, WebThickness = 5.9, Area = 33.37, InertialMomentY = 2772, InertialMomentZ = 204.9, ResistanceMomentY = 252.0, ResistanceMomentZ = 37.25, InertialRadiusY = 9.11, InertialRadiusZ = 2.48 });
            await dbContext.Sections.AddAsync(new Section { Type = SectionType.IPE, Name = "IPE240", Height = 240, Width = 120, FlangeThickness = 9.8, WebThickness = 6.2, Area = 39.12, InertialMomentY = 3892, InertialMomentZ = 283.6, ResistanceMomentY = 324.3, ResistanceMomentZ = 47.27, InertialRadiusY = 9.97, InertialRadiusZ = 2.69 });
            await dbContext.Sections.AddAsync(new Section { Type = SectionType.IPE, Name = "IPE270", Height = 270, Width = 135, FlangeThickness = 10.2, WebThickness = 6.6, Area = 45.9, InertialMomentY = 5789.8, InertialMomentZ = 419.9, ResistanceMomentY = 424.0, ResistanceMomentZ = 62.2, InertialRadiusY = 11.2, InertialRadiusZ = 3.0 });

            await dbContext.SaveChangesAsync();
        }
    }
}

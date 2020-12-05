namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class MaterialSteelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MaterialSteels.Any())
            {
                return;
            }

            await dbContext.MaterialSteels.AddAsync(new MaterialSteel { Name = "S235", YieldStrength = 23.5, UltimateTensile = 36, ModulusOfElasticity = 21000, VolumeWeight = 7850 });
            await dbContext.MaterialSteels.AddAsync(new MaterialSteel { Name = "S275", YieldStrength = 27.5, UltimateTensile = 43, ModulusOfElasticity = 21000, VolumeWeight = 7850 });
            await dbContext.MaterialSteels.AddAsync(new MaterialSteel { Name = "S355", YieldStrength = 35.5, UltimateTensile = 49, ModulusOfElasticity = 21000, VolumeWeight = 7850 });

            await dbContext.SaveChangesAsync();
        }
    }
}

namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class MaterialRebarsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MaterialRebars.Any())
            {
                return;
            }

            await dbContext.AddAsync(new MaterialRebar { Name = "B500B", YieldStrength = 50, PartialSafetyFactor = 1.15, ModulusOfElasticity = 21000, VolumeWeight = 7850 });

            await dbContext.SaveChangesAsync();
        }
    }
}

namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class MaterialSoilSeeder : ISeeder
    {
        public async Task SeedAsync (ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MaterialSoils.Any())
            {
                return;
            }

            await dbContext.MaterialSoils.AddAsync(new MaterialSoil { Name = "Clay-Q", DesignPressure = 200, VolumeWeight = 18.5 });
            await dbContext.MaterialSoils.AddAsync(new MaterialSoil { Name = "Sand", DesignPressure = 250, VolumeWeight = 20 });
            await dbContext.MaterialSoils.AddAsync(new MaterialSoil { Name = "Gravel", DesignPressure = 300, VolumeWeight = 20 });

            await dbContext.SaveChangesAsync();
        }
    }
}

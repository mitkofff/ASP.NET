namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class BoltSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Bolts.Any())
            {
                return;
            }

            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M12", NominalDiameter = 12, NetoDiameter = 9.7, NetoArea = 0.84 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M(14)", NominalDiameter = 14, NetoDiameter = 12.4, NetoArea = 1.15 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M16", NominalDiameter = 16, NetoDiameter = 13.4, NetoArea = 1.57 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M18", NominalDiameter = 18, NetoDiameter = 14.7, NetoArea = 1.92 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M20", NominalDiameter = 20, NetoDiameter = 16.7, NetoArea = 2.45 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M(22)", NominalDiameter = 22, NetoDiameter = 18.7, NetoArea = 3.03 });
            await dbContext.Bolts.AddAsync(new ElementBolt { Name = "M24", NominalDiameter = 24, NetoDiameter = 20.1, NetoArea = 3.53 });

            await dbContext.SaveChangesAsync();
        }
    }
}

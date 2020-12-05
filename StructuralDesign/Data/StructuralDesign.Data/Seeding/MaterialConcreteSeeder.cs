namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class MaterialConcreteSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MaterialConcretes.Any())
            {
                return;
            }

            await dbContext.MaterialConcretes.AddAsync(new MaterialConcrete { Name = "C10/15", DesignCompressiveStrength = 0.95, DesignTensionStrength = 0.075, ModulusOfElasticity = 2500, VolumeWeight = 25 });
            await dbContext.MaterialConcretes.AddAsync(new MaterialConcrete { Name = "C15/20", DesignCompressiveStrength = 1.15, DesignTensionStrength = 0.090, ModulusOfElasticity = 2750, VolumeWeight = 25 });
            await dbContext.MaterialConcretes.AddAsync(new MaterialConcrete { Name = "C20/25", DesignCompressiveStrength = 1.45, DesignTensionStrength = 0.105, ModulusOfElasticity = 3000, VolumeWeight = 25 });
            await dbContext.MaterialConcretes.AddAsync(new MaterialConcrete { Name = "C25/30", DesignCompressiveStrength = 1.70, DesignTensionStrength = 0.120, ModulusOfElasticity = 3150, VolumeWeight = 25 });
            await dbContext.MaterialConcretes.AddAsync(new MaterialConcrete { Name = "C28/35", DesignCompressiveStrength = 1.95, DesignTensionStrength = 0.130, ModulusOfElasticity = 3300, VolumeWeight = 25 });

            await dbContext.SaveChangesAsync();
        }
    }
}

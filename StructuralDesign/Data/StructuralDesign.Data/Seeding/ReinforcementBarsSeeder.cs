namespace StructuralDesign.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Models;

    public class ReinforcementBarsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ReinforcementBars.Any())
            {
                return;
            }

            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 6 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 6.5 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 8 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 10 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 12 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 14 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 16 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 18 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 20 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 22 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 25 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 28 });
            await dbContext.ReinforcementBars.AddAsync(new ReinforcementBar { Diameter = 32 });

            await dbContext.SaveChangesAsync();
        }
    }
}

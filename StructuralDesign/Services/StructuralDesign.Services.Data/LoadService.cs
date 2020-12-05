namespace StructuralDesign.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Services.Data.Models;
    using StructuralDesign.Web.ViewModels.Load;

    public class LoadService : ILoadService
    {
        private readonly IRepository<Load> loadRepository;

        public LoadService(IRepository<Load> loadRepository)
        {
            this.loadRepository = loadRepository;
        }

        public async Task<int> CreateAsync(CreatLoadInputModel input)
        {
            var load = new Load
            {

                Type = (StructuralDesign.Data.Models.LoadType)input.Type,
                AxialForce = input.AxialForce,
                ShearForceY = input.ShearForceY,
                ShearForceZ = input.ShearForceZ,
                BendingMomentY = input.BendingMomentY,
                BendingMomentZ = input.BendingMomentZ,
            };

            await this.loadRepository.AddAsync(load);
            await this.loadRepository.SaveChangesAsync();
            return load.Id;
        }
    }
}

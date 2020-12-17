namespace StructuralDesign.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using StructuralDesign.Web.ViewModels.Load;

    public class LoadService : ILoadService
    {
        private readonly IRepository<Load> loadRepository;

        public LoadService(IRepository<Load> loadRepository)
        {
            this.loadRepository = loadRepository;
        }

        public async Task<int> CreateAsync(CreateLoadInputModel input)
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

        public async Task EditAsync(int id, CreateLoadInputModel input)
        {
            var load = this.loadRepository.All().Where(x => x.Id == id).FirstOrDefault();

            load.Type = (StructuralDesign.Data.Models.LoadType)input.Type;
            load.AxialForce = input.AxialForce;
            load.ShearForceY = input.ShearForceY;
            load.ShearForceZ = input.ShearForceZ;
            load.BendingMomentY = input.BendingMomentY;
            load.BendingMomentZ = input.BendingMomentZ;

            await this.loadRepository.SaveChangesAsync();
        }

        public Load GetSectionById(int id)
        {
            return this.loadRepository.All().FirstOrDefault(x => x.Id == id);
        }
    }
}

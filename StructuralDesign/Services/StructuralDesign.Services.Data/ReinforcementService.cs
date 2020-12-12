namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class ReinforcementService : IReinforcementService
    {
        private readonly IDeletableEntityRepository<MaterialRebar> reinforcementRepository;

        public ReinforcementService(IDeletableEntityRepository<MaterialRebar> reinforcementRepository)
        {
            this.reinforcementRepository = reinforcementRepository;
        }

        IEnumerable<KeyValuePair<string, string>> IReinforcementService.GetAllElementsAsKeyValue()
        {
            return this.reinforcementRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

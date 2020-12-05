namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class ReinforcementController : IReinforcementController
    {
        private readonly IDeletableEntityRepository<MaterialRebar> reinforcementRepository;

        public ReinforcementController(IDeletableEntityRepository<MaterialRebar> reinforcementRepository)
        {
            this.reinforcementRepository = reinforcementRepository;
        }

        IEnumerable<KeyValuePair<string, string>> IReinforcementController.GetAllElementsAsKeyValue()
        {
            return this.reinforcementRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class ReinforcementBarService : IReinforcementBarService
    {
        private readonly IDeletableEntityRepository<ReinforcementBar> reinforcementBarRepostitory;

        public ReinforcementBarService(IDeletableEntityRepository<ReinforcementBar> reinforcementBarRepostitory)
        {
            this.reinforcementBarRepostitory = reinforcementBarRepostitory;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.reinforcementBarRepostitory.All().Select(x => new
            {
                x.Id,
                x.Diameter,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), "Ф-" + x.Diameter + "mm"));
        }
    }
}

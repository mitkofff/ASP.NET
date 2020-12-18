namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class BoltService : IBoltService
    {
        private readonly IRepository<ElementBolt> boltRepository;

        public BoltService(IRepository<ElementBolt> boltRepository)
        {
            this.boltRepository = boltRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.boltRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class SteelService : ISteelService
    {
        private readonly IDeletableEntityRepository<MaterialSteel> steelRepository;

        public SteelService(IDeletableEntityRepository<MaterialSteel> steelRepository)
        {
            this.steelRepository = steelRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.steelRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }
    }
}

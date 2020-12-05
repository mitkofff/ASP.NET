namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;

    public class ConcreteService : IConcreteService
    {
        private readonly IDeletableEntityRepository<MaterialConcrete> concreteRepository;

        public ConcreteService(IDeletableEntityRepository<MaterialConcrete> concreteRepository)
        {
            this.concreteRepository = concreteRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.concreteRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

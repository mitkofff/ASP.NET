namespace StructuralDesign.Services.Data
{
    using StructuralDesign.Data.Common.Repositories;
    using StructuralDesign.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoilService : ISoilService
    {
        private readonly IDeletableEntityRepository<MaterialSoil> soilsRepository;

        public SoilService(IDeletableEntityRepository<MaterialSoil> soilsRepository)
        {
            this.soilsRepository = soilsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.soilsRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
                x.DesignPressure,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name + " - " + x.DesignPressure.ToString() + "kPa"));
        }
    }
}

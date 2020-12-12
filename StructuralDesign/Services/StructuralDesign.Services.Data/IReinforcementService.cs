using System.Collections.Generic;

namespace StructuralDesign.Services.Data
{
    public interface IReinforcementService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllElementsAsKeyValue();
    }
}

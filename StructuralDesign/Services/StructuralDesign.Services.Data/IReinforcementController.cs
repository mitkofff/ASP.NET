using System.Collections.Generic;

namespace StructuralDesign.Services.Data
{
    public interface IReinforcementController
    {
        IEnumerable<KeyValuePair<string, string>> GetAllElementsAsKeyValue();
    }
}

namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface IReinforcementService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllElementsAsKeyValue();
    }
}

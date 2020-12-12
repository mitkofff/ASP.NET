namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface IReinforcementBarService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

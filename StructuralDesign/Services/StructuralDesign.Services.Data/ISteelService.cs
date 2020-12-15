namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface ISteelService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

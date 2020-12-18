namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    using StructuralDesign.Data.Models;

    public interface ISteelService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

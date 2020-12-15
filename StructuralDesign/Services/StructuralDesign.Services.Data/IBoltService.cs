namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface IBoltService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface ISoilService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

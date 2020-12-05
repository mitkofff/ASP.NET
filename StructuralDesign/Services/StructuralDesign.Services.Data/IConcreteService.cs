namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface IConcreteService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

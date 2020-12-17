namespace StructuralDesign.Services.Data
{
    using System.Collections.Generic;

    public interface IBoundaryCondition
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}

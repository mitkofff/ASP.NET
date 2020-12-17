namespace StructuralDesign.Services.Data
{
    using StructuralDesign.Data.Models;
    using System.Collections.Generic;

    public class BoundaryConditionPair : IBoundaryCondition
    {
        public BoundaryConditionPair(BoundaryCondition boundaryCondition)
        {
            BoundaryCondition = boundaryCondition;
        }

        public BoundaryCondition BoundaryCondition { get; }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            throw new System.NotImplementedException();
        }
    }
}

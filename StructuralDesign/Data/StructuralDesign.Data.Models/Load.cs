namespace StructuralDesign.Data.Models
{
    using StructuralDesign.Data.Common.Models;

    public class Load : BaseModel<int>
    {
        public LoadType Type { get; set; }

        public double AxialForce { get; set; }

        public double ShearForceY { get; set; }

        public double ShearForceZ { get; set; }

        public double BendingMomentY { get; set; }

        public double BendingMomentZ { get; set; }
    }
}
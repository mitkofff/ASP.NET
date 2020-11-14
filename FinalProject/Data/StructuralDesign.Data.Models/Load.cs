namespace StructuralDesign.Data.Models
{
    using StructuralDesign.Data.Common.Models;

    public class Load : BaseModel<int>
    {
        public decimal? AxialForce { get; set; }

        public decimal? ShearForceY { get; set; }

        public decimal? ShearForceZ { get; set; }

        public decimal? BendingMomentY { get; set; }

        public decimal? BendingMomentZ { get; set; }

        public string ElementId { get; set; }

        public Element Element { get; set; }
    }
}

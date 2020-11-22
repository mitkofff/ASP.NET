namespace StructuralDesign.Services.Data.Models
{
    public class InputLoadDto
    {
        public LoadType Type { get; set; }

        public double? AxialForce { get; set; }

        public double? ShearForceY { get; set; }

        public double? ShearForceZ { get; set; }

        public double? BendingMomentY { get; set; }

        public double? BendingMomentZ { get; set; }

        public enum LoadType
        {
            ServiceLoad = 1,
            DesigLoad = 2,
            SeismicLoad = 3,
        }
    }
}

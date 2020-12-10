namespace StructuralDesign.Web.ViewModels.Foundation
{
    using StructuralDesign.Data.Models;
    public class FoundationResultViewModel
    {
        public string Name { get; set; }

        public double HeightOfFoundament { get; set; }

        public double HeightOfBackFill { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public string Result { get; set; }

        public string SoilName { get; set; }

        public string ConcreteName { get; set; }

        public string MaterialRebarName { get; set; }

        public string LoadType { get; set; }

        public double AxialForce { get; set; }

        public double ShearForceY { get; set; }

        public double ShearForceZ { get; set; }

        public double BendingMomentY { get; set; }

        public double BendingMomentZ { get; set; }

        public double ReducedAxialForce { get; set; }

        public double ReducedBendingMomentY { get; set; }

        public double ReducedBendingMomentZ { get; set; }

        public double AveragePressure { get; set; }

        public double PressureEdge { get; set; }

        public double PressureVertex1 { get; set; }

        public double PressureVertex2 { get; set; }

        public double PressureVertex3 { get; set; }

        public double PressureVertex4 { get; set; }
    }
}

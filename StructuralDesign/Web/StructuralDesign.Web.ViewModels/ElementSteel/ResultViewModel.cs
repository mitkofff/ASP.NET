namespace StructuralDesign.Web.ViewModels.ElementSteel
{
    using System;

    public class ResultViewModel
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public string SectionType { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double WebThickness { get; set; }

        public double ResistanceMomentY { get; set; }

        public double StaticMomentY { get; set; }

        public double InertialMomentY { get; set; }

        public string LeftBoundaryCondition { get; set; }

        public string RightBoundaryCondition { get; set; }

        public double ShearForceZ { get; set; }

        public double BendingMomentY { get; set; }

        public double YieldStrengthForElement { get; set; }

        public double PreassureBendingMomentY { get; set; }

        public double PreassureShearForceZ { get; set; }

        public double ResultFactorBendingMomentY { get; set; }

        public double ResultFactorShearForceZ { get; set; }

        public string ResultConclusion { get; set; }

        public double BoltDiameter { get; set; }

        public double BoltGrossArea { get; set; }

        public double CountOfBolt { get; set; }

        public double YieldStrengthForBolt { get; set; }
    }
}

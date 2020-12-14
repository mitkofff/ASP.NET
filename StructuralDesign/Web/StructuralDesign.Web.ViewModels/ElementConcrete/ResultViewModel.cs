namespace StructuralDesign.Web.ViewModels.ElementConcrete
{
    using System;

    public class ResultViewModel
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public double SectionWidth { get; set; }

        public double SectionHeight { get; set; }

        public double SectionArea { get; set; }

        public string LeftBoundaryCondition { get; set; }

        public string RightBoundaryCondition { get; set; }

        public double AxialForce { get; set; }

        public double SlendernessCoefficient { get; set; }

        public double BucklingCoefficient { get; set; }

        public double NecessaryReinforcement { get; set; }

        public double ReinforcementPercent => Math.Round(this.NecessaryReinforcement * 100 / (this.SectionArea / 100), 3);

        public double ReinforcementDiameter { get; set; }

        public double ReinforcementBarArea { get; set; }

        public double ConcreteDesignCompressiveStrength { get; set; }

        public double DesignReinforcementStrength { get; set; }

        public double CountOfReinforcementBars { get; set; }
    }
}

namespace StructuralDesign.Web.ViewModels.ElementConcrete
{
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

        public double ReinforcementPercent => this.NecessaryReinforcement / this.SectionArea * 100;

        public double ReinforcementDiameter { get; set; }

        public double ReinforcementBarArea { get; set; }

        public double ConcreteDesignCompressiveStrength { get; set; }

        public double DesignReinforcementStrength { get; set; }

        public double CountOfReinforcementBars { get; set; }
    }
}

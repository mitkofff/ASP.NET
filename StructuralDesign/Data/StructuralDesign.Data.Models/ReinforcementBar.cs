namespace StructuralDesign.Data.Models
{
    using StructuralDesign.Data.Common.Models;

    public class ReinforcementBar : BaseDeletableModel<int>
    {
        public double Diameter { get; set; }

        public double Area => this.Diameter * this.Diameter * 3.14 / 4;
    }
}

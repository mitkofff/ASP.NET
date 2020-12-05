namespace StructuralDesign.Services.Data.Sections
{
    public interface ISection
    {
        double Area();

        double InertialMomentY();

        double InertialMomentZ();

        public double ResistanceMomentY();

        public double ResistanceMomentZ();

        public double InertialRadiusY();

        public double InertialRadiusZ();
    }
}

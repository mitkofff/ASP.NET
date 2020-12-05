namespace StructuralDesign.Services.Data.Sections
{
    using System;

    public class DoubleT : ISection
    {
        private double height;
        private double width;
        private double flangeThickness;
        private double webThickness;

        public DoubleT(double height, double width, double flangeThickness, double webThickness)
        {
            this.Height = height;
            this.Width = width;
            this.FlangeThickness = flangeThickness;
            this.WebThickness = webThickness;
        }

        public double Area()
        {
            return ((this.height - (this.flangeThickness * 2)) * this.webThickness) + (2 * this.width * this.flangeThickness);
        }

        public double InertialMomentY()
        {
            return (this.webThickness * Math.Pow(this.height - (this.flangeThickness * 2), 3) / 12) + (2 * (this.width * this.flangeThickness * Math.Pow((this.height / 2) - (this.flangeThickness /2), 2)));
        }

        public double InertialMomentZ()
        {
            return (Math.Pow(this.webThickness, 3) * (this.height - (this.flangeThickness * 2)) / 12) + (2 * this.flangeThickness * Math.Pow(this.width, 3) / 12);
        }

        public double InertialRadiusY()
        {
            return Math.Sqrt(this.InertialMomentY() / this.Area());
        }

        public double InertialRadiusZ()
        {
            return Math.Sqrt(this.InertialMomentZ() / this.Area());
        }

        public double ResistanceMomentY()
        {
            return this.InertialMomentY() / (this.height / 2);
        }

        public double ResistanceMomentZ()
        {
            return this.InertialMomentZ() / (this.width / 2);
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height should be possitive number!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width should be possitive number!");
                }

                this.width = value;
            }
        }

        public double FlangeThickness
        {
            get
            {
                return this.flangeThickness;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Thickness of the flange should be possitive number!");
                }

                this.flangeThickness = value;
            }
        }

        public double WebThickness
        {
            get
            {
                return this.webThickness;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Thickness of the web should be possitive number!");
                }

                this.webThickness = value;
            }
        }
    }
}
namespace StructuralDesign.Services.Data.Sections
{
    using System;

    public class Rectangle : ISection
    {
        private double height;
        private double width;

        public Rectangle(double height, double width, double flangeThickness = 0, double webThickness = 0)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Area()
        {
            return this.height * this.width;
        }

        public double InertialMomentY()
        {
            return this.width * Math.Pow(this.height, 3) / 12;
        }

        public double InertialMomentZ()
        {
            return this.height * Math.Pow(this.width, 3) / 12;
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
            return this.width * Math.Pow(this.height, 2) / 6;
        }

        public double ResistanceMomentZ()
        {
            return this.height * Math.Pow(this.width, 2) / 6;
        }

        public double StaticMomentY()
        {
            return this.width * this.height * 0.5 * this.height * 0.25;
        }

        public double StaticMomentZ()
        {
            return this.height * this.width * 0.5 * this.width * 0.25;
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
    }
}

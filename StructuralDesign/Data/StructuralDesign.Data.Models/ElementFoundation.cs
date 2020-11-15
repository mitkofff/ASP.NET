namespace StructuralDesign.Data.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class ElementFoundation : BaseModel<string>
    {
        public ElementFoundation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int SectionId { get; set; }

        public virtual Section Section { get; set; }

        public decimal Height { get; set; }

        public decimal HeightOfBackFill { get; set; }

        public int LoadId { get; set; }

        public virtual Load Load { get; set; }

        public string Result { get; set; }

        public int SoilId { get; set; }

        public virtual MaterialSoil Soil { get; set; }

        public int ConcreteId { get; set; }

        public virtual MaterialConcrete Concrete { get; set; }

        public int MaterialRebarId { get; set; }

        public virtual MaterialRebar MaterialRebar { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

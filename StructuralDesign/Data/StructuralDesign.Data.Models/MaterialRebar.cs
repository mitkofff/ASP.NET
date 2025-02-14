﻿namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialRebar : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double YieldStrength { get; set; }

        [Required]
        public double PartialSafetyFactor { get; set; }

        [Required]
        public double VolumeWeight { get; set; }

        [Required]
        public double ModulusOfElasticity { get; set; }

    }
}

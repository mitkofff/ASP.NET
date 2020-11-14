namespace StructuralDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int Id { get; set; }

        public ApplicationUser Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}

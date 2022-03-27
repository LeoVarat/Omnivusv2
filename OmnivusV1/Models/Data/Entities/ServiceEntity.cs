using System.ComponentModel.DataAnnotations;

namespace OmnivusV1.Models.Data.Entities
{
    public class ServiceEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

    }
}

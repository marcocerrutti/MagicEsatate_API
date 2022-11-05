using System.ComponentModel.DataAnnotations;

namespace MagicEsatate_WebApi.Models.Dto
{
    public class EstateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        //public DateTime CreatedDate { get; set; }

        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace B2C2Core.Models
{
    public class Filiaal
    {
        [Key]
        public int FiliaalId { get; set; }

        public string Naam { get; set; }
    }
}

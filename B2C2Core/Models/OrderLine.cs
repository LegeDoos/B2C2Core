using System.ComponentModel.DataAnnotations;

namespace B2C2Core.Models
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public int Kwantiteit { get; set; }
        
        
        public string ProductNaam { get; set; }
    }
}

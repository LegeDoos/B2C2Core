using B2C2Core.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace B2C2Core.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Klant naam"), StringLength(100)]
        public string Klantnaam { get; set; }

       // [DataType(DataType.EmailAddress)]
       // public string Email { get; set; }
       //
       // [DataType(DataType.DateTime)]
       // public DateTime OrderDate{ get; set; }
              
        public List<OrderLine>? OrderLines { get; set; }


        public int FiliaalId { get; set; }
        public virtual Filiaal? Filiaal { get; set; }
    }
}

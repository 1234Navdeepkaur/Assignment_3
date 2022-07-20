using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusManagement.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string? Manufacturer { get; set; }
        public decimal Seats { get; set; }
        //Foreign Key
        public int Routeid { get; set; }

        [ForeignKey("Routeid")]
        public virtual Roadroute? Id { get; set; }
    }
}
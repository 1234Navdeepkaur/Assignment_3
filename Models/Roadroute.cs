using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusManagement.Models
{
    public class Roadroute
    {
        [Key]
        public int Id { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public decimal FairPrice { get; set; }
    }
}

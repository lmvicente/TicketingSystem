using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSystem.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set;}
        public string Summary { get; set;}
        public DateTime? ClosedDate { get; set; }
        public int AssignedTo { get; set; }
        public int TicketPriority { get; set;}
    }
}

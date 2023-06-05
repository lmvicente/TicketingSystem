using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSystem.Models
{
    public class Technicians
    {
        [Key]
        public int TechnicianID { get; set; }
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public bool IsActive { get;set; }
    }
}

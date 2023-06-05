using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class AllTickets
    {
        [Key]
        public int TicketID { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }   
        public string Title { get; set; }   
        public string Summary { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? ClosedDate { get; set; }    
        public string TechName { get; set; }    
        public string Priority { get; set; }

    }
}

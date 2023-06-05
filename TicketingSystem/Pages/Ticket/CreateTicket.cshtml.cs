using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSystem.Models;

namespace TicketingSystem.Pages.Ticket
{
    public class CreateTicketModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public CreateTicketModel(TicketingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tickets Tickets { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tickets == null || Tickets == null)
            {
                return Page();
            }

            Tickets.AssignedTo = 0;
            Tickets.TicketPriority = 1;
            _context.Tickets.Add(Tickets);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AllTickets");
        }
    }
}

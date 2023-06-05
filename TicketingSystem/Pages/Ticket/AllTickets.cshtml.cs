using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Models;

namespace TicketingSystem.Pages.TicketHistory
{
    public class TicketsViewModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public TicketsViewModel(TicketingSystemContext context)
        {
            _context = context;
        }

        public IList<AllTickets> AllTickets { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AllTickets != null)
            {
                AllTickets = await _context.AllTickets.ToListAsync();
            }
        }
    }
}

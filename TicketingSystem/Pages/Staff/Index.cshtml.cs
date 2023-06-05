using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Models;

namespace TicketingSystem.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public IndexModel(TicketingSystemContext context)
        {
            _context = context;
        }

        public IList<Technicians> Technicians { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Technicians != null)
            {
                Technicians = await _context.Technicians.ToListAsync();
            }
        }
    }
}

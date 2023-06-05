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
    public class DeleteModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public DeleteModel(TicketingSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Technicians Technicians { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Technicians == null)
            {
                return NotFound();
            }

            var technicians = await _context.Technicians.FirstOrDefaultAsync(m => m.TechnicianID == id);

            if (technicians == null)
            {
                return NotFound();
            }
            else 
            {
                Technicians = technicians;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Technicians == null)
            {
                return NotFound();
            }
            var technicians = await _context.Technicians.FindAsync(id);

            if (technicians != null)
            {
                Technicians = technicians;
                _context.Technicians.Remove(Technicians);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

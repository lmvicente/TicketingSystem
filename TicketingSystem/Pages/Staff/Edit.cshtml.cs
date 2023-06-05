using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Models;

namespace TicketingSystem.Pages.Staff
{
    public class EditModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public EditModel(TicketingSystemContext context)
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

            var technicians =  await _context.Technicians.FirstOrDefaultAsync(m => m.TechnicianID == id);
            if (technicians == null)
            {
                return NotFound();
            }
            Technicians = technicians;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Technicians).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechniciansExists(Technicians.TechnicianID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TechniciansExists(int id)
        {
          return (_context.Technicians?.Any(e => e.TechnicianID == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSystem.Models;

namespace TicketingSystem.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly TicketingSystemContext _context;

        public CreateModel(TicketingSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Technicians Technicians { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Technicians == null || Technicians == null)
            {
                return Page();
            }

            _context.Technicians.Add(Technicians);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

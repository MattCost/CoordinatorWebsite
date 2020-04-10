using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoordinatorWebpage.Data;
using CoordinatorWebpage.Models;

namespace CoordinatorWebpage.Pages.Coordinators
{
    public class DeleteModel : PageModel
    {
        private readonly CoordinatorWebpage.Data.CoordinatorContext _context;

        public DeleteModel(CoordinatorWebpage.Data.CoordinatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coordinator Coordinator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coordinator = await _context.Coordinator.FirstOrDefaultAsync(m => m.ID == id);

            if (Coordinator == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coordinator = await _context.Coordinator.FindAsync(id);

            if (Coordinator != null)
            {
                _context.Coordinator.Remove(Coordinator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

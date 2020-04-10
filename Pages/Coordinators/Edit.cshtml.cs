using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoordinatorWebpage.Data;
using CoordinatorWebpage.Models;

namespace CoordinatorWebpage.Pages.Coordinators
{
    public class EditModel : PageModel
    {
        private readonly CoordinatorWebpage.Data.CoordinatorContext _context;

        public EditModel(CoordinatorWebpage.Data.CoordinatorContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coordinator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordinatorExists(Coordinator.ID))
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

        private bool CoordinatorExists(int id)
        {
            return _context.Coordinator.Any(e => e.ID == id);
        }
    }
}

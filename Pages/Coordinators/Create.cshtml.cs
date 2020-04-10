using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoordinatorWebpage.Data;
using CoordinatorWebpage.Models;

namespace CoordinatorWebpage.Pages.Coordinators
{
    public class CreateModel : PageModel
    {
        private readonly CoordinatorWebpage.Data.CoordinatorContext _context;

        public CreateModel(CoordinatorWebpage.Data.CoordinatorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coordinator Coordinator { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coordinator.Add(Coordinator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

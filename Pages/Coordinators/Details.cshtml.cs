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
    public class DetailsModel : PageModel
    {
        private readonly CoordinatorWebpage.Data.CoordinatorContext _context;

        public DetailsModel(CoordinatorWebpage.Data.CoordinatorContext context)
        {
            _context = context;
        }

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
    }
}

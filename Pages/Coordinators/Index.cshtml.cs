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
    public class IndexModel : PageModel
    {
        private readonly CoordinatorWebpage.Data.CoordinatorContext _context;

        public IndexModel(CoordinatorWebpage.Data.CoordinatorContext context)
        {
            _context = context;
        }

        public IList<Coordinator> Coordinator { get;set; }

        public async Task OnGetAsync()
        {
            Coordinator = await _context.Coordinator.ToListAsync();
        }
    }
}

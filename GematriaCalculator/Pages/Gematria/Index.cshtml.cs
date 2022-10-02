using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GematriaCalculator.Data;
using GematriaCalculator.Models;

namespace GematriaCalculator.Pages.Gematria
{
    public class IndexModel : PageModel
    {
        private readonly GematriaCalculator.Data.StrongsDbContext _context;

        public IndexModel(GematriaCalculator.Data.StrongsDbContext context)
        {
            _context = context;
        }

        public IList<Models.Gematria> Gematrias { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Gematrias != null)
            {
                Gematrias = await _context.Gematrias.ToListAsync();
            }
        }
    }
}

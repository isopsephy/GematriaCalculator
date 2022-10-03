using GematriaCalculator.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GematriaCalculator.Pages.Hebrew
{
    public class IndexModel : PageModel
    {
        private readonly Data.StrongsDbContext _context;

        public IndexModel(Data.StrongsDbContext context)
        {
            _context = context;
        }

        public IList<HebrewGematria> HebrewGematrias { get; set; } = default!;

        public async Task OnGetAsync()
        {
            HebrewGematrias = await _context.Hebrews
                   .Select(x => new HebrewGematria(_context)
                   {
                       Xlit = x.Xlit,
                       Description = x.Description,
                       Lemma = x.Lemma,
                       Number = x.Number,
                       Pronounce = x.Pronounce
                   })
                   .ToListAsync();
        }
    }
}

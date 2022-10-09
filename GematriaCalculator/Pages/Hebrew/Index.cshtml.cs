using GematriaCalculator.Data;
using GematriaCalculator.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GematriaCalculator.Pages.Hebrew
{
    public class IndexModel : PageModel
    {
        public IList<HebrewGematria> HebrewGematrias { get; set; } = default!;

        public void OnGet()
        {
            if (ApplicationData.Hebrews != null && ApplicationData.Hebrews.Any())
            {
                HebrewGematrias = ApplicationData.Hebrews
                .Select(x => new HebrewGematria()
                {
                    Xlit = x.Xlit,
                    Description = x.Description,
                    Lemma = x.Lemma,
                    Number = x.Number,
                    Pronounce = x.Pronounce
                }).ToList();
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GematriaCalculator.Models
{
    public partial class Greek
    {
        [Key]
        public string? Number { get; set; }
        public string? Lemma { get; set; }
        public string? Xlit { get; set; }
        public string? Pronounce { get; set; }
        public string? Description { get; set; }
    }
}

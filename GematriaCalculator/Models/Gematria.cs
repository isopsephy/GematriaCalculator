using System.ComponentModel.DataAnnotations;

namespace GematriaCalculator.Models
{
    public partial class Gematria
    {
        [Key]
        public string Letter { get; set; } = null!;
        public long Standard { get; set; }
        public long Large { get; set; }
        public long Small { get; set; }
        public long Ordinal { get; set; }
        public string Name { get; set; } = null!;
        public string? Transliteration { get; set; }
    }
}

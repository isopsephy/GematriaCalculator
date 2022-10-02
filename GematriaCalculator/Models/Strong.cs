using System;
using System.Collections.Generic;

namespace GematriaCalculator.Models
{
    public partial class Strong
    {
        public string Number { get; set; } = null!;
        public string Lemma { get; set; } = null!;
        public string Xlit { get; set; } = null!;
        public string Pronounce { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

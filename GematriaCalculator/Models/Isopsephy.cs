using System;
using System.Collections.Generic;

namespace GematriaCalculator.Models
{
    public partial class Isopsephy
    {
        public string Letter { get; set; } = null!;
        public long Value { get; set; }
        public string Name { get; set; } = null!;
        public string? Transliteration { get; set; }
    }
}

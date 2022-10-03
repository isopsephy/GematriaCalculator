using GematriaCalculator.Data;
using System.ComponentModel;

namespace GematriaCalculator.Models
{
    public class HebrewGematria : Hebrew
    {
        StrongsDbContext _context;

        public HebrewGematria(StrongsDbContext context)
        {
            _context = context;
        }

        [DisplayName("Mispar Hechrachi")]
        public long Standard
        {
            get
            {
                long sum = 0;
                foreach (char letter in Lemma)
                {
                    Gematria gematria = _context.Gematrias.FirstOrDefault(x => x.Letter.FirstOrDefault() == letter);
                    if (gematria != null)
                        sum += gematria.Standard;
                }
                return sum;
            }
        }

        [DisplayName("Mispar Gadol")]
        public long Large
        {
            get
            {
                long sum = 0;
                foreach (char letter in Lemma)
                {
                    Gematria gematria = _context.Gematrias.FirstOrDefault(x => x.Letter.FirstOrDefault() == letter);
                    if (gematria != null)
                        sum += gematria.Large;
                }
                return sum;
            }
        }

        [DisplayName("Mispar Katan")]
        public long Small
        {
            get
            {
                long sum = 0;
                foreach (char letter in Lemma)
                {
                    Gematria gematria = _context.Gematrias.FirstOrDefault(x => x.Letter.FirstOrDefault() == letter);
                    if (gematria != null)
                        sum += gematria.Small;
                }
                return sum;
            }
        }

        [DisplayName("Mispar Siduri")]
        public long Ordinal
        {
            get
            {
                long sum = 0;
                foreach (char letter in Lemma)
                {
                    Gematria gematria = _context.Gematrias.FirstOrDefault(x => x.Letter.FirstOrDefault() == letter);
                    if (gematria != null)
                        sum += gematria.Ordinal;
                }
                return sum;
            }
        }

        //Atbash

        //Avgad

        //Albam

        //Mispar HaKadmi
        //Front

        //Mispar HaPerati
        //Square

        //Mispar Shemi
        //Name
    }
}

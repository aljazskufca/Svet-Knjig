using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace web.Models
{
    public class Avtor
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime Datum_rojstva { get; set; }
        public ICollection<Knjiga_avtor>? Knjige_avtorji { get; set; }

    }
}

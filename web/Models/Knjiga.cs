using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime Letnica_izdaje { get; set; }
        public string Zalozba { get; set; }
        public int Stevilo_strani { get; set; }
        public ICollection<Izposoja_nakup>? izposoje_nakupi { get; set; }
        public ICollection<Ocene_komentarji>? oceene_komentarji { get; set; }
        public ICollection<Knjiga_avtor>? knjige_avtorji { get; set; }
        public ICollection<Knjiga_zanr>? knjige_zanri { get; set; } 
    }
}

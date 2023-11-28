using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace web.Models
{
    public class Ocene_komentarji
    {
        public int Id { get; set; }
        public int Ocena { get; set; }
        public string Komentar { get; set; }
        public DateTime Datum_ocene { get; set; }
        public Knjiga knjiga { get; set; }
        public Uporabnik uporabnik { get; set; }
    }
}

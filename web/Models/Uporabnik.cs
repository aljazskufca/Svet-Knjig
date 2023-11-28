using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Uporabnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Uporabnisko_ime { get; set; }
        public string geslo { get; set; }
        public DateTime Datum_rojstva { get; set; }
        public string email { get; set; }
        public int status { get; set; } = 1;

        public ICollection<Ocene_komentarji>? ocene_komentarji { get; set; }
        public ICollection<Izposoja_nakup>? izposoje_nakupi { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Izposoja_nakup
    {
        public int Id { get; set; }
        public DateTime Datum_izposoje { get; set; }
        public DateTime Datum_vrnitve { get; set; }
        public double Cena { get; set; }
        public Knjiga knjiga { get; set; }
        public Uporabnik uporabnik { get; set; }
    }
}

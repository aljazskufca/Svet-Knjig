using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        public string Ime_zanra { get; set; }
        public ICollection<Knjiga_zanr> knjige_zanri { get; set; }
    }
}

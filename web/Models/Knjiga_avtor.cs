using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Knjiga_avtor
    {
        public int Id { get; set; }
        public List<Knjiga> Knjige  { get; set; }
        public List<Avtor> Avtorji { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Knjiga_zanr
    {
        public int Id { get; set; }
        public Knjiga knjiga { get; set; }
        public Zanr zanr { get; set;}
    }
}

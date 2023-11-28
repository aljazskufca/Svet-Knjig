using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web.Models
{
    public class Knjiga_avtor
    {
        public int Id { get; set; }
        public Knjiga knjiga { get; set; }
        public Avtor avtor { get; set; }
    }
}

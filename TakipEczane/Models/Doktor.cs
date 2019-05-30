using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakipEczane.Models
{
    public class Doktor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Adısoyadı { get; set; }
        public int Diplomano { get; set; }
        public string Brans { get; set; }
        public string Kurum { get; set; }
    }
}

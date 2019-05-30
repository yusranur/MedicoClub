using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakipEczane.Models
{
    public class Raf
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Rafadı { get; set; }

        public List<Ilac> Ilaclar { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakipEczane.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Formadı { get; set; }
        public List<Ilac> Ilaclar { get; set; }
    }
}

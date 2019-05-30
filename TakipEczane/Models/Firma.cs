using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TakipEczane.Models
{
    public class Firma
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firmaadı { get; set; }
        
        public virtual IList<Ilac> Ilacs { get; set; }
    }
}

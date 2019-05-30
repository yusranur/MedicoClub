using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TakipEczane.Models
{
    public class Ilac
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Ilacadı { get; set; }
        public string Barkod { get; set; }
        public int Fiyat { get; set; }
        public int Miktar { get; set; }

        public int FirmaId { get; set; }
        public virtual Firma Firma { get; set; }

        public int RafId { get; set; }
        public Raf Raf { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }

        public int EtkiId { get; set; }
        public Etki Etki { get; set; }

        public int EtkenmaddeId { get; set; }
        public Etkenmadde Etkenmadde { get; set; }
    }
}

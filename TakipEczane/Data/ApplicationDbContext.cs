using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TakipEczane.Models;

namespace TakipEczane.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TakipEczane.Models.Doktor> Doktor { get; set; }
        public DbSet<TakipEczane.Models.Etkenmadde> Etkenmadde { get; set; }
        public DbSet<TakipEczane.Models.Etki> Etki { get; set; }
        public DbSet<TakipEczane.Models.Firma> Firma { get; set; }
        public DbSet<TakipEczane.Models.Form> Form { get; set; }
        public DbSet<TakipEczane.Models.Ilac> Ilac { get; set; }
        public DbSet<TakipEczane.Models.Raf> Raf { get; set; }
        public DbSet<TakipEczane.Models.Yanetki> Yanetki { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.EF
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DbSet<Nota> Notas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser<int>>()
                   .ToTable("Usuarios");

            builder.Entity<IdentityRole<int>>()
                   .ToTable("Roles");

            builder.Entity<Nota>()
                   .Property(n => n.Titulo)
                   .HasMaxLength(256);

            builder.Entity<Nota>()
                   .Property(n => n.ContenidoHtml)
                   .IsRequired();

            builder.Entity<Nota>()
                   .Property(n => n.ContenidoSoloTexto)
                   .IsRequired();

            builder.Entity<Nota>()
                   .HasOne<IdentityUser<int>>()
                   .WithMany()
                   .HasForeignKey(n => n.UsuarioId);
                   
                   
        }
    }
}

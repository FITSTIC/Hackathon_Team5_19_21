using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Team5_19_21.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Provincia> Province { get; set; }
        public DbSet<Citta> Citta { get; set; }
        public DbSet<Amministratore> Amministratori { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Esame> Esami { get; set; }
        public DbSet<Modulo> Moduli { get; set; }
        public DbSet<PersonaFitstic> PersonaleFitstic { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<StudenteIscritto> StudentiIscritti { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Citta>()
        .HasOne(p => p.Provincia)
        .WithMany(b => b.Citta)
        .HasForeignKey(p => p.IdProvincia)
        .HasConstraintName("ForeignKey_Provincia_Citta");

            modelBuilder.Entity<PersonaFitstic>()
            .HasOne(p => p.Amministratore)
            .WithMany(b => b.PersonaleFistic)
            .HasForeignKey(p => p.IdAmministratore)
            .HasConstraintName("ForeignKey_Amministratore_PersonaFitstic");

            modelBuilder.Entity<Corso>()
            .HasOne(p => p.Citta)
            .WithMany(b => b.Corsi)
            .HasForeignKey(p => p.IdCitta)
            .HasConstraintName("ForeignKey_Corso_Citta");

            modelBuilder.Entity<Corso>()
            .HasOne(p => p.Organizzatore)
            .WithMany(b => b.CorsiOrganizzatore)
            .HasForeignKey(p => p.IdOrganizzatore)
            .HasConstraintName("ForeignKey_Corso_Organizzatore");

            modelBuilder.Entity<Studente>()
            .HasOne(p => p.Citta)
            .WithMany(b => b.Studenti)
            .HasForeignKey(p => p.IdCitta)
            .HasConstraintName("ForeignKey_Studente_Citta");

            modelBuilder.Entity<StudenteIscritto>()
            .HasOne(p => p.Studente)
            .WithMany(b => b.StudentiIscritti)
            .HasForeignKey(p => p.IdStudente)
            .HasConstraintName("ForeignKey_Studente_StudenteIscritto");

            modelBuilder.Entity<StudenteIscritto>()
            .HasOne(p => p.Corso)
            .WithMany(b => b.StudentiIscritti)
            .HasForeignKey(p => p.IdCorso)
            .HasConstraintName("ForeignKey_Corso_StudenteIscritto");

            modelBuilder.Entity<Esame>()
            .HasOne(p => p.StudenteIscritto)
            .WithMany(b => b.Esami)
            .HasForeignKey(p => p.IdStudenteIscritto)
            .HasConstraintName("ForeignKey_Esame_StudenteIscritto");


            modelBuilder.Entity<Esame>()
            .HasOne(p => p.Modulo)
            .WithMany(b => b.Esami)
            .HasForeignKey(p => p.IdModulo)
            .HasConstraintName("ForeignKey_Modulo_Esame");

            modelBuilder.Entity<Modulo>()
            .HasOne(p => p.Corso)
            .WithMany(b => b.Moduli)
            .HasForeignKey(p => p.IdCorso)
            .HasConstraintName("ForeignKey_Modulo_Corso");


            modelBuilder.Entity<Modulo>()
            .HasOne(p => p.Docente)
            .WithMany(b => b.ModuliDocente)
            .HasForeignKey(p => p.IdDocente)
            .HasConstraintName("ForeignKey_Modulo_Docente");

            modelBuilder.Entity<Modulo>()
            .HasOne(p => p.Tutor)
            .WithMany(b => b.ModuliTutor)
            .HasForeignKey(p => p.IdTutor)
            .HasConstraintName("ForeignKey_Modulo_Tutor");

            modelBuilder.Entity<Amministratore>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<PersonaFitstic>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Esame>().HasIndex("IdStudenteIscritto", "IdModulo").IsUnique();
        }
    }
}

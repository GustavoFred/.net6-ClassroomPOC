using Domain.Entities;
using Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<SalaAula> SalaAula { get; set; }
        public DbSet<SalaAulaAluno> SalaAulaAluno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // In order to be able to create migrations and update database:
            if (!options.IsConfigured)
            {
                options.UseSqlServer("server=(localdb)\\Local;database=ClassroomDB;Trusted_Connection=true");
            }
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;

            // Config das Tabelas via EF

            modelBuilder.ApplyConfiguration(new AlunoConfig());
            modelBuilder.ApplyConfiguration(new ProfessorConfig());
            modelBuilder.ApplyConfiguration(new SalaConfig());

        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {}
      
        public DbSet <Aluno> Alunos{ get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplina { get; set; }
       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoID, AD.DisciplinaId });
        }
    }
}

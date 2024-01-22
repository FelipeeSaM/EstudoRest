using Microsoft.EntityFrameworkCore;

namespace RestAPI.Model.restDbContext {
    public class rest_api_db_context : DbContext {
        public DbSet<Pessoa> pessoas { get; set; }

        public rest_api_db_context(DbContextOptions<rest_api_db_context> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pessoa>().HasData(
                new Pessoa { Id = 1, PrimeiroNome = "João", UltimoNome = "Silva", Endereco = "Rua A", Genero = "Masculino" },
                new Pessoa { Id = 2, PrimeiroNome = "Maria", UltimoNome = "Santos", Endereco = "Rua B", Genero = "Feminino" },
                new Pessoa { Id = 3, PrimeiroNome = "Pedro", UltimoNome = "Oliveira", Endereco = "Rua C", Genero = "Masculino" },
                new Pessoa { Id = 4, PrimeiroNome = "Ana", UltimoNome = "Costa", Endereco = "Rua D", Genero = "Feminino" },
                new Pessoa { Id = 5, PrimeiroNome = "Lucas", UltimoNome = "Pereira", Endereco = "Rua E", Genero = "Masculino" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TF0LNRF\\SQLEXPRESS2019;Initial Catalog=rest_api_estudo;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

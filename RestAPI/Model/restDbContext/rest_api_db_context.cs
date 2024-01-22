using Microsoft.EntityFrameworkCore;

namespace RestAPI.Model.restDbContext {
    public class rest_api_db_context : DbContext {
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Livros> livros { get; set; }

        public rest_api_db_context(DbContextOptions<rest_api_db_context> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pessoa>().HasData(
            new Pessoa { Id = 1, PrimeiroNome = "João", UltimoNome = "Silva", Endereco = "Rua A", Genero = "Masculino" },
            new Pessoa { Id = 2, PrimeiroNome = "Maria", UltimoNome = "Santos", Endereco = "Rua B", Genero = "Feminino" },
            new Pessoa { Id = 3, PrimeiroNome = "Pedro", UltimoNome = "Oliveira", Endereco = "Rua C", Genero = "Masculino" },
            new Pessoa { Id = 4, PrimeiroNome = "Ana", UltimoNome = "Costa", Endereco = "Rua D", Genero = "Feminino" },
            new Pessoa { Id = 5, PrimeiroNome = "Lucas", UltimoNome = "Pereira", Endereco = "Rua E", Genero = "Masculino" }
            );

            modelBuilder.Entity<Livros>().HasData(
            new Livros { Id = 1, Nome = "Livro 1", Autor = "Autor 1", Preco = 18.99, Estoque = true },
            new Livros { Id = 2, Nome = "Livro 2", Autor = "Autor 2", Preco = 28.99, Estoque = false },
            new Livros { Id = 3, Nome = "Livro 3", Autor = "Autor 3", Preco = 38.99, Estoque = true },
            new Livros { Id = 4, Nome = "Livro 4", Autor = "Autor 4", Preco = 48.99, Estoque = false },
            new Livros { Id = 5, Nome = "Livro 5", Autor = "Autor 5", Preco = 58.99, Estoque = true },
            new Livros { Id = 6, Nome = "Livro 6", Autor = "Autor 6", Preco = 68.99, Estoque = false }
);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TF0LNRF\\SQLEXPRESS2019;Initial Catalog=rest_api_estudo;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

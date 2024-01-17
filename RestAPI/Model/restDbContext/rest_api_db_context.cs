using Microsoft.EntityFrameworkCore;

namespace RestAPI.Model.restDbContext {
    public class rest_api_db_context : DbContext {
        public DbSet<Pessoa> pessoas { get; set; }

        public rest_api_db_context(DbContextOptions<rest_api_db_context> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TF0LNRF\\SQLEXPRESS2019;Initial Catalog=rest_api_estudo;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

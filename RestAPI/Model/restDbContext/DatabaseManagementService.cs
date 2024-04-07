using Microsoft.EntityFrameworkCore;

namespace RestAPI.Model.restDbContext {
    public static class DatabaseManagementService {

        public static void MigrationInitializer(this IApplicationBuilder app) {
            // 1 - método que cria, caso não exista, o banco e as tabelas
            using(var serviceScope = app.ApplicationServices.CreateScope()) {
                var serviceDb = serviceScope.ServiceProvider.GetService<rest_api_db_context>();

                serviceDb.Database.Migrate();
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;

namespace RestAPI.Model.restDbContext {
    public static class DatabaseManagementService {

        public static void MigrationInitializer(this IApplicationBuilder app) {
            using(var servviceScope = app.ApplicationServices.CreateScope()) {
                var serviceDb = servviceScope.ServiceProvider.GetService<rest_api_db_context>();

                serviceDb.Database.Migrate();
            }
        }

    }
}

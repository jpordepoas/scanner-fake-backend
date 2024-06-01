using scannerFakeBackend.Repositories;
using scannerFakeBackend.Services;

namespace scannerFakeBackend;

public static class CustomBootstrap
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var connectionString = configuration.GetConnectionString("MongoDB");
        var dbName = configuration["MongoDB:DatabaseName"];

        builder.Services.AddSingleton(new MongoDBService(connectionString?? string.Empty, dbName?? string.Empty));
        builder.Services.AddScoped<IWorkflowSettingsRepository, WorkflowSettingsRepository>();
        return builder;
    }
}
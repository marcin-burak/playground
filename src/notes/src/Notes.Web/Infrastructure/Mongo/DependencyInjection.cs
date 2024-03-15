using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notes.Web.Infrastructure.Mongo.Documents;

namespace Notes.Web.Infrastructure.Mongo;

internal static class DependencyInjection
{
    //TODO: Verify dependency injection scopes
    public static IServiceCollection AddMongo(this IServiceCollection services) => services
        .AddOptionsWithValidateOnStart<MongoOptions, MongoOptionsValidation>().BindConfiguration("Mongo").Services
        .AddScoped<IMongoClient>(serviceProvider =>
        {
            var mongoOptions = serviceProvider.GetRequiredService<IOptions<MongoOptions>>();
            var mongoClient = new MongoClient(mongoOptions.Value.Connection);

            return mongoClient;
        })
        .AddScoped(serviceProvider =>
        {
            var mongoOptions = serviceProvider.GetRequiredService<IOptions<MongoOptions>>();
            var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
            var mongoDatabase = mongoClient.GetDatabase(mongoOptions.Value.Database);

            return mongoDatabase;
        })
        .AddScoped(serviceProvider =>
        {
            var mongoDatabase = serviceProvider.GetRequiredService<IMongoDatabase>();
            var mongoDatabaseNotesCollection = mongoDatabase.GetCollection<Note>(nameof(Note));

            return mongoDatabaseNotesCollection;
        });
}

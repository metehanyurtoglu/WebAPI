using Application;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddApplication();

            var mongoDBSettings = configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton(a =>
            {
                var mongoClient = new MongoClient(mongoDBSettings.ConnectionString);

                return mongoClient.GetDatabase(mongoDBSettings.DatabaseName);
            });

            services.AddScoped<IRepository<Country>>(a =>
            {
                var database = a.GetService<IMongoDatabase>();

                return new Repository<Country>(database, "Country");
            });

            services.AddScoped<IRepository<City>>(a =>
            {
                var database = a.GetService<IMongoDatabase>();

                return new Repository<City>(database, "City");
            });

            return services;
        }
    }
}

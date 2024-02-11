using Application.Interfaces;
using Domain.Entities;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Linq.Expressions;

namespace Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _collection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException (nameof(entity));
            }

            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, entity.Id);

            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(string id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);

            await _collection.DeleteOneAsync(filter);
        }
    }
}

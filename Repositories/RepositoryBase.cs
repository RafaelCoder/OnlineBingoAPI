using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        private const string _databaseName = "bingo";
        private readonly string _collectionName;
        protected readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;
        protected readonly IMongoCollection<T> _collection;

        public RepositoryBase(IMongoClient mongoClient)
        {
            _collectionName = typeof(T).Name.ToLower();
            IMongoDatabase db = mongoClient.GetDatabase(_databaseName);
            _collection = db.GetCollection<T>(_collectionName);
        }

        public async Task Add(T model)
        {
            await _collection.InsertOneAsync(model);
        }

        public abstract Task Update(T model);

        public abstract Task Delete(T model);

        public abstract Task<T> Get(Guid id);

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }
    }
}

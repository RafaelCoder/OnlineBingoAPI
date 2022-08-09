using MongoDB.Driver;
using OnlineBingoAPI.Models;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override async Task Delete(User model)
        {
            var filter = _filterBuilder.Eq(usr => usr.ReferenceId, model.ReferenceId);
            await _collection.DeleteOneAsync(filter);
        }

        public override async Task<User> Get(Guid id)
        {
            var filter = _filterBuilder.Eq(usr => usr.ReferenceId, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public override async Task Update(User model)
        {
            var filter = _filterBuilder.Eq(usr => usr.ReferenceId, model.ReferenceId);
            await _collection.ReplaceOneAsync(filter, model);
        }
    }
}

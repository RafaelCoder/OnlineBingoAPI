using MongoDB.Driver;
using OnlineBingoAPI.Models;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Repositories
{
    public class MatchRepository : RepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public override async Task Delete(Guid id)
        {
            var filter = _filterBuilder.Eq(usr => usr.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public override async Task<Match> Get(Guid id)
        {
            var filter = _filterBuilder.Eq(usr => usr.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public override async Task Update(Match model)
        {
            var filter = _filterBuilder.Eq(usr => usr.Id, model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }
    }
}

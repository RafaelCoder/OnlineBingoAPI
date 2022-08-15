using OnlineBingoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public interface IMatchService
    {
        public Task<MatchReadContract> Create(MatchCreateContract newMatch);
        public Task<MatchReadContract> Get(Guid id);
        public Task<IEnumerable<MatchReadContract>> GetAll();
        public Task Update(MatchUpdateContract match);
        public Task Delete(Guid id);
    }
}

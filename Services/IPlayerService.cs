using OnlineBingoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Services
{
    public interface IPlayerService
    {
        public Task<PlayerReadContract> NewPlayer(Guid MatchId, PlayerCreateContract newPlayer);
        public Task<PlayerReadContract> Get(Guid MatchId, Guid id);
        public Task<IEnumerable<PlayerReadContract>> GetAll(Guid MatchId);
        public Task Update(Guid MatchId, PlayerUpdateContract player);
        public Task Delete(Guid MatchId, Guid id);
    }
}

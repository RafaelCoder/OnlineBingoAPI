using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBingoAPI.CustomException;
using Mapster;
using OnlineBingoAPI.Models;
using System.Linq;

namespace OnlineBingoAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IUserRepository _userRepository;

        public PlayerService(IMatchRepository matchRepository, IUserRepository userRepository)
        {
            _matchRepository = matchRepository;
            _userRepository = userRepository;
        }

        public async Task Delete(Guid MatchId, Guid id)
        {
            var match = await _matchRepository.Get(MatchId);
            if (match == null)
                throw new NotFoundException("Match not found");

            var player = match.Players.Where(p => p.UserId == id).FirstOrDefault();
            if (player == null)
                throw new NotFoundException("Player not found in this match");
            
            match.Players.Remove(player);
            await _matchRepository.Update(match);
        }

        public async Task<PlayerReadContract> Get(Guid MatchId, Guid id)
        {
            var match = await _matchRepository.Get(MatchId);
            if (match == null)
                throw new NotFoundException("Match not found");

            var player = match.Players.Where(p => p.UserId == id).FirstOrDefault();
            if (player == null)
                throw new NotFoundException("Player not found in this match");
            return player.Adapt<PlayerReadContract>();
        }

        public async Task<IEnumerable<PlayerReadContract>> GetAll(Guid MatchId)
        {
            var match = await _matchRepository.Get(MatchId);
            if (match == null)
                throw new NotFoundException("Match not found");

            var players = match.Players.Select(p => p.Adapt<PlayerReadContract>());
            return players;
        }

        public async Task<PlayerReadContract> NewPlayer(Guid MatchId, PlayerCreateContract newPlayer)
        {
            var match = await _matchRepository.Get(MatchId);
            if (match == null)
                throw new NotFoundException("Match not found");

            if (match.Players.Any(p => p.UserId == newPlayer.UserId))
                throw new BusinessRuleException("This player already is in this match");

            var player = newPlayer.Adapt<Player>();
            match.Players.Add(player);
            await _matchRepository.Update(match);
            return player.Adapt<PlayerReadContract>();
        }

        public async Task Update(Guid MatchId, PlayerUpdateContract player)
        {
            var match = await _matchRepository.Get(MatchId);
            if (match == null)
                throw new NotFoundException("Match not found");

            if (match.Players.Any(p => p.UserId != player.UserId))
                throw new BusinessRuleException("Player not found in this match");

            var newPlayer = player.Adapt<Player>();
            match.Players.Where(p => p.UserId == player.UserId).ToList().ForEach(p => p = newPlayer);
            await _matchRepository.Update(match);
        }
    }
}

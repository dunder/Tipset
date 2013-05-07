using System;
using System.Collections.Generic;
using System.Linq;
using Tipset.Common;

namespace Tipset.Domain
{
    public class RoundRobinPlayerAllocator : IPlayerAllocator
    {
        public IList<Round> Allocate(IList<Player> players, IList<Round> rounds)
        {
            Guard.ArgumentIsNotNull(players, "players");
            Guard.ArgumentIsNotNull(rounds, "rounds");

            var numberOfPlayers = players.Count;
            if (numberOfPlayers == 0) return rounds;

            var surplusCount = rounds.Count % numberOfPlayers;

            for (var i = 0; i < rounds.Count; i++ )
            {
                var playerOffset = i % numberOfPlayers;
                var lastRound = i + 1 == rounds.Count;
                var numberOfPlayersToAssign = surplusCount > 0 && lastRound ? surplusCount : 1;
                var playersToAssign = players.Skip(playerOffset).Take(numberOfPlayersToAssign);
                
                rounds[i].AssignedPlayerIds = playersToAssign.Select(player => player.Id).ToList();
            }

            return rounds;
        }
    }
}

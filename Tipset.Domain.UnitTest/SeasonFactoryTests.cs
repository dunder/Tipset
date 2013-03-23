using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tipset.Domain.UnitTest
{
    [TestClass]
    public class SeasonFactoryTests
    {
        [TestMethod]
        public void SeasonFactoryCreatesSeasonWithRoundsAndAssignsPlayersInRoundARobinFashion()
        {
            var factory = new SeasonFactory();
            var start = new DateTime(2012, 08, 18);
            var end = new DateTime(2013, 5, 18);
            var players = new List<Player>
                              {
                                  new Player { Id = "1" },
                                  new Player { Id = "2" },
                                  new Player { Id = "3" },
                                  new Player { Id = "4" },
                              };
            var season = factory.Create("TestSeason", start, end, players);


            Assert.AreEqual(40, season.Rounds.Count);

            Assert.AreEqual(start, season.Rounds.First().Date);
            Assert.AreEqual(end, season.Rounds.Last().Date);

            for (var i = 0; i < season.Rounds.Count; i++)
            {
                Assert.AreEqual(end, season.Rounds.Last().Date);
                Assert.AreEqual(1, season.Rounds[i].AssignedPlayerIds.Count);
                var expectedPlayerTurn = i % players.Count;

                Assert.AreEqual(players[expectedPlayerTurn].Id, season.Rounds[i].AssignedPlayerIds.Single(),
                    "Round {0}", i);

            }
        }
    }
}

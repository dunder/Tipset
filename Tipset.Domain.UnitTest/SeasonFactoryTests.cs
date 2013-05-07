using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace Tipset.Domain.UnitTest
{
    [TestFixture]
    public class SeasonFactoryTests
    {
        private const string SeasonName = "name";

        private SeasonFactory factory;
        private List<Player> players;

        [TestFixtureSetUp]
        public void SetUp()
        {
            factory = new SeasonFactory();
            players = new List<Player>
                      {
                          new Player {Id = "1"},
                          new Player {Id = "2"},
                          new Player {Id = "3"},
                          new Player {Id = "4"},
                      };
        }

        [Test]
        public void SeasonFactoryCreatesSeason()
        {
            var start = new DateTime(2013, 4, 27);
            var end = new DateTime(2013, 4, 4);

            var season = factory.Create(SeasonName, start, end, players);

            Assert.That(season, Is.Not.Null);
            Assert.That(season.Name, Is.EqualTo(SeasonName));
            Assert.That(season.Rounds, Is.Not.Null);
        }

        [Test]
        public void SeasonFactoryDistributeRounds()
        {
            var start = new DateTime(2013, 4, 27);
            var end = new DateTime(2013, 5, 18);

            var distributedRounds = new List<Round>
                                    {
                                        new Round(),
                                        new Round(),
                                        new Round(),
                                    };

            var roundDistribution = new Mock<IRoundDistribution>();
            roundDistribution.Setup(r => r.Distribute(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                             .Returns(distributedRounds);

            var factory = new SeasonFactory(roundDistribution.Object, new Mock<IPlayerAllocator>().Object);

            var season = factory.CreateWithDistribution(SeasonName, start, end, players);

            roundDistribution.Verify(x => x.Distribute(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once());
            Assert.That(season.Rounds, Is.EqualTo(distributedRounds));
        }

        [Test]
        public void SeasonFactoryDistributePlayers()
        {
            var start = new DateTime();
            var end = new DateTime();

            var distributedRounds = new List<Round>
                                    {
                                        new Round(),
                                        new Round(),
                                        new Round(),
                                    };

            var roundDistribution = new Mock<IRoundDistribution>();
            roundDistribution.Setup(r => r.Distribute(It.Is<DateTime>(x => x.Equals(start)), It.Is<DateTime>(x => x.Equals(end))))
                             .Returns(distributedRounds);


            var playerDistribution = new Mock<IPlayerAllocator>();
            playerDistribution.Setup(p => p.Allocate(It.IsAny<IList<Player>>(), It.IsAny<IList<Round>>()))
                              .Callback(() =>
                                            {
                                                distributedRounds[0].AssignedPlayerIds = new List<string>();
                                                distributedRounds[1].AssignedPlayerIds = new List<string>();
                                                distributedRounds[2].AssignedPlayerIds = new List<string>();
                                            })
                              .Returns(distributedRounds);

            var factory = new SeasonFactory(roundDistribution.Object, playerDistribution.Object);

            var season = factory.CreateWithDistribution(SeasonName, start, end, players);

            Assert.That(season.Rounds.All(round => round.AssignedPlayerIds != null));
        }


        [Test]
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

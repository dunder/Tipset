using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Tipset.Domain.UnitTest
{

    [TestFixture]
    public class RoundRobinPlayerAllocatorTests
    {
        private RoundRobinPlayerAllocator allocator;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            allocator = new RoundRobinPlayerAllocator();
        }

        [Test]
        public void PlayersArgumentNullThrows()
        {
            var exception = Assert.Throws<ArgumentException>(() => allocator.Allocate(null, new List<Round>()));
            Assert.That(exception.Message, Is.EqualTo("players"));
        }

        [Test]
        public void RoundsArgumentNullShouldThrow()
        {
            var exception = Assert.Throws<ArgumentException>(() => allocator.Allocate(new List<Player>(), null));
            Assert.That(exception.Message, Is.EqualTo("rounds"));
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ShouldAllocatePlayersInARoundRobinFashion()
        {
            var players = new List<Player>
                      {
                          new Player {Id = "1"},
                          new Player {Id = "2"},
                          new Player {Id = "3"}
                      };

            IList<Round> rounds = new List<Round>
                                  {
                                      new Round {Date = new DateTime(2013,5,1)},
                                      new Round {Date = new DateTime(2013,5,2)},
                                      new Round {Date = new DateTime(2013,5,3)},
                                      new Round {Date = new DateTime(2013,5,4)},
                                      new Round {Date = new DateTime(2013,5,5)},
                                      new Round {Date = new DateTime(2013,5,6)},
                                  };

            rounds = allocator.Allocate(players, rounds);

            Approvals.VerifyAll(rounds, "round");
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ShouldAllocatePlayersInARoundRobinFashionAndAssignSurplusToLastRound()
        {
            var players = new List<Player>
                      {
                          new Player {Id = "1"},
                          new Player {Id = "2"},
                          new Player {Id = "3"}
                      };

            IList<Round> rounds = new List<Round>
                                  {
                                      new Round {Date = new DateTime(2013,5,1)},
                                      new Round {Date = new DateTime(2013,5,2)},
                                      new Round {Date = new DateTime(2013,5,3)},
                                      new Round {Date = new DateTime(2013,5,4)},
                                      new Round {Date = new DateTime(2013,5,5)},
                                  };

            rounds = allocator.Allocate(players, rounds);

            Approvals.VerifyAll(rounds, "round");
        }
    }
}

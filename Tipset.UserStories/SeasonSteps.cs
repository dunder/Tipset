using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client;
using Raven.Client.Linq;
using TechTalk.SpecFlow;
using System;
using Tipset.Domain;

namespace Tipset.UserStories
{
    [Binding]
    public class SeasonSteps
    {
        [Given(@"(\d*) players")]
        public void GivenPlayers(int numberOfPlayers)
        {
            var players = new List<Player>
                          {
                              new Player {Name = "player1"},
                              new Player {Name = "player2"},
                              new Player {Name = "player3"},
                              new Player {Name = "player4"}
                          };

           ScenarioContext.Current.Set(players);
        }

        [When(@"I create a new season starting at (\d{4}-\d{2}-\d{2}) and ending at (\d{4}-\d{2}-\d{2})")]
        public void WhenICreateANewSeasonStartingAtAndEndingAtWithPlayers(DateTime start, DateTime end)
        {
            var seasonFactory = new SeasonFactory();
            var players = ScenarioContext.Current.Get<List<Player>>();
            var season = seasonFactory.Create("season1", start, end, players);

            ScenarioContext.Current.Set(start, "seasonStart");
            ScenarioContext.Current.Set(end, "seasonEnd");
            ScenarioContext.Current.Set(season);
        }

        [Then(@"the created season should have (\d+) rounds")]
        public void ThenTheCreatedSeasonShouldHaveTheFollowingRounds(int expectedNumberOfRounds)
        {
            var season = ScenarioContext.Current.Get<Season>();

            Assert.AreEqual(expectedNumberOfRounds, season.Rounds.Count);
        }

        [Then(@"there should be one round for every saturday between the start and end date")]
        public void ThenThereShouldBeOneRoundForEverySaturdayBetweenTheStartAndEndDate()
        {
            // TODO: ersätta hela det här krångliga med approval test?

            var season = ScenarioContext.Current.Get<Season>();
            var startDate = ScenarioContext.Current.Get<DateTime>("seasonStart");
            var endDate = ScenarioContext.Current.Get<DateTime>("seasonEnd");

            const DayOfWeek expectedDayOfWeek = DayOfWeek.Saturday;

            Assert.AreEqual(expectedDayOfWeek, startDate.DayOfWeek, "Start date should represent a {0} but was a {1}", expectedDayOfWeek, startDate.DayOfWeek);
            Assert.AreEqual(expectedDayOfWeek, endDate.DayOfWeek, "End date should represent a {0} but was a {1}", expectedDayOfWeek, endDate.DayOfWeek);
            Assert.IsTrue(startDate < endDate, "Given startDate {0} should be before endDate ({1})", startDate, endDate);

            Assert.IsNotNull(season.Rounds, "Failed to create rounds for season");
            Assert.AreEqual(startDate, season.Rounds.First().Date);
            Assert.AreEqual(endDate, season.Rounds.Last().Date);

            Assert.IsTrue(season.Rounds.All(round => round.Date.DayOfWeek == DayOfWeek.Monday),
                "All round dates should represent a {0} but was: {1}",
                expectedDayOfWeek,
                string.Join(",", season.Rounds.Select(round => round.Date.DayOfWeek)));

            var roundDate = startDate;
            foreach (var round in season.Rounds)
            {

            }


        }
    }
}

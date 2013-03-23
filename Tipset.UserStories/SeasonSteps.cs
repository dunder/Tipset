using TechTalk.SpecFlow;
using System;

namespace Tipset.UserStories
{
    [Binding]
    public class SeasonSteps
    {
        [When(@"I create a new season starting at (\d{4}-\d{2}-\d{2}) and ending at (\d{4}-\d{2}-\d{2}) with (\d+) players")]
        public void WhenICreateANewSeasonStartingAtAndEndingAtWithPlayers(DateTime start, DateTime end, int numberOfPlayers)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the created season should have the following rounds")]
        public void ThenTheCreatedSeasonShouldHaveTheFollowingRounds(Table table)
        {
            foreach (var row in table.Rows)
            {

            }
        }
    }
}

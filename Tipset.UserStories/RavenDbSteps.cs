using Raven.Client.Embedded;
using TechTalk.SpecFlow;

namespace Tipset.UserStories
{
    [Binding]
    public class RavenDbSteps
    {
        public const string RavenDbSession = "ravendb";

        [BeforeScenario("ravendb")]
        public static void InsertNewRavenDbSessionInScenarioContext()
        {
            var store = new EmbeddableDocumentStore
                        {
                            RunInMemory = true
                        };
            store.Initialize();

            ScenarioContext.Current[RavenDbSession] = store.OpenSession();
        }
    }
}

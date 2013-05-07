using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tipset.Domain.UnitTest
{
    [TestFixture]
    public class WeeklyDistributionTests
    {
        [Test]
        public void ShouldThrowIfEndIsEqualToStart()
        {
            var weeklyDistribution = new WeeklyDistribution(DayOfWeek.Saturday);

            var start = new DateTime(2000, 1, 1);
            var end = start;

            Assert.Throws<ArgumentException>(() => weeklyDistribution.Distribute(start, end), "Should throw ArgumentException if end is equal to start");
        }

        [Test]
        public void ShouldThrowIfEndIsBeforeStart()
        {
            var weeklyDistribution = new WeeklyDistribution(DayOfWeek.Saturday);

            var start = new DateTime(2000, 1, 1);
            var end = start.AddDays(-1);

            Assert.Throws<ArgumentException>(() => weeklyDistribution.Distribute(start, end), "Should throw ArgumentException if end is before start");
        }

        [Test]
        public void ShouldReturnDistributionResult()
        {
            var weeklyDistribution = new WeeklyDistribution(DayOfWeek.Monday);

            var start = new DateTime(2000, 1, 1);
            var end = start.AddDays(7*2);
            var distribution = weeklyDistribution.Distribute(start, end);

            Assert.That(distribution, Is.Not.Null, "Distribution with valid arguments should not return null");
            Assert.That(distribution, Is.Not.Empty, "Distribution with valid arguments should not return an empty result");
        }

        [Test]
        public void ShouldCreateOneRoundPerDayOfWeekBetweenStartAndEnd()
        {
            const DayOfWeek specifiedDayOfWeek = DayOfWeek.Saturday;

            var weeklyDistribution = new WeeklyDistribution(specifiedDayOfWeek);

            var start = new DateTime(2013,4,27);
            var end = new DateTime(2013,5,12);
            var distribution = weeklyDistribution.Distribute(start, end);

            Assert.That(distribution.Count, Is.EqualTo((end - start).Days / 7 + 1), 
                "Number of rounds should equal number of times a {0} occurs between start and end (both inclusive)", weeklyDistribution.DayOfWeek);

            Assert.That(distribution.All(round => round.Date.DayOfWeek == specifiedDayOfWeek));

            AssertOneWeekBetweenAllRoundsInDistribution(distribution);
        }

        private static void AssertOneWeekBetweenAllRoundsInDistribution(IList<Round> distribution)
        {
            var previousDate = distribution.First().Date;
            for (var i = 1; i < distribution.Count; i++)
            {
                var date = distribution[i].Date;
                Assert.That((date - previousDate).TotalDays / 7, Is.EqualTo(1));
                previousDate = date;
            }
        }
    }
}

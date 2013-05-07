using System;
using System.Collections.Generic;
using Tipset.Common;

namespace Tipset.Domain
{
    public class WeeklyDistribution : IRoundDistribution
    {
        public WeeklyDistribution(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }

        public DayOfWeek DayOfWeek { get; private set; }

        public IList<Round> Distribute(DateTime start, DateTime end)
        {
            Guard.ArgumentsCondition(() => end > start, "end must be after start");

            var roundDate = start;

            const int daysInWeek = 7;

            if (start.DayOfWeek != DayOfWeek)
            {
                var daysUntilNext = ((int)DayOfWeek - (int)start.DayOfWeek + daysInWeek) % daysInWeek;
                roundDate = start.AddDays(daysUntilNext);
            }

            var rounds = new List<Round>();

            while (roundDate <= end)
            {
                rounds.Add(new Round { Date = roundDate });
                roundDate = roundDate.AddDays(daysInWeek);
            }

            return rounds;
        }
    }
}
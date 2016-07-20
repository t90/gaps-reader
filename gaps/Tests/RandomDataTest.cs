using System;
using System.Collections.Generic;
using System.Linq;
using libGaps;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests
{
    public class RandomDataTest
    {
        private List<DateInterval> _dateIntervals;
        private IEnumerable<DateInterval> _result;

        public RandomDataTest()
        {
            var random = new Random((int)(DateTime.Now - DateTime.Parse("01/01/1982")).TotalSeconds);

            var numberOfDateIntervals = random.Next(0, 50);

            _dateIntervals = new List<DateInterval>(numberOfDateIntervals);

            while (numberOfDateIntervals-- > 0)
            {
                var startDate = new DateTime(random.Next(1930, 2016), random.Next(1, 12), random.Next(1, 28));
                _dateIntervals.Add(new DateInterval()
                {
                    StartDate = startDate,
                    EndDate = startDate.AddDays(random.Next(0,1000))
                });
            }
            _result = (new GapsReader(_dateIntervals)).Read();
        }

        [Test]
        public void It_should_return_gaps_where_no_input_date_interval_are()
        {

            foreach (var gap in _result)
            {
                var endedAfterGapStarted = _dateIntervals.Where(di => di.EndDate > gap.StartDate.AddHours(1));
                var failedDataIntervals = endedAfterGapStarted.Where(di => di.StartDate < gap.StartDate.AddHours(1)).ToArray();
                Assert.IsFalse(failedDataIntervals.Any(),
                        $"GAP: {JsonConvert.SerializeObject(gap)}" +
                        $"FAILED ON: {JsonConvert.SerializeObject(failedDataIntervals)}" +
                        $"DATA: {JsonConvert.SerializeObject(_dateIntervals)}"
                );

                var startedBeforeGapEnded = _dateIntervals.Where(di => gap.EndDate > di.StartDate);
                failedDataIntervals = startedBeforeGapEnded.Where(di => di.EndDate.AddMinutes(1) > gap.EndDate).ToArray();

                Assert.IsFalse(failedDataIntervals.Any(),
                    $"GAP: {JsonConvert.SerializeObject(gap)}" +
                    $"FAILED ON: {JsonConvert.SerializeObject(failedDataIntervals)}" +
                    $"DATA: {JsonConvert.SerializeObject(_dateIntervals)}"
                );


            }

        }
    }
}
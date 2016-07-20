using System;
using System.Collections.Generic;
using System.Linq;
using libGaps;

namespace gaps
{
    class Program
    {

        public static List<DateInterval> CreateUpTo50RandomDateIntervals()
        {
            var random = new Random(DateTime.Now.Millisecond);

            var numberOfDateIntervals = random.Next(0, 50);
            var dateIntervals = new List<DateInterval>(numberOfDateIntervals);

            while (numberOfDateIntervals-- > 0)
            {
                var startDate = new DateTime(random.Next(1930, 2016), random.Next(1, 12), random.Next(1, 28));
                dateIntervals.Add(new DateInterval()
                {
                    StartDate = startDate,
                    EndDate = startDate.AddDays(random.Next(0, 1000))
                });
            }

            return dateIntervals;

        }


        static void Main(string[] args)
        {

            var random = new Random(DateTime.Now.Millisecond);

            int numberOfDataSamples;

            if (args.Length != 1 || !int.TryParse(args[0], out numberOfDataSamples))
            {
                numberOfDataSamples = 1000;
            }

            List<List<DateInterval>> dataSamples = new List<List<DateInterval>>(numberOfDataSamples);

            while (numberOfDataSamples-- > 0)
            {
                dataSamples.Add(CreateUpTo50RandomDateIntervals());
            }

//            _result = (new GapsReader(dateIntervals)).Read();

        }
    }
}



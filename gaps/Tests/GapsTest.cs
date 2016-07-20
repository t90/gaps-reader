using System;
using System.Linq;
using libGaps;
using NUnit.Framework;

namespace Tests
{
    public class GapsTest
    {
        private DateInterval[] _intervals;
        private DateInterval[] _result;


        public GapsTest()
        {
            _intervals = new[]
            {
                new DateInterval()
                {
                    StartDate = DateTime.Parse("1/1/2000"),
                    EndDate = DateTime.Parse("2/1/2000"),
                },
                new DateInterval()
                {
                    StartDate = DateTime.Parse("3/1/2000"),
                    EndDate = DateTime.Parse("4/1/2000"),
                },
                new DateInterval()
                {
                    StartDate = DateTime.Parse("3/1/2000"),
                    EndDate = DateTime.Parse("5/1/2000"),
                },
                new DateInterval()
                {
                    StartDate = DateTime.Parse("4/1/2000"),
                    EndDate = DateTime.Parse("4/20/2000"),
                },
                new DateInterval()
                {
                    StartDate = DateTime.Parse("4/20/2000"),
                    EndDate = DateTime.Parse("5/20/2000"),
                },
                new DateInterval()
                {
                    StartDate = DateTime.Parse("10/1/2000"),
                    EndDate = DateTime.Parse("12/1/2000"),
                },
            };

            var gapsReader = new GapsReader(
                _intervals
            );

            _result = gapsReader.Read().ToArray();

        }

        [Test]
        public void It_Should_Produce_Two_Predefined_Gaps()
        {
            Assert.AreEqual(2, _result.Count());
        }

        [Test]
        public void It_Should_Have_One_Gap_Ending_3_1_2000()
        {
            Assert.IsTrue(_result.Any(r => r.EndDate == DateTime.Parse("3/1/2000")));
        }

        [Test]
        public void It_Should_Have_One_Gap_Ending_10_1_2000()
        {
            Assert.IsTrue(_result.Any(r => r.EndDate == DateTime.Parse("10/1/2000")));
        }
    }
}

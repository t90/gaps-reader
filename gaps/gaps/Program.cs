using System;
using System.Collections.Generic;
using System.Linq;
using libGaps;

namespace gaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var gapsReader = new GapsReader(
            new []
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
            }
            );


            gapsReader.Read().ToList().ForEach(i =>
                    Console.WriteLine($"{i.StartDate}:{i.EndDate}"));

        }
    }
}



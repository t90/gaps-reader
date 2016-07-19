using System;
using System.Collections.Generic;
using System.Linq;

/**
Copyright (c) 2016, Vladimir Vasiltsov and Andrew Yepin
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

 * Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of  nor the names of its contributors may be used to
   endorse or promote products derived from this software without specific
   prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
namespace libGaps
{
    public class DateInterval
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class GapsReader
    {
        private readonly IReadOnlyList<DateInterval> _inputIntervals;

        public GapsReader(IReadOnlyList<DateInterval> inputIntervals)
        {
            _inputIntervals = inputIntervals;
        }

        private SortedDictionary<DateTime,int> _datesList = new SortedDictionary<DateTime, int>();

        private void AddDate(DateTime date, int action)
        {
            int weight;
            if (_datesList.TryGetValue(date, out weight))
            {
                _datesList[date] = weight + action;
            }
            else
            {
                _datesList.Add(date,action);
            }
        }

        public IEnumerable<DateInterval> Read()
        {
            foreach (var i in _inputIntervals)
            {
                AddDate(i.StartDate,1);
                AddDate(i.EndDate,-1);
            }

            int counter = 0;
            int index = 0;
            var totalDates = _datesList.Count;

            var dates = _datesList.Keys.ToArray();
            var weights = _datesList.Values.ToArray();

            while (index < totalDates)
            {
                counter += weights[index];
                if (counter == 0 && index < totalDates - 1)
                {
                    yield return new DateInterval()
                    {
                        StartDate = dates[index],
                        EndDate = dates[index + 1]
                    };
                }
                index++;
            }
        }
    }
}

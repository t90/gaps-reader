# gaps-reader
Accept a list of date intervals and find gaps between them.

Many times we need to find gaps between dates (like work history gaps, payment gaps, procedure gaps etc) so here is a code snipped doing just this.

There is a class accepting a collection of date intervals which can overlap and it finds gaps between them. 

For example we have dates 

There will be two gaps 

2/1/2000 12:00:00 AM *to* 3/1/2000 12:00:00 AM

5/20/2000 12:00:00 AM *to* 10/1/2000 12:00:00 AM

for the following date intervals

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

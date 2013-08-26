using System;
using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports.Standings
{
    public class Leader : IResult
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public int Games { get; set; }
    }
}
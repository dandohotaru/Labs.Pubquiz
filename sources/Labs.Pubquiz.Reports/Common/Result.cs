using System;

namespace Labs.Pubquiz.Reports.Common
{
    [Serializable]
    public abstract class Result : IResult
    {
        protected Result()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; set; }
    }
}
using System;

namespace Labs.Pubquiz.Reports.Common
{
    public interface IResult
    {
        DateTimeOffset Stamp { get; }
    }
}
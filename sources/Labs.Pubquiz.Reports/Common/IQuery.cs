using System;

namespace Labs.Pubquiz.Reports.Common
{
    public interface IQuery<TResult> : IQuery
        where TResult : IResult
    {
    }

    public interface IQuery
    {
        DateTimeOffset Stamp { get; }
    }
}
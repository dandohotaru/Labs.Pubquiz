using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports
{
    public interface IReader
    {
        TResult Search<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IResult;
    }
}
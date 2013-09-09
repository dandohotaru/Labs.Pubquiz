using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports
{
    public interface IReader
    {
        TResult Search<TResult>(IQuery<TResult> query)
            where TResult : IResult;
    }
}
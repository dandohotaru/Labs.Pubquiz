using Labs.Pubquiz.Reports.Common;

namespace Labs.Pubquiz.Reports
{
    public interface IReader
    {
        TResult Process<TResult>(IQuery<TResult> query) where TResult : IResult;
    }
}
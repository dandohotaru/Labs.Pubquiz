namespace Labs.Pubquiz.Reports.Common
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Handle(TQuery request);
    }
}
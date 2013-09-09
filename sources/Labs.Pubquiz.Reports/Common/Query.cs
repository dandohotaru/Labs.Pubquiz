using System;

namespace Labs.Pubquiz.Reports.Common
{
    [Serializable]
    public abstract class Query<TResult> : Query, IQuery<TResult> 
        where TResult : IResult
    {
    }

    [Serializable]
    public abstract class Query : IQuery
    {
        protected Query()
        {
            Stamp = DateTimeOffset.Now;
        }

        public DateTimeOffset Stamp { get; set; }
    }
}
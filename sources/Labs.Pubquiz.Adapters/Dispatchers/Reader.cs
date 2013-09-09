using System;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Reports;
using Labs.Pubquiz.Reports.Common;
using Ninject;
using Ninject.Parameters;

namespace Labs.Pubquiz.Adapters.Dispatchers
{
    public class Reader : IReader
    {
        public Reader(Func<IStorage> context, IKernel resolver)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (resolver == null)
                throw new ArgumentNullException("resolver");

            Context = context;
            Resolver = resolver;
        }

        protected Func<IStorage> Context { get; private set; }

        protected IKernel Resolver { get; private set; }

        public TResult Search<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IResult
        {
            using (var context = Context())
            {
                var parameter = new ConstructorArgument("context", context);
                var handler = Resolver.Get<IQueryHandler<TQuery, TResult>>(parameter);
                return handler.Handle(query);
            }
        }
    }
}
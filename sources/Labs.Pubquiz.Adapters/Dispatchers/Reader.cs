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

        public TResult Search<TResult>(IQuery<TResult> query)
            where TResult : IResult
        {
            using (var context = Context())
            {
                var type = typeof (IQueryHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
                var parameter = new ConstructorArgument("context", context);
                var handler = (dynamic) Resolver.Get(type, parameter);
                var result = (TResult) handler.Handle((dynamic) query);

                return result;
            }
        }
    }
}
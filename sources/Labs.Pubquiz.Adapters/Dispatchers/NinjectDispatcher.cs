using System;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Handlers;
using Labs.Pubquiz.Reports;
using Labs.Pubquiz.Reports.Common;
using Ninject;
using Ninject.Parameters;

namespace Labs.Pubquiz.Adapters.Dispatchers
{
    public class NinjectDispatcher : IWriter, IReader
    {
        public NinjectDispatcher(Func<IStorage> context, IKernel resolver)
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

        public void Process(ICommand command)
        {
            using (var context = Context())
            {
                var contextParameter = new ConstructorArgument("context", context);
                var handlerType = typeof (ICommandHandler<>).MakeGenericType(command.GetType());
                var handler = (dynamic) Resolver.Get(handlerType, contextParameter);
                handler.Handle((dynamic) command);

                context.Save();
            }
        }

        public TResult Process<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            using (var context = Context())
            {
                var contextParameter = new ConstructorArgument("context", context);
                var handlerType = typeof (IQueryHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
                var handler = (dynamic) Resolver.Get(handlerType, contextParameter);
                var result = (TResult) handler.Handle((dynamic) query);

                return result;
            }
        }
    }
}
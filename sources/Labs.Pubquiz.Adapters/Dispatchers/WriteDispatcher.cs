using System;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Commands;
using Labs.Pubquiz.Domain.Common.Handlers;
using Ninject;
using Ninject.Parameters;

namespace Labs.Pubquiz.Adapters.Dispatchers
{
    public class WriteDispatcher : IDispatcher
    {
        public WriteDispatcher(Func<IStorage> context, IKernel resolver)
        {
            Context = context;
            Resolver = resolver;
        }

        protected Func<IStorage> Context { get; private set; }

        protected IKernel Resolver { get; private set; }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (var context = Context())
            {
                var parameter = new ConstructorArgument("context", context);
                var handler = Resolver.Get<ICommandHandler<TCommand>>(parameter);
                handler.Handle(command);

                context.Save();
            }
        }
    }
}
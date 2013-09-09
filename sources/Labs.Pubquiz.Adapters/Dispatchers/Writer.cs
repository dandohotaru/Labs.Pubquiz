using System;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common;
using Ninject;
using Ninject.Parameters;

namespace Labs.Pubquiz.Adapters.Dispatchers
{
    public class Writer : IWriter
    {
        public Writer(Func<IStorage> context, IKernel resolver)
        {
            if (context == null )
                throw new ArgumentNullException("context");
            if (resolver == null)
                throw new ArgumentNullException("resolver");

            Context = context;
            Resolver = resolver;
        }

        protected Func<IStorage> Context { get; private set; }

        protected IKernel Resolver { get; private set; }

        public void Send<TCommand>(TCommand command) 
            where TCommand : ICommand
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
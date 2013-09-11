using System;
using Labs.Pubquiz.Adapters.Dispatchers;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Reports;
using Labs.Pubquiz.Reports.Common;
using Labs.Pubquiz.Storage.Efw.Contexts;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Labs.Pubquiz.Adapters.Bootstrap
{
    public class NinjectBootstrap : NinjectModule
    {
        public override void Load()
        {
            Bind<Func<IStorage>>().ToMethod(context => (() => new SqlStorage()));
            Bind<IWriter>().To<NinjectDispatcher>();
            Bind<IReader>().To<NinjectDispatcher>();

            this.Bind(p => p
                .FromAssemblyContaining(typeof (ICommandHandler<>))
                .SelectAllClasses()
                .InheritedFrom(typeof (ICommandHandler<>))
                .BindAllInterfaces());

            this.Bind(p => p
                .FromAssemblyContaining(typeof (IQueryHandler<,>))
                .SelectAllClasses()
                .InheritedFrom(typeof (IQueryHandler<,>))
                .BindAllInterfaces());
        }
    }
}
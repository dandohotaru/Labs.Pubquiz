using System;
using Labs.Pubquiz.Adapters.Bootstrap;
using Labs.Pubquiz.Adapters.Dispatchers;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Reports;
using Labs.Pubquiz.Reports.Common;
using Labs.Pubquiz.Storage.Efw.Contexts;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Labs.Pubquiz.Tests.Common
{
    [TestFixture]
    public abstract class TestBase
    {
        protected IWriter Writer { get; private set; }
        protected IReader Reader { get; private set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IStorage>>().ToMethod(context => (() => new SqlStorage()));
            kernel.Bind<IWriter>().To<Writer>();
            kernel.Bind<IReader>().To<Reader>();

            kernel.Bind(p => p
                .FromAssemblyContaining(typeof(ICommandHandler<>))
                .SelectAllClasses()
                .InheritedFrom(typeof(ICommandHandler<>))
                .BindAllInterfaces());

            kernel.Bind(p => p
               .FromAssemblyContaining(typeof(IQueryHandler<,>))
               .SelectAllClasses()
               .InheritedFrom(typeof(IQueryHandler<,>))
               .BindAllInterfaces());

            ServiceLocator.SetLocatorProvider(() => new NinjectLocator(kernel));

            Writer = kernel.Get<IWriter>();
            Reader = kernel.Get<IReader>();
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            // ToDo: Seed test data
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            var builder = ServiceLocator.Current.GetInstance<Func<IStorage>>();
            using (var context = builder())
            {
                context.Clear();
                context.Save();
            }
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }

}

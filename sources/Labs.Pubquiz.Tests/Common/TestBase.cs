using System;
using Labs.Pubquiz.Adapters.Bootstrap;
using Labs.Pubquiz.Adapters.Dispatchers;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Handlers;
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
        protected IDispatcher Dispatcher { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IStorage>>().ToMethod(context => (() => new SqlStorage()));
            kernel.Bind<IDispatcher>().To<WriteDispatcher>();

            kernel.Bind(p => p
                .FromAssemblyContaining(typeof(ICommandHandler<>))
                .SelectAllClasses()
                .InheritedFrom(typeof(ICommandHandler<>))
                .BindAllInterfaces());

            ServiceLocator.SetLocatorProvider(() => new NinjectLocator(kernel));

            Dispatcher = kernel.Get<IDispatcher>();
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

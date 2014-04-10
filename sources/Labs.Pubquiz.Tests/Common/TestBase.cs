using System;
using Labs.Pubquiz.Adapters.Bootstrap;
using Labs.Pubquiz.Domain;
using Labs.Pubquiz.Domain.Common;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Reports;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ninject;

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
            var kernel = new StandardKernel(new NinjectBootstrap());
            ServiceLocator.SetLocatorProvider(() => new NinjectLocator(kernel));

            Writer = ServiceLocator.Current.GetInstance<IWriter>();
            Reader = ServiceLocator.Current.GetInstance<IReader>();
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

namespace Company.Application.UnitTests.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Company.Application.Models;
    using Company.Application.UnitTests.Creators;
    using Company.Application.UnitTests.Mocks;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CoolRepositoryShould
    {
        [SetUp]
        public void TestSetUp()
        {
            UnitTestContext.Instance.ConfigureDependencies();
        }

        [Test]
        public void Retrieve_Exisiting_Cool_Thing()
        {
            const int id = 13;
            var existingCoolThing = new CoolThing
            {
                Id = id
            };

            var coolThings = new List<CoolThing> { existingCoolThing }.AsQueryable();
            CoolDbContextMocks.CoolThings(UnitTestContext.Instance.Container, coolThings);

            var coolRepository = RepositoriesCreator.CoolRepository(UnitTestContext.Instance.Container);
            var retrievedCoolThing = coolRepository.Get(id);

            Assert.That(
                retrievedCoolThing.Id,
                Is.EqualTo(existingCoolThing.Id),
                "The retrieved cool thing is not correct");
        }

        [Test]
        public void Return_Null_For_Non_Exisiting_Cool_Thing()
        {
            const int id = 13;

            CoolDbContextMocks.CoolThings(UnitTestContext.Instance.Container);

            var coolRepository = RepositoriesCreator.CoolRepository(UnitTestContext.Instance.Container);
            var retrievedCoolThing = coolRepository.Get(id);

            Assert.That(
                retrievedCoolThing,
                Is.Null,
                "The retrieved cool thing is not correct");
        }

        [Test]
        public void Expose_IQueryable_Methods()
        {
            var dbCoolThings = new List<CoolThing> { new CoolThing() }.AsQueryable();

            CoolDbContextMocks.CoolThings(UnitTestContext.Instance.Container, dbCoolThings);

            var coolRepository = RepositoriesCreator.CoolRepository(UnitTestContext.Instance.Container);
            var coolThings = coolRepository.Where(x => true);

            Assert.That(
                coolThings.Count(),
                Is.EqualTo(dbCoolThings.Count()),
                "The total cool things count is not correct");

            var repositoryType = coolRepository.ElementType;

            Assert.That(
                repositoryType,
                Is.EqualTo(typeof(CoolThing)),
                "Cool repository returns wrong element type");

            coolRepository.ToList().ForEach(Console.WriteLine);

            var casted = coolRepository.AsWeakEnumerable().Cast<CoolThing>().Take(1).ToArray();
        }
    }
}

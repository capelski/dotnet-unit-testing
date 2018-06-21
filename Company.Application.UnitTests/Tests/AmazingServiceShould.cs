namespace Company.Application.UnitTests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Company.Application.Models;
    using Company.Application.UnitTests.Creators;
    using Company.Application.UnitTests.Mocks;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class AmazingServiceShould
    {
        [SetUp]
        public void TestSetUp()
        {
            UnitTestContext.Instance.ConfigureDependencies();
        }

        [Test]
        public void Successfully_Retrieve_Exisiting_Cool_Thing()
        {
            const int id = 13;
            var coolThing = new CoolThing
            {
                Id = id
            };

            CoolRepositoryMocks.GetById(UnitTestContext.Instance.Container, id, coolThing);
            AwesomeServiceMocks.IsItReallyCool(UnitTestContext.Instance.Container, true);

            var amazingService = ServicesCreator.AmazingService(UnitTestContext.Instance.Container);
            var retrievedInstance = amazingService.GetById(id);

            Assert.That(
                retrievedInstance.Id,
                Is.EqualTo(coolThing.Id),
                "The cool thing is not being correctly retrieved");
        }

        [Test]
        public void Raise_Exception_For_Non_Exisiting_Cool_Thing()
        {
            const int id = 13;

            CoolRepositoryMocks.GetById(UnitTestContext.Instance.Container, null);
            AwesomeServiceMocks.IsItReallyCool(UnitTestContext.Instance.Container, false);

            var amazingService = ServicesCreator.AmazingService(UnitTestContext.Instance.Container);
            Assert.Throws<Exception>(
                () => amazingService.GetById(id),
                "No exception is raised for non existing cool thing");
        }

        [Test]
        public void Raise_Exception_For_Non_Cool_Thing()
        {
            const int id = 14;
            var coolThing = new CoolThing
            {
                Id = id
            };

            CoolRepositoryMocks.GetById(UnitTestContext.Instance.Container, coolThing);
            AwesomeServiceMocks.IsItReallyCool(UnitTestContext.Instance.Container, false);

            var amazingService = ServicesCreator.AmazingService(UnitTestContext.Instance.Container);
            Assert.Throws<Exception>(
                () => amazingService.GetById(id),
                "No exception is raised for non cool thing");
        }
    }
}

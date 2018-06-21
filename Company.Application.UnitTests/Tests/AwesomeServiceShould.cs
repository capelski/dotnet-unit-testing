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
    public class AwesomeServiceShould
    {
        [SetUp]
        public void TestSetUp()
        {
            UnitTestContext.Instance.ConfigureDependencies();
        }

        [Test]
        public void Return_Cool_Thing_Is_Really_Cool_For_Odd_Id_Cool_Thing()
        {
            var coolThing = new CoolThing
            {
                Id = 13
            };

            var awesomeService = ServicesCreator.AwesomeService(UnitTestContext.Instance.Container);
            var isItReallyCool = awesomeService.IsItReallyCool(coolThing);

            Assert.That(
                isItReallyCool,
                Is.True,
                "Actual cool thing is being classified as non cool");
        }

        [Test]
        public void Return_Cool_Thing_Is_Not_Really_Cool_For_Even_Id_Cool_Thing()
        {
            var coolThing = new CoolThing
            {
                Id = 14
            };

            var awesomeService = ServicesCreator.AwesomeService(UnitTestContext.Instance.Container);
            var isItReallyCool = awesomeService.IsItReallyCool(coolThing);

            Assert.That(
                isItReallyCool,
                Is.False,
                "Non cool thing is being classified as cool");
        }

        [Test]
        public void Return_Cool_Thing_Is_Not_Really_Cool_For_Null_Cool_Thing()
        {
            var awesomeService = ServicesCreator.AwesomeService(UnitTestContext.Instance.Container);
            var isItReallyCool = awesomeService.IsItReallyCool(null);

            Assert.That(
                isItReallyCool,
                Is.False,
                "Non cool thing is being classified as cool");
        }
    }
}

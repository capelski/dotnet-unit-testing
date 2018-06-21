namespace Company.Application.UnitTests.Mocks
{
    using Company.Application.Logic.Contracts;
    using Company.Application.Models;
    using Microsoft.Practices.Unity;
    using Moq;

    public static class AwesomeServiceMocks
    {
        public static void IsItReallyCool(IUnityContainer container, bool result)
        {
            var mock = container.Resolve<Mock<IAwesomeService>>();

            mock
                .Setup(x => x.IsItReallyCool(It.IsAny<CoolThing>()))
                .Returns(result);
        }
    }
}

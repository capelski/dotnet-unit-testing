namespace Company.Application.UnitTests.Creators
{
    using Company.Application.Logic.Contracts;
    using Company.Application.Logic.Implementations;
    using Company.Application.Logic.Repositories;
    using Microsoft.Practices.Unity;
    using Moq;

    public static class ServicesCreator
    {
        public static IAmazingService AmazingService(IUnityContainer container)
        {
            var amazingService = new AmazingService(
                container.Resolve<Mock<ICoolRepository>>().Object,
                container.Resolve<Mock<IAwesomeService>>().Object);
            return amazingService;
        }

        public static IAwesomeService AwesomeService(IUnityContainer container)
        {
            var awesomeService = new AwesomeService();
            return awesomeService;
        }
    }
}

namespace Company.Application.UnitTests.Creators
{
    using Company.Application.Infrastructure;
    using Company.Application.Infrastructure.Implementations;
    using Company.Application.Logic.Repositories;
    using Microsoft.Practices.Unity;
    using Moq;

    public static class RepositoriesCreator
    {
        public static ICoolRepository CoolRepository(IUnityContainer container)
        {
            var coolRepository = new CoolRepository(
                container.Resolve<Mock<CoolDbContext>>().Object);
            return coolRepository;
        }
    }
}

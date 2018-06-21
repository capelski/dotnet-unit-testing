namespace Company.Application.UnitTests.Mocks
{
    using Company.Application.Logic.Repositories;
    using Company.Application.Models;
    using Microsoft.Practices.Unity;
    using Moq;

    public static class CoolRepositoryMocks
    {
        public static void GetById(IUnityContainer container, CoolThing result)
        {
            var coolRepositoryMock = container.Resolve<Mock<ICoolRepository>>();

            coolRepositoryMock
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(result);
        }

        public static void GetById(IUnityContainer container, int id, CoolThing result)
        {
            var coolRepositoryMock = container.Resolve<Mock<ICoolRepository>>();

            coolRepositoryMock
                .Setup(x => x.Get(id))
                .Returns(result);
        }
    }
}

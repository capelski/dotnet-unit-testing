namespace Company.Application.UnitTests
{
    using Company.Application.Infrastructure;
    using Company.Application.Logic.Contracts;
    using Company.Application.Logic.Repositories;
    using Company.Application.Models;
    using Microsoft.Practices.Unity;
    using Moq;

    public class UnitTestContext : QueryableRepositoriesTestContext
    {
        private static UnitTestContext instance;

        private UnitTestContext()
        {
        }

        public static UnitTestContext Instance => instance ?? (instance = new UnitTestContext());

        public override void ConfigureDependencies()
        {
            this.Container = new UnityContainer();

            this.Container.RegisterInstance(new Mock<CoolDbContext>());

            this.MockQueryableRepository<ICoolRepository, CoolThing>();

            this.Container.RegisterInstance(new Mock<IAwesomeService>());
            this.Container.RegisterInstance(new Mock<IAmazingService>());
        }
    }
}

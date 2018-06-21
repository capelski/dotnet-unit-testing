namespace Company.Application.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Moq;

    public abstract class QueryableRepositoriesTestContext
    {
        public IUnityContainer Container { get; protected set; }

        public abstract void ConfigureDependencies();

        public void MockQueryableRepository<TRepositoryInterface, TRepositoryType>()
            where TRepositoryInterface : class, IQueryable<TRepositoryType>
        {
            var source = new List<TRepositoryType>().AsQueryable();
            this.MockQueryableRepository<TRepositoryInterface, TRepositoryType>(source);
        }

        public void MockQueryableRepository<TRepositoryInterface, TRepositoryType>(
            IQueryable<TRepositoryType> source)
            where TRepositoryInterface : class, IQueryable<TRepositoryType>
        {
            var mockRepository = new Mock<TRepositoryInterface>();

            mockRepository.Setup(r => r.GetEnumerator()).Returns(source.GetEnumerator());
            mockRepository.Setup(r => r.Provider).Returns(source.Provider);
            mockRepository.Setup(r => r.ElementType).Returns(source.ElementType);
            mockRepository.Setup(r => r.Expression).Returns(source.Expression);

            this.Container.RegisterInstance(mockRepository);
        }
    }
}

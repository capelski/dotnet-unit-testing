namespace Company.Application.UnitTests.Mocks
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Company.Application.Infrastructure;
    using Company.Application.Models;
    using Microsoft.Practices.Unity;
    using Moq;

    public static class CoolDbContextMocks
    {
        public static void CoolThings(IUnityContainer container)
        {
            var coolThings = new List<CoolThing>().AsQueryable();
            CoolThings(container, coolThings);
        }

        public static void CoolThings(IUnityContainer container, IQueryable<CoolThing> coolThings)
        {
            var dbContext = container.Resolve<Mock<CoolDbContext>>();
            var dbSet = new Mock<DbSet<CoolThing>>();
            dbSet.As<IQueryable<CoolThing>>().Setup(x => x.ElementType).Returns(coolThings.ElementType);
            dbSet.As<IQueryable<CoolThing>>().Setup(x => x.Expression).Returns(coolThings.Expression);
            dbSet.As<IQueryable<CoolThing>>().Setup(x => x.Provider).Returns(coolThings.Provider);
            dbSet.As<IQueryable<CoolThing>>().Setup(x => x.GetEnumerator()).Returns(coolThings.GetEnumerator);
            dbContext.Setup(x => x.Set<CoolThing>()).Returns(dbSet.Object);
        }
    }
}

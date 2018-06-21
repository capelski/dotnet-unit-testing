namespace Company.Application.Infrastructure
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    internal class CoolDbConfiguration : DbConfiguration
    {
        public CoolDbConfiguration()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<CoolDbContext>());
        }
    }
}

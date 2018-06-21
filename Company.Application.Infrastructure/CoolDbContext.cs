namespace Company.Application.Infrastructure
{
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using Company.Application.Models;

    [ExcludeFromCodeCoverage]
    [DbConfigurationType(typeof(CoolDbConfiguration))]
    public class CoolDbContext : DbContext
    {
        public CoolDbContext()
            : base("name=CoolDbConnectionString")
        {
        }

        public DbSet<CoolThing> CoolThings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CoolDbSchema");
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
        }
    }
}
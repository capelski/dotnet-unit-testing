namespace Company.Application.Infrastructure.Implementations
{
    using System.Linq;
    using Company.Application.Logic.Repositories;
    using Company.Application.Models;

    public class CoolRepository : QueryableRepository<CoolThing>, ICoolRepository
    {
        public CoolRepository(CoolDbContext context)
            : base(context)
        {
        }

        public CoolThing Get(int id)
        {
            var coolThing = this.context.CoolThings.FirstOrDefault(x => x.Id == id);
            return coolThing;
        }
    }
}

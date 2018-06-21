namespace Company.Application.Logic.Repositories
{
    using System.Linq;
    using Company.Application.Models;

    public interface ICoolRepository : IQueryable<CoolThing>
    {
        CoolThing Get(int id);
    }
}

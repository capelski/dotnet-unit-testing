namespace Company.Application.Logic.Contracts
{
    using Company.Application.Models;

    public interface IAmazingService
    {
        CoolThing GetById(int id);
    }
}

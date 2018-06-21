namespace Company.Application.Logic.Implementations
{
    using Company.Application.Logic.Contracts;
    using Company.Application.Models;

    public class AwesomeService : IAwesomeService
    {
        public bool IsItReallyCool(CoolThing coolThing)
        {
            /* Everyone knows that only odd numbers can be cool */
            return coolThing != null && coolThing.Id % 2 == 1;
        }
    }
}

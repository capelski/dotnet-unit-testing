namespace Company.Application.Logic.Implementations
{
    using System;
    using Company.Application.Logic.Contracts;
    using Company.Application.Logic.Repositories;
    using Company.Application.Models;

    public class AmazingService : IAmazingService
    {
        private readonly ICoolRepository coolRepository;

        private readonly IAwesomeService awesomeService;

        public AmazingService(
            ICoolRepository coolRepository,
            IAwesomeService awesomeService)
        {
            this.coolRepository = coolRepository;
            this.awesomeService = awesomeService;
        }

        public CoolThing GetById(int id)
        {
            var coolThing = this.coolRepository.Get(id);
            var coolness = this.awesomeService.IsItReallyCool(coolThing);
            if (!coolness)
            {
                throw new Exception("The thing is actually not cool");
            }

            return coolThing;
        }
    }
}

namespace Company.Application.WebApi
{
    using System;
    using Company.Application.Infrastructure;
    using Company.Application.Infrastructure.Implementations;
    using Company.Application.Logic.Contracts;
    using Company.Application.Logic.Implementations;
    using Company.Application.Logic.Repositories;
    using Unity;

    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(new CoolDbContext());

            container.RegisterType<ICoolRepository, CoolRepository>();

            container.RegisterType<IAwesomeService, AwesomeService>();
            container.RegisterType<IAmazingService, AmazingService>();
        }
    }
}
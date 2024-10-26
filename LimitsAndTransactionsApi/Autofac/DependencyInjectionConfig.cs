using Autofac;
using Autofac.Core;
using LimitsAndTransactionsApi.Repositories.ExchangeRateRepository;
using LimitsAndTransactionsApi.Services;
using Quartz.Impl.AdoJobStore;

namespace LimitsAndTransactionsApi
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(ContainerBuilder builder)
        {
            // Пример регистрации с использованием различных жизненных циклов
            // builder.RegisterType<MyService>().As<IMyService>().InstancePerDependency(); // Transient
            // builder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope(); // Scoped, по умолчанию
            // builder.RegisterType<MyService>().As<IMyService>().SingleInstance(); // Singleton

            builder.RegisterType<ExchangeRateService>().As<IExchangeRateService>(); // Это будет использовать жизненный цикл .NET Core
            builder.RegisterType<ExchangeRateRepository>().As<IExchangeRateRepository>();
            
        }
    }
}

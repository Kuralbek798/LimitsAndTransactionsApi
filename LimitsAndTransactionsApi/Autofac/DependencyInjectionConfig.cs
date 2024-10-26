using Autofac;
using Autofac.Core;
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

            builder.RegisterType<MyService>().As<IMyService>(); // Это будет использовать жизненный цикл .NET Core
        }
    }
}

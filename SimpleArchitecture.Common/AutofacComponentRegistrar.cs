using System.Data.Entity;
using System.Linq;
using Autofac;
using SimpleArchitecture.Domain.Repositories;
using SimpleArchitecture.Domain.Services.Impl;
using SimpleArchitecture.Oracle;
using SimpleArchitecture.Oracle.Repositories;
using SimpleArchitecture.Util;

namespace SimpleArchitecture.Common
{
    public class AutofacComponentRegistrar
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterModule<OracleModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<UtilModule>();
        }
    }

    public class OracleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GenericRepository<>).Assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .As(type => type.GetInterfaces().Single(i => !i.IsGenericType));

            builder.RegisterType(typeof(OracleDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(TestService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .As(type => type.GetInterfaces().Single(i => i.Name.EndsWith("Service") && !i.IsGenericType));
        }
    }

    public class UtilModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(JsonUtil).Assembly)
                   .Where(t => t.Name.EndsWith("Util"))
                   .As(type => type.GetInterfaces().Single(i => !i.IsGenericType));
        }
    }
}
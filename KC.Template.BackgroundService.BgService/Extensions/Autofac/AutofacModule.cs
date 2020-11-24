using Autofac;
using KC.Template.BackgroundService.Domain;
using KC.Template.BackgroundService.Repository;
using KC.Template.BackgroundService.Service;
using Microsoft.Extensions.Hosting;

namespace KC.Template.BackgroundService.BgService
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 注入数据库上下文
            builder.RegisterType<ThisDBContext>().InstancePerLifetimeScope();
            #endregion
            #region 注入Service层
            builder.RegisterAssemblyTypes(typeof(BaseService).Assembly)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            #endregion
            #region 注入Repository层
            builder.RegisterAssemblyTypes(typeof(BaseRepository).Assembly)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            #endregion
            #region 添加后台服务
            builder.RegisterType<UserHS>().As<IHostedService>().SingleInstance();
            #endregion
        }
    }
}

using Autofac;
using CP.FinTech.SVO.Core.Interfaces;
using CP.FinTech.SVO.Core.Services;

namespace CP.FinTech.SVO.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}

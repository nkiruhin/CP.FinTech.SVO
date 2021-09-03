using System;
using Microsoft.Extensions.DependencyInjection;

namespace CP.FinTech.SVO.Core
{
    public static class StartupSetup
    {

        /// <summary>
        /// Регистрация зависимостей уровня приложения
        /// </summary>
        /// <param name="serviceCollection">serviceCollection</param>
        /// <param name="coreSettingsAction"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection, Action<CoreSettings> coreSettingsAction)
        {
            var coreSettings = new CoreSettings();
            coreSettingsAction?.Invoke(coreSettings);
            return serviceCollection;
        }
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}

using CP.FinTech.SVO.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CP.FinTech.SVO.ERC20
{
    public static class StartupSetup
    {
        public static IServiceCollection AddERC20(this IServiceCollection services)
        {
            services.AddSingleton<IContractOperation, ContractOperation>();
            return services;
        }          
    }
}

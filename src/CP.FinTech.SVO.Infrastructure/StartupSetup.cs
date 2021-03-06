using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Infrastructure.Data;
using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;
using CP.FinTech.SVO.Infrastructure.Ethereum.Interfaces;
using CP.FinTech.SVO.Infrastructure.Ethereum.Services;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CP.FinTech.SVO.Infrastructure
{
	public static class StartupSetup
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
			services.AddScoped<IAccountService, AccountService>();
			services.AddSingleton<ContractService>();
			services.AddSingleton<IContractFacade, ContractFacade>();
			services.AddTransient<IRepository,EfRepository>();
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite(connectionString)); // will be created in web project root
			return services;
		}
			
	}
}

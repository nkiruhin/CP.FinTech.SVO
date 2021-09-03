using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CP.FinTech.SVO.Infrastructure.Ethereum.Facade
{
    public partial class ContractFacade: IContractFacade
    {
        protected IConfiguration Config;
        protected readonly ILogger Logger;
        protected IMemoryCache Cache;
        private readonly object _locker = new object();
        public ContractFacade(IConfiguration config, ILogger<ContractFacade> logger, IMemoryCache cache)
        {
            Config = config;
            Logger = logger;
            Cache =  cache;
        }
    }
}
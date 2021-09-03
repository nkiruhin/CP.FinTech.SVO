using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;
using CP.FinTech.SVO.Infrastructure.Ethereum.Helpers.OperationResults;
using Microsoft.Extensions.Configuration;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.Infrastructure.Ethereum.Services
{
    public class ContractService
    {
        private readonly IContractFacade _contractFacade;
        private readonly IConfiguration _config;
        public ContractService(IContractFacade contractFacade, IConfiguration configuration)
        {
            _contractFacade = contractFacade;
            _config = configuration;
        }
        public async Task<DeploymentResult> DeploySVOSmartToken()
        {
            var abi = await _contractFacade.GetAbi("SVOToken", false, null);
            var byteCode = await _contractFacade.GetByteCode("SVOToken", false, null);
            return await _contractFacade.Deploy("SVOToken",
                                abi,
                                byteCode,
                                Constants.DEFAULT_TEST_ACCOUNT_ADDRESS,
                                Constants.DEFAULT_TEST_ACCOUNT_PASSWORD,
                                new HexBigInteger(Constants.DEFAULT_GAS));
        }

        public Web3 GetDefaultWeb3(ManagedAccount account)
        {
            return new Web3(account, _config.GetSection(Constants.GETH_RPC).Value);
        }
    }
}
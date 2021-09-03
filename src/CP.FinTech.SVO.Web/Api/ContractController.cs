using ContractInterface.ERC20;
using CP.FinTech.SVO.Infrastructure.Ethereum.DAO;
using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;
using CP.FinTech.SVO.Infrastructure.Ethereum.Helpers.OperationResults;
using CP.FinTech.SVO.Infrastructure.Ethereum.Interfaces;
using CP.FinTech.SVO.Infrastructure.Ethereum.Services;
using CP.FinTech.SVO.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.Web.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IConfiguration _config;
        private IContractFacade _contractFacade;
        private IContractOperation _operation;
        private Web3 _web3;
        private ManagedAccount _account;
        private ContractService _contractService;
        private ContractDAO _contract;
        private IAccountService _accountService;

        private readonly ILogger _logger;
        public ContractController(
            IConfiguration configuration,
            IContractFacade contractFacade,
            IContractOperation operation,
            ILogger<ContractController> logger,
            ContractService contractService,
            IAccountService accountService)
        {
            _config = configuration;
            _contractFacade = contractFacade;
            _operation = operation;
            _logger = logger;
            _contractService = contractService;
            _accountService = accountService;
            _web3 = _accountService.GetWeb3();
            _account = _accountService.GetAccount();
        }

        [HttpPost]
        [Route("deploy")]
        public async Task<ActionResult<DeploymentResult>> Deploy([FromBody] DeployDto request)
        {
            return await _contractFacade.Deploy(request.ContractName, request.Abi, request.Bytecode, request.AddressOwner, request.Password, request.Gas);
        }

        [HttpPost("deploy/default")]
        public async Task<ActionResult<DeploymentResult>> DeployDefault()
        {
            try
            {
                ContractService contServ = new ContractService(_contractFacade, _config);
                return await contServ.DeploySVOSmartToken();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error deploying contract: \n" + ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{contractAddress}/totalsupply")]
        public async Task<ActionResult<BigInteger>> GetTotalSupply(string contractAddress)
        {

            try
            {
                var contract = await _contractFacade.GetContract("SVOToken", true, contractAddress);
                return await _operation.GetTotalSupply(contract.Contract);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogDebug(ex.Message);
                return StatusCode(500);
            }
            catch (ArgumentException ex)
            {
                _logger.LogDebug(ex.Message);
                return StatusCode(400);
            }

        }

        [HttpGet("{contractAddress}/owner")]
        public async Task<ActionResult<string>> GetOwner(string contractAddress)
        {
            var contract = await _contractFacade.GetContract("SVOToken", true, contractAddress);
            return await _operation.GetOwner(contract.Contract);
        }
    }
}
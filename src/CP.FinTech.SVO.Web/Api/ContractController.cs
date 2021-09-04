using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Core.ProjectAggregate.Specifications;
using CP.FinTech.SVO.ERC20;
using CP.FinTech.SVO.Infrastructure.Ethereum.DAO;
using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;
using CP.FinTech.SVO.Infrastructure.Ethereum.Helpers.OperationResults;
using CP.FinTech.SVO.Infrastructure.Ethereum.Interfaces;
using CP.FinTech.SVO.Infrastructure.Ethereum.Services;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using CP.FinTech.SVO.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Diagnostics;
using System.Linq;
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
        private readonly IRepository _repository;

        private readonly ILogger _logger;
        public ContractController(
            IConfiguration configuration,
            IContractFacade contractFacade,
            IRepository repository,
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
            _repository = repository;
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
        // GET: api/Projects
        [AllowAnonymous]
        [HttpGet("{tenantId}")]
        public async Task<IActionResult> List(int tenantId)
        {
            var contractsDtos = (await _repository.ListAsync<Contract>(new ContractByTenantIdSpec(tenantId)))
                .Select(x => new ContractDto
                {
                    Id = x.Id,
                    DateEnd = x.DateEnd,
                    DateStart = x.DateStart,
                    Conssesion = x.Conssesion,
                    RatePerSquareMeter = x.RatePerSquareMeter,
                    RentalObjectId = x.RentalObjectId,
                    TenantId = x.TenantId,
                    WalletAddress = x.WalletAddress,
                    Transactions = x.Transactions.Select(t=> new TransactionDto 
                    { 
                        Date = t.Date,
                        Amount = (BigInteger)t.Amount,
                        ToAddress = t.Destination,
                        EthereumTransactionId = t.EthereumTransactionId,
                        ContractId = t.ContractId,
                        FromAddress = t.Source,
                        Id = t.Id
                    }).ToList()
                })
                .ToList();

            return Ok(contractsDtos);
        }
    }
}
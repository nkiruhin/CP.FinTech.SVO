using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Threading.Tasks;
using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Core.ProjectAggregate.Enum;
using CP.FinTech.SVO.Core.ProjectAggregate.Specifications;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using CP.FinTech.SVO.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CP.FinTech.SVO.Web.Api
{
    /// <summary>
    /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
    /// https://github.com/ardalis/ApiEndpoints
    /// </summary>
    public class TransactionController : BaseApiController
    {
        private readonly IRepository _repository;

        public TransactionController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Projects
        [HttpGet("{contractId:int}/transactions")]
        public async Task<IActionResult> List(int contractId)
        {
            var transactionDtos = (await _repository.ListAsync<Transaction>(new TransactionByContractIdSpec(contractId)))               
                .Select(t => new TransactionDto
                {
                    Date = t.Date,
                    Amount = (BigInteger)t.Amount,
                    ToAddress = t.Destination,
                    EthereumTransactionId = t.EthereumTransactionId,
                    ContractId = t.ContractId,
                    FromAddress = t.Source,
                    Id = t.Id
                })
                .ToList();

            return Ok(transactionDtos);
        }

        // GET: api/Projects
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {            
            
            var tenantDto = await _repository.GetByIdAsync<Transaction>(id);
                        
            var result = new TransactionDto
            {
                Date = tenantDto.Date,
                Amount = (BigInteger)tenantDto.Amount,
                ToAddress = tenantDto.Destination,
                EthereumTransactionId = tenantDto.EthereumTransactionId,
                ContractId = tenantDto.ContractId,
                FromAddress = tenantDto.Source,
                Id = tenantDto.Id
            };

            return Ok(result);
        }
                
    }
}

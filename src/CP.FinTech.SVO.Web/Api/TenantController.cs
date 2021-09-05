using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class TenantController : BaseApiController
    {
        private readonly IRepository _repository;

        public TenantController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tenantDtos = (await _repository.ListAsync<Tenant>(new TenantWithContractSpec()))
                .Select(tenantDto => new TenantDto
                {
                    Id = tenantDto.Id,
                    Name = tenantDto.Name,
                    ShortName = tenantDto.ShortName,
                    ActualAddress = tenantDto.ActualAddress,
                    Address = tenantDto.Address,
                    WalletAddress = tenantDto.WalletAddress,
                    Inn = tenantDto.Inn,
                    Kpp = tenantDto.Kpp,
                    Contacts = tenantDto.Contacts,
                    Ogrn = tenantDto.Ogrn,
                    orgType = tenantDto.orgType,
                    Contracts = tenantDto.Contracts.Select(x => new ContractDto
                    {
                        Id = x.Id,
                        RentalObjectId = x.RentalObjectId,
                        RatePerSquareMeter = x.RatePerSquareMeter,
                        Conssesion = x.Conssesion,
                        DateEnd = x.DateEnd,
                        DateStart = x.DateStart,
                        TenantId = x.TenantId,
                        WalletAddress = x.WalletAddress
                    }).ToList()
                });                

            return Ok(tenantDtos);
        }

        // GET: api/Projects
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {            
            
            var tenantDto = await _repository.GetByIdAsyncInclude<Tenant>(id, x => x.Contracts);

            var contractDto = tenantDto.Contracts.Select(x => new ContractDto
            {
                Id = x.Id,
                RentalObjectId = x.RentalObjectId,
                RatePerSquareMeter = x.RatePerSquareMeter,
                Conssesion = x.Conssesion,
                DateEnd = x.DateEnd,
                DateStart = x.DateStart,
                TenantId = x.TenantId,
                WalletAddress = x.WalletAddress
            }).ToList();
            
            var result = new TenantDto
            {
                Id = tenantDto.Id,
                Name = tenantDto.Name,
                ShortName = tenantDto.ShortName,
                ActualAddress = tenantDto.ActualAddress,
                Address = tenantDto.Address,
                WalletAddress = tenantDto.WalletAddress,
                Inn = tenantDto.Inn,
                Kpp = tenantDto.Kpp,
                Contacts = tenantDto.Contacts,
                Ogrn = tenantDto.Ogrn,
                orgType = tenantDto.orgType,
                Contracts = contractDto
            };

            return Ok(result);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TenantDto request)
        {
            var newTenant = new Tenant() 
            {
                Name = request.Name,
                ShortName = request.ShortName,
                Address = request.Address,
                ActualAddress = request.ActualAddress,
                Contacts = request.Contacts,
                Inn = request.Inn,
                Kpp = request.Kpp,
                Ogrn = request.Ogrn,
                orgType = request.orgType
            };
            _ = await _repository.AddAsync(newTenant);
            return Ok(request);
        }
        
    }
}

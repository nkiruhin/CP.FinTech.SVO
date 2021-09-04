using Ardalis.Specification;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Core.ProjectAggregate.Specifications
{
    public class ContractByTenantIdSpec : Specification<Contract>, ISingleResultSpecification
    {
        public ContractByTenantIdSpec(int tenantId)
        {
            Query
                .Include(x =>x.Transactions)
                .Where(x => x.TenantId == tenantId);

        }
    }
}

using Ardalis.Specification;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Core.ProjectAggregate.Specifications
{
    public class TenantWithContractSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantWithContractSpec()
        {
            Query
                .Include(x => x.Contracts);

        }
    }
}

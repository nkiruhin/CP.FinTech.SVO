using Ardalis.Specification;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Core.ProjectAggregate.Specifications
{
    public class TenantByIdSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantByIdSpec(int tenantId)
        {
            Query
                .Where(project => project.Id == tenantId);

        }
    }
}

using Ardalis.Specification;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Core.ProjectAggregate.Specifications
{
    public class TransactionByContractIdSpec : Specification<Transaction>, ISingleResultSpecification
    {
        public TransactionByContractIdSpec(int contractId)
        {
            Query
                .Where(x => x.ContractId == contractId);

        }
    }
}

using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;

namespace CP.FinTech.SVO.ERC20
{
    public partial class ContractOperation : IContractOperation
    {
        protected readonly IContractFacade ContractFacade;
        public ContractOperation(IContractFacade contractFacade)
        {
            ContractFacade = contractFacade;
        }
    }
}
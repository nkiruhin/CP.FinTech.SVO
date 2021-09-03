using CP.FinTech.SVO.Infrastructure.Ethereum.Facade;

namespace ContractInterface.ERC20
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
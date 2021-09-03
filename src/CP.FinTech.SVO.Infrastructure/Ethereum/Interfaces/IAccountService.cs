using CP.FinTech.SVO.Infrastructure.Ethereum.DAO;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Web3;

namespace CP.FinTech.SVO.Infrastructure.Ethereum.Interfaces
{
    public interface IAccountService
    {
        AccountDAO Authenticate(string address, string password);
        ManagedAccount GetAccount();
        Web3 GetWeb3();
    }
}
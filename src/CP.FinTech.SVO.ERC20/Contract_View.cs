using Nethereum.Contracts;
using System.Numerics;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.ERC20
{
    public partial class ContractOperation : IContractOperation
    {

        public async Task<BigInteger> GetTotalSupply(Contract contract)
        {
            var totalSupply = contract.GetFunction(Constants.FUNCTION_TOTAL_SUPPLY);
            var res = await totalSupply.CallAsync<long>();
            return res;
        }

        public async Task<BigInteger> GetBalanceOf(Contract contract, string address)
        {
            var balanceOf = contract.GetFunction(Constants.FUNCTION_BALANCE_OF);
            var res = await balanceOf.CallAsync<long>(address);
            return res;
        }

    }
}
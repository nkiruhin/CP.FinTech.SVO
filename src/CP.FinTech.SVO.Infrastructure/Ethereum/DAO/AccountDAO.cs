using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CP.FinTech.SVO.Infrastructure.Ethereum.DAO
{
    [FunctionOutput]
    public class AccountDAO
    {
        [Parameter("address", 1)]
        public string Address{get; set;}
        public double Balance{get; set;}
        public long Nonce{get; set;}
        public string PublicKey{get; set;}
        public string Password{get; set;}
        public string Token{get; set;}
        
    }
}
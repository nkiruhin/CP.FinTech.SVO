using System.Numerics;

namespace CP.FinTech.SVO.Web.ApiModels
{
    public class DeployDto
    {
        public string ContractName { get; set; }
        public string AddressOwner { get; set; }
        public string Password { get; set; }
        public string Abi { get; set; }
        public string Bytecode { get; set; }
        public BigInteger Gas { get; set; }
    }
}
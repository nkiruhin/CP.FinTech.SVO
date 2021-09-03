using System.Numerics;

namespace CP.FinTech.SVO.Web.ApiModels
{
    public class TransactionDto
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public BigInteger Amount { get; set; }
    }
}
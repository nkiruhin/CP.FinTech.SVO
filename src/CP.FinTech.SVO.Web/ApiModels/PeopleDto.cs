using System.Numerics;

namespace CP.FinTech.SVO.Web.ApiModels
{
    public class PeopleDto
    {
        public string ToAdd { get; set; }
        public string ToRemove { get; set; }
        public string ToInquire { get; set; }
        public string MapTo { get; set; }
        public BigInteger Allowance { get; set; }
    }
}
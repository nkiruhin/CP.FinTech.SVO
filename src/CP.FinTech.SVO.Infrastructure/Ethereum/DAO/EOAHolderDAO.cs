using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace CP.FinTech.SVO.Infrastructure.Ethereum.DAO
{
    [FunctionOutput]
    public class EOAHolderDAO : AccountDAO
    {
        public List<EOAAppointeeDAO> Appointees { get; set; }

    }
}
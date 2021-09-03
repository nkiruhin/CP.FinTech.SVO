namespace CP.FinTech.SVO.Infrastructure.Ethereum.DAO
{
    public class EOAAppointeeDAO : AccountDAO
    {
        public long Allowance { get; set; }
        public EOAHolderDAO Holder { get; set; }
    }
}
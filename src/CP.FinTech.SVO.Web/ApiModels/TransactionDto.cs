using CP.FinTech.SVO.SharedKernel;
using System;
using System.Numerics;

namespace CP.FinTech.SVO.Web.ApiModels
{
    public class TransactionDto: BaseEntity
    {
                    
        /// <summary>
        /// ���� ����������
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ���� �����������
        /// </summary>        
        public string FromAddress { get; set; }
        /// <summary>
        /// ���� ����������
        /// </summary>
        public string ToAddress { get; set; }
        /// <summary>
        /// ������������� ���������� � Ethereum
        /// </summary>
        public string EthereumTransactionId { set; get; }
        /// <summary>
        /// �����
        /// </summary>
        public BigInteger Amount { get; set; }
        /// <summary>
        /// ������ �� ��������
        /// </summary>
        public ContractDto Contract { get; set; }
        public int ContractId { get; set; }
    }
}
using CP.FinTech.SVO.SharedKernel;
using System;
using System.Numerics;

namespace CP.FinTech.SVO.Web.ApiModels
{
    public class TransactionDto: BaseEntity
    {
                    
        /// <summary>
        /// Дата транзакции
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Счет отправителя
        /// </summary>        
        public string FromAddress { get; set; }
        /// <summary>
        /// Счет получателя
        /// </summary>
        public string ToAddress { get; set; }
        /// <summary>
        /// Идентификатор транзакции в Ethereum
        /// </summary>
        public string EthereumTransactionId { set; get; }
        /// <summary>
        /// Сумма
        /// </summary>
        public BigInteger Amount { get; set; }
        /// <summary>
        /// Ссылка на контракт
        /// </summary>
        public ContractDto Contract { get; set; }
        public int ContractId { get; set; }
    }
}
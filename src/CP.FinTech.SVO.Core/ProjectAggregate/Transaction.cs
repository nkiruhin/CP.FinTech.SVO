using CP.FinTech.SVO.SharedKernel.Interfaces;
using CP.FinTech.SVO.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.Core.ProjectAggregate
{
    public class Transaction: BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Дата транзакции
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Счет отправителя
        /// </summary>        
        public string Source { get; set; }
        /// <summary>
        /// Счет получателя
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Идентификатор транзакции в Ethereum
        /// </summary>
        public string EthereumTransactionId { set; get; }
        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Ссылка на контракт
        /// </summary>
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
    }
}

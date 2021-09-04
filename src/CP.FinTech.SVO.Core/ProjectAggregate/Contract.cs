using CP.FinTech.SVO.SharedKernel.Interfaces;
using CP.FinTech.SVO.SharedKernel;
using System;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;

namespace CP.FinTech.SVO.Core.ProjectAggregate
{
    public class Contract : BaseEntity, IAggregateRoot
    {

        /// <summary>
        /// Дата договора
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// Сигнатура контракта(арендатора)
        /// </summary>
        public byte[] Signature { get; set; }
        /// <summary>
        /// Идентификатор обьекта аренды
        /// </summary>
        public string RentalObjectId { get; set; }
        /// <summary>
        /// Конссия
        /// </summary>
        public int Conssesion { get; set; }
        /// <summary>
        /// Ставка за кв.м
        /// </summary>
        public int RatePerSquareMeter { get; set; }
        /// <summary>
        /// Номер счетa
        /// </summary>
        public string WalletAddress { get; set; }
        /// <summary>
        /// Арендодатель
        /// </summary>
        public Tenant Tenant { get; set; }
        /// <summary>
        /// Арендодатель
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// Ссылка на транзакции
        /// </summary>
        public IList<Transaction> Transactions { get; set; }
    }
}
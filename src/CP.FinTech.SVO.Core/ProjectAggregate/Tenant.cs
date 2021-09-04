using CP.FinTech.SVO.Core.ProjectAggregate.Enum;
using CP.FinTech.SVO.SharedKernel;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace CP.FinTech.SVO.Core.ProjectAggregate
{
    public class Tenant : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Нименование организации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Краткое наименование организации
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Юр. адресс
        /// </summary>
        public string ActualAddress { get; set; }
        /// <summary>
        /// Контакт
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// Инн
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// КПП
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// ОГРН
        /// </summary>
        public string Ogrn { get; set; }
        /// <summary>
        /// Тип организации
        /// </summary>
        public OrgType orgType { get; set; }
        /// <summary>
        /// Номера счетов
        /// </summary>
        public string[] WalletAddress { get; set; }
        /// <summary>
        /// Список контрактов
        /// </summary>
        public IList<Contract> Contracts { get; set; }
    }
}

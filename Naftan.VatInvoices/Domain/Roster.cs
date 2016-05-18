
using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Продукт (товар, услуга)
    /// </summary>
    public class Roster
    {
        [DisplayName("№ п.п.")]
        public string Name { get; set; }

        [DisplayName("Код")]
        public int Id { get; set; }
        [DisplayName("Код ЭСЧФ")]
        public int InvoiceId { get; set; }
        [DisplayName("Тип ставки НДС")]
        public VatRateType VatRateType { get; set; }
        [DisplayName("Номер")]
        public int Number { get; set; }
        [DisplayName("Код ТНВЭД")]
        public string Code { get; set; }
        [DisplayName("Код ОКЭД")]
        public string CodeOced { get; set; }
        [DisplayName("Ед. изм.")]
        public string Units { get; set; }
        [DisplayName("Кол-во (объём)")]
        public decimal? Count { get; set; }
        [DisplayName("Цена")]
        public decimal? Price { get; set; }
        [DisplayName("Стоимость")]
        public decimal Cost { get; set; }
        [DisplayName("Сумма акциза")]
        public decimal? SummaExcise { get; set; }
        [DisplayName("НДС, ставка %")]
        public decimal VatRate { get; set; }
        [DisplayName("Сумма НДС")]
        public decimal SummaVat { get; set; }
        [DisplayName("Стоимость с учётом НДС")]
        public decimal CostVat { get; set; }
        [DisplayName("Доп. сведения")]
        public RosterDescription? Description { get; set; }
    }
}

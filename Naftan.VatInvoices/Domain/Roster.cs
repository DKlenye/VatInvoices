
using System.ComponentModel;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Продукт (товар, услуга)
    /// </summary>
    public class Roster : IVatInvoiceId
    {
        [DisplayName("№ п.п.")]
        public int Number { get; set; }

        [DisplayName("Код")]
        public int Id { get; set; }

        [DisplayName("Код ЭСЧФ")]
        public int InvoiceId { get; set; }
        
        [DisplayName("Наименование")]
        public string Name { get; set; }
        
        [DisplayName("Код ТНВЭД")]
        public string Code { get; set; }

        [DisplayName("Код ОКЭД")]
        public string CodeOced { get; set; }

        [DisplayName("Ед. изм.")]
        public int Units { get; set; }

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

        [DisplayName("Тип ставки НДС")]
        public rateType VatRateType { get; set; }

        [DisplayName("Сумма НДС")]
        public decimal SummaVat { get; set; }

        [DisplayName("Стоимость с учётом НДС")]
        public decimal CostVat { get; set; }

        [DisplayName("Доп. сведения")]
        public descriptionType[] Description { get; set; }
    }
}
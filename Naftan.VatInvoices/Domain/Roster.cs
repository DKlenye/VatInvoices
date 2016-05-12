
namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Продукт (товар, услуга)
    /// </summary>
    public class Roster
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public VatRateType VatRateType { get; set; }
        public int? Number { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CodeOced { get; set; }
        public string Units { get; set; }
        public decimal? Count { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public decimal? SummaExcise { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? SummaVat { get; set; }
        public decimal? CostVat { get; set; }
        public RosterDescription? Description { get; set; }
    }
}

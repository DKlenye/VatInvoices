namespace Naftan.VatInvoices.Dto
{
    /// <summary>
    /// Информация по ЭСЧФ
    /// </summary>
    public class VatInvoiceDto
    {
        public int InvoiceId { get; set; }
        public string NumberString { get; set; }

        public decimal? RosterTotalCostVat { get; set; }
        public decimal? RosterTotalExcise { get; set; }
        public decimal? RosterTotalVat { get; set; }
        public decimal? RosterTotalCost { get; set; }
    }
}

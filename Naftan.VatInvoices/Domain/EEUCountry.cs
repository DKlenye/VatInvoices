namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Страны ЕАЭС
    /// </summary>
    public class EEUCountry
    {
        public static int BelarusCode = 112;

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

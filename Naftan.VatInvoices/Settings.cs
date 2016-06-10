namespace Naftan.VatInvoices
{
    public static class Settings
    {
        //значения по умолчанию
        static Settings()
        {
            SenderUnp = "300042199";
            ConnectionString = "data source=db3; initial catalog=NDSInvoices; integrated security=SSPI;";
            PortalUrl = "https://vat.gov.by:4443/InvoicesWS/services/InvoicesPort";
        }
        
        /// <summary>
        ///  УНП отправителя (по умолчанию УНП Нафтана)
        /// </summary>
        public static string SenderUnp { get; set; }

        /// <summary>
        /// Строка подключения к БД ЭСЧФ
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        ///  url адрес веб сервиса портала МНС
        /// </summary>
        public static string PortalUrl { get; set; }
    }
}

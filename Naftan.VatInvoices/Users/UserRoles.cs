using System.ComponentModel;

namespace Naftan.VatInvoices.Users
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public enum UserRoles
    {
        [Description("Администратор")] NDSInvoices_Admins,
        [Description("Пользователь")] NDSInvoices_Users,
        [Description("Бухгалтер")] NDSInvoices_Accountant,
        [Description("Бухгалтер налогового сектора")] NDSInvoices_TaxAccountant
    }
}

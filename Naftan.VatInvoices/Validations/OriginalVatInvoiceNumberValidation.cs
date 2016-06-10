using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Queries;

namespace Naftan.VatInvoices.Validations
{
    public class OriginalVatInvoiceNumberValidation:IValidation<VatInvoice>
    {
        private IDatabase _db;

        private const string message1 =
           "Номер исходного или предыдущего исправленного ЭСЧФ обязателен для заполнения при указании Исправленного или Дополнительного типа ЭСЧФ";

        private const string message2 =
           "Не найден исходный ЭСЧФ. Неверный номер исходного ЭСЧФ";

        private const string message3 =
           "Статус исходного ЭСЧФ должен быть «Выставлен» или «Выставлен. Подписан получателем»";

        private const string message4 =
            "При заполнении поля <к ЭСЧФ> можноввести только номер Исходного или Исправленного ЭСЧФ";


        private readonly invoiceDocType[] docTypesforValidation =
        {
            invoiceDocType.FIXED,
            invoiceDocType.ADDITIONAL
        };

        private readonly InvoiceStatus[] originalValidStatuses =
        {
            InvoiceStatus.COMPLETED, 
            InvoiceStatus.COMPLETED_SIGNED
        };

        private readonly invoiceDocType[] originalValidTypes =
        {
            invoiceDocType.ORIGINAL,
            invoiceDocType.FIXED
        };


        public OriginalVatInvoiceNumberValidation(IDatabase db)
        {
            _db = db;
        }
        
        public IList<string> Validate(VatInvoice obj)
        {
            var errorList = new List<string>();

            if (docTypesforValidation.Contains(obj.InvoiceType))
            {
                if (String.IsNullOrEmpty(obj.OriginalInvoiceNumber))
                {
                    errorList.Add(message1);
                }

                var original = _db.Execute(new SelectVatInvoiceDtoByNumber(obj.OriginalInvoiceNumber)).FirstOrDefault();

                if (original == null)
                {
                    errorList.Add(message2);
                }
                else
                {
                    if( !originalValidStatuses.Contains(original.InvoiceStatus))
                        errorList.Add(message3);
                    if(!originalValidTypes.Contains(original.InvoiceType))
                        errorList.Add(message4);
                }

            }

            return errorList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Validations
{
    public class DocumentValidation:IValidation<VatInvoice>
    {
        private string message1 = 
            "Для ТТН-1 и ТН-2 дата, код типа бланка, серия и номер - обязательны для заполнения";

        private string message2 =
            "Если заполнен тип, или номер или дата документа, то тип, номер и дата обязательны для заполнения";

        /// <summary>
        /// ТТН1 и ТН2
        /// </summary>
        private int[] checkDocTypes = {602, 603};


        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<string>();

            if (obj.Documents.Any(
                x =>x.DocTypeCode!=null && checkDocTypes.Contains(x.DocTypeCode.Value) &&
                    (String.IsNullOrEmpty(x.BlancCode) || String.IsNullOrEmpty(x.Seria) || String.IsNullOrEmpty(x.Number) || x.Date==null)
            ))
              messages.Add(message1);


            if(obj.Documents.Any(
                x=>
                    (x.DocTypeCode!=null || !String.IsNullOrEmpty(x.Number) ||x.Date!=null) &&
                    (x.DocTypeCode == null || String.IsNullOrEmpty(x.Number) || x.Date==null)
                ))
                messages.Add(message2);

            return messages;

        }
    }
}

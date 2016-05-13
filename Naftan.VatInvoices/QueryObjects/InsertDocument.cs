using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.QueryObjects
{
    public class InsertDocument{   
        public QueryObject Query(Document document){
        
            return new QueryObject(@"
                INSERT INTO Documents
                    (
	                    ReplicationId,
	                    InvoiceId,
	                    DocTypeCode,
	                    DocTypeValue,
	                    BlancCode,
	                    Number,
	                    Seria,
	                    [Date]
                    )
                    VALUES
                    (
	                     @ReplicationId,
	                     @InvoiceId,
	                     @DocTypeCode,
	                     @DocTypeValue,
	                     @BlancCode,
	                     @Number,
	                     @Seria,
	                     @Date
                    ); Select SCOPE_IDENTITY(); ", new
                    {
                        document.ReplicationId,
                        document.InvoiceId,
                        document.DocTypeCode,
                        document.DocTypeValue,
                        document.BlancCode,
                        document.Number,
                        document.Seria,
                        document.Date
                    }
            );
        }
    }
}

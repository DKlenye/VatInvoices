using System;
using System.Data;
using System.Xml;
using Dapper;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Commands
{
    public class AddVatInvoice:ICommand
    {
        public AddVatInvoice(AddVatInvoiceParams addParams, XmlNode consignors, XmlNode consignees, XmlNode documents, XmlNode rosterList)
        {
            Consignors = consignors;
            RosterList = rosterList;
            Documents = documents;
            Consignees = consignees;
            AddParams = addParams;
        }

        public AddVatInvoiceParams AddParams { get; private set; }
        public XmlNode Documents { get; private set; }
        public XmlNode Consignors { get; private set; }
        public XmlNode Consignees { get; private set; }
        public XmlNode RosterList { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            var p = new DynamicParameters(AddParams);

            p.Add("@DateCancelled", AddParams.DateCancelledSpecified ? AddParams.DateCancelled : (DateTime?)null);
            p.Add("@PrincipalInvoiceDate", AddParams.PrincipalInvoiceDateSpecified ? AddParams.PrincipalInvoiceDate : (DateTime?)null);
            p.Add("@VendorInvoiceDate", AddParams.VendorInvoiceDateSpecified ? AddParams.VendorInvoiceDate : (DateTime?)null);

            p.Add("@DateRelease", AddParams.DateReleaseSpecified ? AddParams.DateRelease : (DateTime?)null);
            p.Add("@DateActualExport", AddParams.DateActualExportSpecified ? AddParams.DateActualExport : (DateTime?)null);
            p.Add("@ProviderTaxeDate", AddParams.ProviderTaxeDateSpecified ? AddParams.ProviderTaxeDate : (DateTime?)null);
            p.Add("@RecipientCounteragentId", AddParams.RecipientCounteragentIdSpecified ? AddParams.RecipientCounteragentId : (int?)null);
            p.Add("@RecipientTaxeDate", AddParams.RecipientTaxeDateSpecified ? AddParams.RecipientTaxeDate : (DateTime?)null);

            p.Add("@RecipientCountryCode", AddParams.RecipientCountryCodeSpecified ? AddParams.RecipientCountryCode : (int?)null);
            p.Add("@DateImport", AddParams.DateImportSpecified ? AddParams.DateImport : (DateTime?)null);
            p.Add("@ContractDate", AddParams.ContractDateSpecified ? AddParams.ContractDate : (DateTime?)null);

            p.Add("@Documents",Documents.OuterXml);
            p.Add("@Consignors", Consignors.OuterXml);
            p.Add("@Consignees", Consignees.OuterXml);
            p.Add("@RosterList", RosterList.OuterXml);


            db.Query<AddVatInvoiceRezult>(
                "spu_AddVatInvoice",
                param:p,
                commandType: CommandType.StoredProcedure,
                transaction:tx
                );

        }
    }
}

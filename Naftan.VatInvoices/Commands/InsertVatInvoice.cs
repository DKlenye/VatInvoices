using System.Data;
using System.Linq;
using Dapper;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class InsertVatInvoice : ICommand
    {
        public InsertVatInvoice(VatInvoice invoice)
        {
            Invoice = invoice;
        }

        public VatInvoice Invoice { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {

            var param = new DynamicParameters(Invoice)
                .Output(Invoice, x => x.InvoiceId);
            param.AddDynamicParams(Invoice.VatNumber);
            param.AddDynamicParams(Invoice.Provider);
            param.AddDynamicParams(Invoice.Recipient);

            db.Execute(@"
                INSERT INTO VatInvoice
            (
                IsIncome,
                ReplicationSourceId,
	            ReplicationId,
	            BuySaleTypeId,
	            VatAccount,
	            Account,
                AccountingDate,
	            StatusId,                
                StatusMessage,
                Sender,
	            [Year],
	            Number,
	            NumberString,
	            DateIssuance,
	            DateTransaction,
	            InvoiceTypeId,
	            OriginalInvoiceNumber,
	            SendToRecipient,
	            DateCancelled,
                ProviderCounteragentId,
	            ProviderStatusId,
	            ProviderDependentPerson,
	            ProviderResidentsOfOffshore,
	            ProviderSpecialDealGoods,
	            ProviderBigCompany,
	            ProviderCountryCode,
	            ProviderUnp,
	            ProviderBranchCode,
	            ProviderName,
	            ProviderAddress,
	            PrincipalInvoiceNumber,
	            PrincipalInvoiceDate,
	            VendorInvoiceNumber,
	            VendorInvoiceDate,
	            ProviderDeclaration,
	            DateRelease,
	            DateActualExport,
	            ProviderTaxeNumber,
	            ProviderTaxeDate,
                RecipientCounteragentId,
	            RecipientStatusId,
	            RecipientDependentPerson,
	            RecipientResidentsOfOffshore,
	            RecipientSpecialDealGoods,
	            RecipientBigCompany,
	            RecipientCountryCode,
	            RecipientUnp,
	            RecipientBranchCode,
	            RecipientName,
	            RecipientAddress,
	            RecipientDeclaration,
	            RecipientTaxeNumber,
	            RecipientTaxeDate,
	            DateImport,
                ContractId,
	            ContractNumber,
	            ContractDate,
	            ContractDescription,
                RosterTotalCostVat,
	            RosterTotalExcise,
	            RosterTotalVat,
	            RosterTotalCost,
	            ApproveDate,
                ApproveUser,
                ApproveDateExport,
                IsValidate
            )
            VALUES
            (
                @IsIncome,
                @ReplicationSourceId,
	            @ReplicationId,
	            @BuySaleType,
	            @VatAccount,
	            @Account,
                @AccountingDate,
	            @Status,
                @StatusMessage,
                @Sender,
	            @Year,
	            @Number,
	            @NumberString,
	            @DateIssuance,
	            @DateTransaction,
	            @InvoiceType,
	            @OriginalInvoiceNumber,
	            @SendToRecipient,
	            @DateCancelled,
                @ProviderCounteragentId,
	            @ProviderStatus,
	            @ProviderDependentPerson,
	            @ProviderResidentsOfOffshore,
	            @ProviderSpecialDealGoods,
	            @ProviderBigCompany,
	            @ProviderCountryCode,
	            @ProviderUnp,
	            @ProviderBranchCode,
	            @ProviderName,
	            @ProviderAddress,
	            @PrincipalInvoiceNumber,
	            @PrincipalInvoiceDate,
	            @VendorInvoiceNumber,
	            @VendorInvoiceDate,
	            @ProviderDeclaration,
	            @DateRelease,
	            @DateActualExport,
	            @ProviderTaxeNumber,
	            @ProviderTaxeDate,
                @RecipientCounteragentId,
	            @RecipientStatus,
	            @RecipientDependentPerson,
	            @RecipientResidentsOfOffshore,
	            @RecipientSpecialDealGoods,
	            @RecipientBigCompany,
	            @RecipientCountryCode,
	            @RecipientUnp,
	            @RecipientBranchCode,
	            @RecipientName,
	            @RecipientAddress,
	            @RecipientDeclaration,
	            @RecipientTaxeNumber,
	            @RecipientTaxeDate,
	            @DateImport,
                @ContractId,
	            @ContractNumber,
	            @ContractDate,
	            @ContractDescription,
                @RosterTotalCostVat,
	            @RosterTotalExcise,
	            @RosterTotalVat,
	            @RosterTotalCost,
                @ApproveDate,
                @ApproveUser,
                @ApproveDateExport,
                @IsValidate
            );
            SELECT @InvoiceId = SCOPE_IDENTITY();

        ", param, tx);

            if (Invoice.Documents != null)
                Invoice.Documents.ToList().ForEach(d =>
                {
                    d.InvoiceId = Invoice.InvoiceId;
                    db.Insert(d, tx);
                });

            if (Invoice.Consignees != null)
                Invoice.Consignees.ToList().ForEach(c =>
                {
                    c.InvoiceId = Invoice.InvoiceId;
                    db.Insert(c, tx);
                });

            if (Invoice.Consignors != null)
                Invoice.Consignors.ToList().ForEach(c =>
                {
                    c.InvoiceId = Invoice.InvoiceId;
                    db.Insert(c, tx);
                });

            Invoice.RosterList.ToList().ForEach(r =>
            {
                r.InvoiceId = Invoice.InvoiceId;
                new InsertRoster(r).Execute(db, tx);
            });
        }
    }
}

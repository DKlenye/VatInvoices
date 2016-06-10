using System.Data;
using System.Linq;
using Dapper;
using DapperExtensions;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Queries;

namespace Naftan.VatInvoices.Commands
{
    public class UpdateVatInvoice : ICommand
    {
        public UpdateVatInvoice(VatInvoice invoice, bool headerOnly = false)
        {
            HeaderOnly = headerOnly;
            Invoice = invoice;
        }

        /// <summary>
        /// ЭСЧФ
        /// </summary>
        public VatInvoice Invoice { get; private set; }

        /// <summary>
        /// Обновить информацию только по головной части ЭСЧФ
        /// </summary>
        public bool HeaderOnly { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            var param = new DynamicParameters(Invoice);
            param.AddDynamicParams(Invoice.VatNumber);
            param.AddDynamicParams(Invoice.Provider);
            param.AddDynamicParams(Invoice.Recipient);

            db.Execute(@"

                UPDATE VatInvoice
                SET
	                IsIncome = @IsIncome,
	                ReplicationSourceId = @ReplicationSourceId,
	                ReplicationId = @ReplicationId,
	                BuySaleTypeId = @BuySaleType,
	                VatAccount = @VatAccount,
	                Account = @Account,
	                AccountingDate = @AccountingDate,
	                StatusId = @Status,
	                StatusMessage = @StatusMessage,
	                Sender = @Sender,
	                [Year] = @Year,
	                Number = @Number,
	                NumberString = @NumberString,
	                DateIssuance = @DateIssuance,
	                DateTransaction = @DateTransaction,
	                InvoiceTypeId = @InvoiceType,
	                OriginalInvoiceNumber = @OriginalInvoiceNumber,
	                SendToRecipient = @SendToRecipient,
	                DateCancelled = @DateCancelled,
	                ProviderCounteragentId = @ProviderCounteragentId,
	                ProviderStatusId = @ProviderStatus,
	                ProviderDependentPerson = @ProviderDependentPerson,
	                ProviderResidentsOfOffshore = @ProviderResidentsOfOffshore,
	                ProviderSpecialDealGoods = @ProviderSpecialDealGoods,
	                ProviderBigCompany = @ProviderBigCompany,
	                ProviderCountryCode = @ProviderCountryCode,
	                ProviderUnp = @ProviderUnp,
	                ProviderBranchCode = @ProviderBranchCode,
	                ProviderName = @ProviderName,
	                ProviderAddress = @ProviderAddress,
	                PrincipalInvoiceNumber = @PrincipalInvoiceNumber,
	                PrincipalInvoiceDate = @PrincipalInvoiceDate,
	                VendorInvoiceNumber = @VendorInvoiceNumber,
	                VendorInvoiceDate = @VendorInvoiceDate,
	                ProviderDeclaration = @ProviderDeclaration,
	                DateRelease = @DateRelease,
	                DateActualExport = @DateActualExport,
	                ProviderTaxeNumber = @ProviderTaxeNumber,
	                ProviderTaxeDate = @ProviderTaxeDate,
	                RecipientCounteragentId = @RecipientCounteragentId,
	                RecipientStatusId = @RecipientStatus,
	                RecipientDependentPerson = @RecipientDependentPerson,
	                RecipientResidentsOfOffshore = @RecipientResidentsOfOffshore,
	                RecipientSpecialDealGoods = @RecipientSpecialDealGoods,
	                RecipientBigCompany = @RecipientBigCompany,
	                RecipientCountryCode = @RecipientCountryCode,
	                RecipientUnp = @RecipientUnp,
	                RecipientBranchCode = @RecipientBranchCode,
	                RecipientName = @RecipientName,
	                RecipientAddress = @RecipientAddress,
	                RecipientDeclaration = @RecipientDeclaration,
	                RecipientTaxeNumber = @RecipientTaxeNumber,
	                RecipientTaxeDate = @RecipientTaxeDate,
	                DateImport = @DateImport,
	                ContractId = @ContractId,
	                ContractNumber = @ContractNumber,
	                ContractDate = @ContractDate,
	                ContractDescription = @ContractDescription,
	                RosterTotalCostVat = @RosterTotalCostVat,
	                RosterTotalExcise = @RosterTotalExcise,
	                RosterTotalVat = @RosterTotalVat,
	                RosterTotalCost = @RosterTotalCost,
	                ApproveDate = @ApproveDate,
	                ApproveUser = @ApproveUser,
                    IsValidate = @IsValidate
                WHERE 
                    InvoiceId = @InvoiceId", param, tx);

            if (!HeaderOnly)
            {
                Invoice.Documents.ToList().ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                        x.InvoiceId = Invoice.InvoiceId;
                        db.Insert(x, tx);
                    }
                    else db.Update(x, tx);
                });

                var DocumentMap = Invoice.Documents.ToDictionary(x => x.Id, x => x);

                new SelectDocumentsByInvoiceId(Invoice.InvoiceId).Execute(db, tx).ToList().ForEach(x =>
                {
                    if (!DocumentMap.ContainsKey(x.Id))
                    {
                        db.Delete(x, tx);
                    }
                });

                Invoice.Consignees.ToList().ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                        x.InvoiceId = Invoice.InvoiceId;
                        db.Insert(x, tx);
                    }
                    else db.Update(x, tx);
                });

                var ConsigneeMap = Invoice.Consignees.ToDictionary(x => x.Id, x => x);

                new SelectConsigneesByInvoiceId(Invoice.InvoiceId).Execute(db, tx).ToList().ForEach(x =>
                {
                    if (!ConsigneeMap.ContainsKey(x.Id))
                    {
                        db.Delete(x, tx);
                    }
                });


                Invoice.Consignors.ToList().ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                        x.InvoiceId = Invoice.InvoiceId;
                        db.Insert(x, tx);
                    }
                    else db.Update(x, tx);
                });

                var ConsignorMap = Invoice.Consignors.ToDictionary(x => x.Id, x => x);

                new SelectConsignorsByInvoiceId(Invoice.InvoiceId).Execute(db, tx).ToList().ForEach(x =>
                {
                    if (!ConsignorMap.ContainsKey(x.Id))
                    {
                        db.Delete(x, tx);
                    }
                });

                Invoice.RosterList.ToList().ForEach(x =>
                {
                    if (x.Id == 0)
                    {
                        x.InvoiceId = Invoice.InvoiceId;
                        new InsertRoster(x).Execute(db, tx);
                    }
                    else new UpdateRoster(x).Execute(db, tx);
                });

                var RosterMap = Invoice.RosterList.ToDictionary(x => x.Id, x => x);

                new SelectRostersByInvoiceId(Invoice.InvoiceId).Execute(db, tx).ToList().ForEach(x =>
                {
                    if (!RosterMap.ContainsKey(x.Id))
                    {
                        new DeleteRoster(x).Execute(db, tx);
                    }
                });
            }
        }
    }
}

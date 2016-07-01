namespace Naftan.VatInvoices.Commands.DDL.CreateProcedure
{
    public class spu_AddVatInvoice:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"

CREATE PROC [dbo].[spu_AddVatInvoice] 
(
	@ReplicationSourceId INT,
	@ReplicationId INT,
	@IsApprove BIT = 0,
	@ApproveUser NVARCHAR(100) = null,
	@BuySaleType TINYINT,
	@InvoiceTypeId TINYINT,
	@DateTransaction DATE,
	@VatAccount NVARCHAR(8) = NULL,
	@Account NVARCHAR(8),
	@AccountingDate date, 
	@OriginalInvoiceNumber NCHAR(25) = NULL,
	@SendToRecipient BIT = 0,
	@DateCancelled DATE = NULL,
	
	--Поставщик
	@ProviderCounteragentId INT = NULL,
	
	@ProviderStatusId TINYINT = NULL,
	@ProviderDependentPerson BIT = 0,
	@ProviderResidentsOfOffshore BIT = 0,
	@ProviderSpecialDealGoods BIT = 0,
	@ProviderBigCompany BIT = 0,
	@ProviderCountryCode INT = NULL,
	@ProviderUnp NCHAR(9) = NULL,
	@ProviderBranchCode NVARCHAR(50) = NULL,
	@ProviderName NVARCHAR(512) = NULL,
	@ProviderAddress NVARCHAR(512) = NULL,
	@PrincipalInvoiceNumber NCHAR(25) = NULL,
	@PrincipalInvoiceDate DATE = NULL,
	@VendorInvoiceNumber NCHAR(25) = NULL,
	@VendorInvoiceDate DATE = NULL,
	@ProviderDeclaration NVARCHAR(50) = NULL,
	@DateRelease DATE = NULL,
	@DateActualExport DATE = NULL,
	@ProviderTaxeNumber NVARCHAR(50) = NULL,
	@ProviderTaxeDate DATE = NULL,
	--
	
	--Получатель
	@RecipientCounteragentId INT = NULL,
	
	@RecipientStatusId TINYINT = NULL,
	@RecipientDependentPerson BIT = 0,
	@RecipientResidentsOfOffshore BIT = 0,
	@RecipientSpecialDealGoods BIT = 0,
	@RecipientBigCompany BIT = 0,
	@RecipientCountryCode INT = NULL,
	@RecipientUnp NCHAR(9) = NULL,
	@RecipientBranchCode NVARCHAR(50) = NULL,
	@RecipientName NVARCHAR(512) = NULL,
	@RecipientAddress NVARCHAR(512) = NULL,
	@RecipientDeclaration NVARCHAR(50) = NULL,
	@RecipientTaxeNumber NVARCHAR(50) = NULL,
	@RecipientTaxeDate DATE = NULL,
	@DateImport DATE = NULL,
	
		
	--Договор
	@ContractId	INT = NULL,
	@ContractNumber NVARCHAR(50) = NULL,
	@ContractDate DATE = NULL,
	@ContractDescription NVARCHAR(100) = NULL,
	
	
	--Документ
	@DocumentId INT = NULL,
	@DocumentTypeCode INT = NULL,
	@DocumentBlancCode NVARCHAR(50) = NULL,
	@DocumentNumber NVARCHAR(50) = NULL,
	@DocumentSeria NVARCHAR(50) = NULL,
	@DocumentDate DATE = NULL,
		
	@Documents NTEXT = NULL,
		
	--Грузоотправитель
	@ConsignorCounteragentId INT = NULL,
	
	@ConsignorCountryCode INT = NULL,
	@ConsignorUnp NCHAR(9) = NULL,
	@ConsignorName NVARCHAR(512) = NULL,
	@ConsignorAddress NVARCHAR(512) = NULL,
	
	@Consignors NTEXT = NULL,
	
	
	--Грузополучатель
	@ConsigneeCounteragentId INT = NULL,
	
	@ConsigneeCountryCode INT = NULL,
	@ConsigneeUnp NCHAR(9) = NULL,
	@ConsigneeName NVARCHAR(200) = NULL,
	@ConsigneeAddress NVARCHAR(200) = NULL,
	
	@Consignees NTEXT = NULL,
	--
			
	--Товары
	@RosterList NTEXT = NULL
	
)
AS
BEGIN
	SET NOCOUNT ON;
	
	--Constants 
	
	DECLARE @NaftanUNP CHAR(9)
	SET @NaftanUNP = '300042199'
	
	--
		
	--Таблица результатов импорта
	DECLARE @Rezult TABLE
	(
		IsException BIT NOT NULL,
		[Message] varchar(1000) NOT NULL,
		VatInvoiceNumber nchar(25),
		VatInvoiceId  int
	)
	
	
	
	--Проверка заполнения--
		
		
	--
	DECLARE @invoiceId INT, @status TINYINT, @numberString NCHAR(25), @number BIGINT
	
	IF(@InvoiceTypeId=1)
	BEGIN
		
		SELECT 
			@invoiceId = InvoiceId,
			@numberString = NumberString,
			@number = Number,
			@status = StatusId
		FROM VatInvoice WHERE ReplicationSourceId = @ReplicationSourceId AND ReplicationId =  @ReplicationId AND InvoiceTypeId = 1
		
		--если исходный счёт фактура уже сформирован по документу и он ещё не отправлен на портал, то удаляем её сохраняем новые данные со старым номером 
		IF(@invoiceId is not NULL)
		BEGIN
			IF(@status IN (1,2,8))
			BEGIN
				EXEC spu_RemoveVatInvoice
				@InvoiceId = @invoiceId
			END
			ELSE BEGIN
								
			     	INSERT INTO @Rezult
				VALUES
				(
					1,
					'Исходный ЭСЧФ по документу уже сформирован и отправлен на портал, изменение данных невозможно',
					NULL,
					NULL
				)
	
				
	
				SELECT * FROM @Rezult
				RETURN 0
			     END
		END
		
		
	END
	
	
	DECLARE @year INT
	SELECT 
			@year = YEAR(GETDATE())
	
	IF(@numberString IS null)
		
		EXEC spu_GenerateVatInvoiceNumber
			@Year = @year,
			@Number = @number OUTPUT,
			@NumberString = @numberString OUTPUT
	
	
	
	--Поставщик
	
	/*Если задан код контрагента то пытаемся найти его данные из общезаводского справочника*/
	IF(@ProviderCounteragentId IS NOT NULL)
		EXEC spu_FindCounteragent
			@CounteragentId = @ProviderCounteragentId,
			@Name = @ProviderName OUTPUT,
			@Unp = @ProviderUnp OUTPUT,
			@CountryCode = @ProviderCountryCode OUTPUT,
			@Address = @ProviderAddress OUTPUT
	
	--Получатель
	
	/*Если задан код контрагента то пытаемся найти его данные из общезаводского справочника*/
	IF(@RecipientCounteragentId IS NOT NULL)
		EXEC spu_FindCounteragent
			@CounteragentId = @RecipientCounteragentId,
			@Name = @RecipientName OUTPUT,
			@Unp = @RecipientUnp OUTPUT,
			@CountryCode = @RecipientCountryCode OUTPUT,
			@Address = @RecipientAddress OUTPUT
	
	/*Если задан код договора, то пытаемся найти его данные из общезаводского справочника*/
	IF(@ContractId IS NOT null)
		EXEC spu_FindContract
			@ContractId = @ContractId,
			@Number = @ContractNumber OUTPUT,
			@Date = @ContractDate OUTPUT
	
	
	
	DECLARE @_documents TABLE(DocumentId INT, DocumentTypeCode INT , DocumentBlancCode NVARCHAR(50), DocumentNumber NVARCHAR(50) ,	DocumentSeria NVARCHAR(50) ,DocumentDate Date )
	
	IF(@Documents IS NULL AND @DocumentTypeCode IS NOT NULL)
	BEGIN
		INSERT INTO @_documents
		VALUES
		(
			@DocumentId,
			@DocumentTypeCode,
			@DocumentBlancCode,--CASE WHEN @DocumentBlancCode IS NULL AND @DocumentTypeCode IN (602,603) THEN dbo.f_FindBlankCode(@DocumentSeria, @DocumentNumber) ELSE @DocumentBlancCode END,
			@DocumentNumber,
			@DocumentSeria,
			@DocumentDate
		)
	END	
	ELSE 
	BEGIN
		DECLARE @idXmlDocuments INT
		EXEC sp_xml_preparedocument @idXmlDocuments OUTPUT, @Documents 
		
		INSERT INTO @_documents		
		SELECT 
			DocumentId,
			DocumentTypeCode,
			DocumentBlancCode,--CASE WHEN DocumentBlancCode IS NULL AND DocumentTypeCode IN (602,603) THEN dbo.f_FindBlankCode(DocumentSeria, DocumentNumber) ELSE DocumentBlancCode END,
			DocumentNumber,
			DocumentSeria,
			DocumentDate
		FROM
			OPENXML (@idXmlDocuments, '/Documents/Document') WITH 
			(
				DocumentId INT '@Id',
				DocumentTypeCode INT '@TypeCode',
				DocumentBlancCode NVARCHAR(50) '@BlancCode',
				DocumentNumber NVARCHAR(50) '@Number',
				DocumentSeria NVARCHAR(50) '@Seria',
				DocumentDate Date '@Date'
			)
		EXEC sp_xml_removedocument @idXmlDocuments
	END
	
	
	DECLARE @_RosterList TABLE(
				Number INT,
				Name NVARCHAR(512) ,
				Code NVARCHAR(10) ,
				CodeOced NVARCHAR(5) ,
				Units INT ,
				[Count] DECIMAL(18,6) ,
				Price DECIMAL(18,3) ,
				Cost DECIMAL(18,3) ,
				SummaExcise DECIMAL(18,3),
				VatRate DECIMAL(4,2),
				VatRateTypeId TINYINT,
				SummaVat DECIMAL(18,3),
				CostVat DECIMAL(18,3))
	
	DECLARE @_RosterDescription TABLE(Number INT,DescriptionTypeId  TINYINT)
	
	DECLARE @idXmlRosterList INT
	EXEC sp_xml_preparedocument @idXmlRosterList OUTPUT, @RosterList 
	
	INSERT INTO @_RosterList
		SELECT 
			Number,
			Name,
			Code,
			CodeOced,
			Units,
			[Count],
			Price,
			Cost,
			SummaExcise,
			VatRate,
			VatRateTypeId,
			SummaVat,
			CostVat
		FROM
			OPENXML (@idXmlRosterList, '/RosterList/Roster') WITH 
			(
				Number INT '@Number',
				Name NVARCHAR(512) '@Name',
				Code NVARCHAR(10) '@Code',
				CodeOced NVARCHAR(5) '@CodeOced',
				Units INT '@Units',
				[Count] DECIMAL(18,6) '@Count',
				Price DECIMAL(18,3) '@Price',
				Cost DECIMAL(18,3) '@Cost',
				SummaExcise DECIMAL(18,3) '@SummaExcise',
				VatRate DECIMAL(4,2) '@VatRate',
				VatRateTypeId TINYINT '@VatRateTypeId',
				SummaVat DECIMAL(18,3) '@SummaVat',
				CostVat DECIMAL(18,3) '@CostVat'
			)
			
		INSERT INTO @_RosterDescription
		SELECT a.Number,a.DescriptionTypeId
		FROM OPENXML (@idXmlRosterList, '/RosterList/Roster/Description',2)	WITH (
			Number	INT	'../@Number',
			DescriptionTypeId  TINYINT '@DescriptionTypeId'
		)a
		WHERE a.DescriptionTypeId IS NOT NULL AND a.DescriptionTypeId<>0
											
		EXEC sp_xml_removedocument @idXmlRosterList
	
	
	--SELECT * FROM @_RosterDescription
	
	
	BEGIN TRANSACTION AddInvoiceTransaction
	
	BEGIN TRY
		
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
		Sender,
		[Year],
		Number,
		NumberString,
		DateTransaction,
		InvoiceTypeId, 
		OriginalInvoiceNumber,
		SendToRecipient,
		DateCancelled,
		ContractId, 
		ContractNumber,
		ContractDate,
		ContractDescription,
		ProviderCounteragentId,
		ProviderCountryCode,
		ProviderBranchCode,
		ProviderUnp,
		ProviderName,
		ProviderAddress,
		ProviderStatusId,
		ProviderDependentPerson,
		ProviderResidentsOfOffshore,
		ProviderSpecialDealGoods,
		ProviderBigCompany,
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
		RecipientCountryCode, 
		RecipientBranchCode, 
		RecipientUnp, 
		RecipientName, 
		RecipientAddress,
		RecipientStatusId,
		RecipientDependentPerson,
		RecipientResidentsOfOffshore,
		RecipientSpecialDealGoods,
		RecipientBigCompany,
		RecipientDeclaration,
		RecipientTaxeNumber,
		RecipientTaxeDate,
		DateImport,
		ApproveDate,
		ApproveUser,
		IsValidate,
		RosterTotalCostVat,
		RosterTotalExcise,
		RosterTotalVat,
		RosterTotalCost
	)
	VALUES
	(
		0,
		@ReplicationSourceId,
		@ReplicationId,
		@BuySaleType,
		@VatAccount,
		@Account,
		@AccountingDate,
		1,
		@NaftanUNP,
		@year,
		@number,
		@numberString,
		@DateTransaction,
		@InvoiceTypeId,
		@OriginalInvoiceNumber,
		@SendToRecipient,
		@DateCancelled,
		@ContractId,
		@ContractNumber,
		@ContractDate,
		@ContractDescription,
		@ProviderCounteragentId,
		@ProviderCountryCode,
		@ProviderBranchCode,
		@ProviderUnp,
		@ProviderName,
		@ProviderAddress, 
		@ProviderStatusId,
		@ProviderDependentPerson,
		@ProviderResidentsOfOffshore,
		@ProviderSpecialDealGoods,
		@ProviderBigCompany,
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
		@RecipientCountryCode,
		@RecipientBranchCode,
		@RecipientUnp,
		@RecipientName,
		@RecipientAddress,
		@RecipientStatusId,
		@RecipientDependentPerson,
		@RecipientResidentsOfOffshore,
		@RecipientSpecialDealGoods,
		@RecipientBigCompany,
		@RecipientDeclaration,
		@RecipientTaxeNumber,
		@RecipientTaxeDate,
		@DateImport,
		CASE WHEN @IsApprove = 1 THEN GETDATE() ELSE NULL END,
		CASE WHEN @IsApprove = 1 THEN @ApproveUser ELSE NULL END,
		0,
		(SELECT SUM(isnull(CostVat,0)) FROM @_RosterList),
		(SELECT SUM(isnull(SummaExcise,0)) FROM @_RosterList),
		(SELECT SUM(isnull(SummaVat,0)) FROM @_RosterList),
		(SELECT SUM(isnull(Cost,0)) FROM @_RosterList)
	)
		
	SET @InvoiceId = SCOPE_IDENTITY()
	
	--Временная таблица для извлечения контрагентов
	DECLARE @counteragents TABLE(N int, CounteragentId INT,NAME NVARCHAR(200),Unp NCHAR(9),CountryCode INT,[Address] NVARCHAR(200))
	DECLARE @counter INT
	
	/* Грузоотправители
		* Если грузоотправителей несколько, то они задаются списком в формате xml параметр @Consignors
		* Иначе обрабатываем одного грузоотправителя
	*/
	
	IF(@Consignors IS NULL)
	BEGIN
		
		/*Если задан код контрагента то пытаемся найти его данные из общезаводского справочника*/
		IF(@ConsignorCounteragentId IS NOT NULL)
			EXEC spu_FindCounteragent
			@CounteragentId = @ConsignorCounteragentId,
			@Name = @ConsignorName OUTPUT,
			@Unp = @ConsignorUnp OUTPUT,
			@CountryCode = @ConsignorCountryCode OUTPUT,
			@Address = @ConsignorAddress OUTPUT
		
		IF(@ConsignorName IS NOT null)
		
		INSERT INTO Consignors
		VALUES
		(
			@ConsignorCounteragentId,
			@invoiceId,
			@ConsignorCountryCode,
			@ConsignorUnp,
			@ConsignorName,
			@ConsignorAddress
		)
		
	END
	ELSE
	BEGIN
				
		DECLARE @idXmlConsignors INT

		EXEC sp_xml_preparedocument @idXmlConsignors OUTPUT, @Consignors
		
		INSERT INTO @counteragents
		SELECT ROW_NUMBER() OVER ( ORDER BY CounteragentId),* FROM
			OPENXML (@idXmlConsignors, '/Consignors/Consignor') WITH 
			(
				CounteragentId INT '@CounteragentId',
				NAME NVARCHAR(200) '@Name',
				Unp NCHAR(9) '@Unp',
				CountryCode INT '@CountryCode',
				[Address] NVARCHAR(200) '@Address'
			)
		EXEC sp_xml_removedocument @idXmlConsignors

		SELECT @counter = COUNT(*) FROM @counteragents
				
		WHILE @counter>0
		BEGIN
			SELECT 
				@ConsignorCounteragentId = CounteragentId,
				@ConsignorCountryCode = CountryCode,
				@ConsignorUnp = Unp,
				@ConsignorName = NAME,
				@ConsignorAddress = [Address]
			FROM @counteragents WHERE N = @counter
	
		IF(@ConsignorCounteragentId IS NOT NULL)
			EXEC spu_FindCounteragent
				@CounteragentId = @ConsignorCounteragentId,
				@Name = @ConsignorName OUTPUT,
				@Unp = @ConsignorUnp OUTPUT,
				@CountryCode = @ConsignorCountryCode OUTPUT,
				@Address = @ConsignorAddress OUTPUT
				
			INSERT INTO Consignors
			VALUES
			(
				@ConsignorCounteragentId,
				@invoiceId,
				@ConsignorCountryCode,
				@ConsignorUnp,
				@ConsignorName,
				@ConsignorAddress
			)
	
			DELETE FROM @counteragents WHERE N = @counter
			SET @counter = @counter-1
		END
		
	END
		
		
	/* Грузополучатели
		* Если грузополучателей несколько, то они задаются списком в формате xml параметр @Consignees
		* Иначе обрабатываем одного грузополучателя
	*/
	
	IF(@Consignees IS NULL)
	BEGIN
		
		/*Если задан код контрагента то пытаемся найти его данные из общезаводского справочника*/
		IF(@ConsigneeCounteragentId IS NOT NULL)
			EXEC spu_FindCounteragent
			@CounteragentId = @ConsigneeCounteragentId,
			@Name = @ConsigneeName OUTPUT,
			@Unp = @ConsigneeUnp OUTPUT,
			@CountryCode = @ConsigneeCountryCode OUTPUT,
			@Address = @ConsigneeAddress OUTPUT
		
		
		IF(@ConsigneeName IS NOT null)
		INSERT INTO Consignees
		VALUES
		(
			@ConsigneeCounteragentId,
			@invoiceId,
			@ConsigneeCountryCode,
			@ConsigneeUnp,
			@ConsigneeName,
			@ConsigneeAddress
		)
		
	END
	ELSE
	BEGIN
				
		DECLARE @idXmlConsignees INT

		EXEC sp_xml_preparedocument @idXmlConsignees OUTPUT, @Consignees
		
		INSERT INTO @counteragents
		SELECT ROW_NUMBER() OVER ( ORDER BY CounteragentId),* FROM
			OPENXML (@idXmlConsignees, '/Consignees/Consignee') WITH 
			(
				CounteragentId INT '@CounteragentId',
				NAME NVARCHAR(200) '@Name',
				Unp NCHAR(9) '@Unp',
				CountryCode INT '@CountryCode',
				[Address] NVARCHAR(200) '@Address'
			)
		EXEC sp_xml_removedocument @idXmlConsignees

		SELECT @counter = COUNT(*) FROM @counteragents
				
		WHILE @counter>0
		BEGIN
			SELECT 
				@ConsigneeCounteragentId = CounteragentId,
				@ConsigneeCountryCode = CountryCode,
				@ConsigneeUnp = Unp,
				@ConsigneeName = NAME,
				@ConsigneeAddress = [Address]
			FROM @counteragents WHERE N = @counter
	
			IF(@ConsigneeCounteragentId IS NOT NULL)
			EXEC spu_FindCounteragent
				@CounteragentId = @ConsigneeCounteragentId,
				@Name = @ConsigneeName OUTPUT,
				@Unp = @ConsigneeUnp OUTPUT,
				@CountryCode = @ConsigneeCountryCode OUTPUT,
				@Address = @ConsigneeAddress OUTPUT
				
			INSERT INTO Consignees
			VALUES
			(
				@ConsigneeCounteragentId,
				@invoiceId,
				@ConsigneeCountryCode,
				@ConsigneeUnp,
				@ConsigneeName,
				@ConsigneeAddress
			)
	
			DELETE FROM @counteragents WHERE N = @counter
			SET @counter = @counter-1
		END
		
	END
	
	
	INSERT INTO Documents
	SELECT 
		DocumentId,
		@invoiceId,
		DocumentTypeCode,
		DocumentBlancCode,
		DocumentNumber,
		DocumentSeria,
		DocumentDate
	FROM @_documents
	
	
	INSERT INTO RosterList(
		InvoiceId,
		Number,
		NAME,
		Code,
		CodeOced,
		Units,
		[Count],
		Price,
		Cost,
		SummaExcise,
		VatRate,
		VatRateTypeId,
		SummaVat,
		CostVat
	)
	SELECT 
		@invoiceId,
		Number,
		NAME,
		Code,
		CodeOced,
		Units,
		[Count],
		Price,
		Cost,
		SummaExcise,
		VatRate,
		VatRateTypeId,
		SummaVat,
		CostVat
	FROM @_RosterList
	
	INSERT INTO RosterDescription
	(
		RosterId,
		DescriptionTypeId
	)
	SELECT 
		l.Id,
		d.DescriptionTypeId
	FROM @_RosterDescription d
	LEFT JOIN RosterList l ON l.InvoiceId = @invoiceId AND l.Number = d.Number
	
	INSERT INTO @Rezult
	VALUES
	(
		0,
		'',
		@numberString,
		@invoiceId
	)
		
		COMMIT TRANSACTION AddInvoiceTransaction
		
	END TRY
	BEGIN CATCH
	
	
	INSERT INTO @Rezult
	VALUES
	(
		1,
		ERROR_MESSAGE(),
		null,
		null
	)
	
		/* 
			SELECT
				ERROR_NUMBER() AS ErrorNumber,
				ERROR_SEVERITY() AS ErrorSeverity,
				ERROR_STATE() AS ErrorState,
				ERROR_PROCEDURE() AS ErrorProcedure,
				ERROR_LINE() AS ErrorLine,
				ERROR_MESSAGE() AS ErrorMessage
		*/
	END CATCH
	
			
	
	
	SELECT * FROM @Rezult
	RETURN 1
	
END





"; }
        }
    }
}

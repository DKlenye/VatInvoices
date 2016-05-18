﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.18020.
// 
namespace Naftan.VatInvoices.Mnsati.AddNoReference
{
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.w3schools.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.w3schools.com", IsNullable=false)]
    public partial class issuance {
        
        /// <remarks/>
        public general general;
        
        /// <remarks/>
        public provider provider;
        
        /// <remarks/>
        public recipient recipient;
        
        /// <remarks/>
        public senderReceiver senderReceiver;
        
        /// <remarks/>
        public deliveryCondition deliveryCondition;
        
        /// <remarks/>
        public rosterList roster;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sender;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class general {
        
        /// <remarks/>
        public string number;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateIssuance;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateTransaction;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateTransactionSpecified;
        
        /// <remarks/>
        public invoiceDocType documentType;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum invoiceDocType {
        
        /// <remarks/>
        ORIGINAL,
        
        /// <remarks/>
        ADDITIONAL,
        
        /// <remarks/>
        FIXED,
        
        /// <remarks/>
        ADD_NO_REFERENCE,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class vat {
        
        /// <remarks/>
        public decimal rate;
        
        /// <remarks/>
        public rateType rateType;
        
        /// <remarks/>
        public decimal summaVat;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum rateType {
        
        /// <remarks/>
        DECIMAL,
        
        /// <remarks/>
        ZERO,
        
        /// <remarks/>
        NO_VAT,
        
        /// <remarks/>
        CALCULATED,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class rosterItem {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string number;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string code;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string code_oced;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string units;
        
        /// <remarks/>
        public decimal count;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool countSpecified;
        
        /// <remarks/>
        public decimal price;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceSpecified;
        
        /// <remarks/>
        public decimal cost;
        
        /// <remarks/>
        public decimal summaExcise;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool summaExciseSpecified;
        
        /// <remarks/>
        public vat vat;
        
        /// <remarks/>
        public decimal costVat;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("description", IsNullable=false)]
        public descriptionType[] descriptions;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum descriptionType {
        
        /// <remarks/>
        DEDUCTION_IN_FULL,
        
        /// <remarks/>
        VAT_EXEMPTION,
        
        /// <remarks/>
        OUTSIDE_RB,
        
        /// <remarks/>
        IMPORT_VAT,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class rosterList {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("rosterItem")]
        public rosterItem[] rosterItem;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalCostVat;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalExcise;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalVat;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal totalCost;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class document {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string typeDocument;
        
        /// <remarks/>
        public string customDocTypeValue;
        
        /// <remarks/>
        public string nameDocument;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime date;
        
        /// <remarks/>
        public string blankCode;
        
        /// <remarks/>
        public string seria;
        
        /// <remarks/>
        public string number;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class contract {
        
        /// <remarks/>
        public string number;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime date;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public document[] documents;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class deliveryCondition {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public contract[] contracts;
        
        /// <remarks/>
        public string description;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class consignee {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string countryCode;
        
        /// <remarks/>
        public string unp;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string address;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class consignor {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string countryCode;
        
        /// <remarks/>
        public string unp;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string address;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class senderReceiver {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public consignor[] consignors;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public consignee[] consignees;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class recipient {
        
        /// <remarks/>
        public recipientStatusType recipientStatus;
        
        /// <remarks/>
        public bool dependentPerson;
        
        /// <remarks/>
        public bool residentsOfOffshore;
        
        /// <remarks/>
        public bool specialDealGoods;
        
        /// <remarks/>
        public bool bigCompany;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string countryCode;
        
        /// <remarks/>
        public string unp;
        
        /// <remarks/>
        public string branchCode;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string address;
        
        /// <remarks/>
        public taxesType declaration;
        
        /// <remarks/>
        public taxesType taxes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateImport;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateImportSpecified;
        
        public recipient() {
            this.recipientStatus = recipientStatusType.CUSTOMER;
            this.dependentPerson = false;
            this.residentsOfOffshore = false;
            this.specialDealGoods = false;
            this.bigCompany = false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum recipientStatusType {
        
        /// <remarks/>
        CUSTOMER,
        
        /// <remarks/>
        CONSUMER,
        
        /// <remarks/>
        CONSIGNOR,
        
        /// <remarks/>
        COMMISSIONAIRE,
        
        /// <remarks/>
        TAX_DEDUCTION_RECIPIENT,
        
        /// <remarks/>
        FOREIGN_ORGANIZATION_BUYER,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class taxesType {
        
        /// <remarks/>
        public string number;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime date;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class forInvoiceType {
        
        /// <remarks/>
        public string number;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime date;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class provider {
        
        /// <remarks/>
        public providerStatusType providerStatus;
        
        /// <remarks/>
        public bool dependentPerson;
        
        /// <remarks/>
        public bool residentsOfOffshore;
        
        /// <remarks/>
        public bool specialDealGoods;
        
        /// <remarks/>
        public bool bigCompany;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string countryCode;
        
        /// <remarks/>
        public string unp;
        
        /// <remarks/>
        public string branchCode;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string address;
        
        /// <remarks/>
        public forInvoiceType principal;
        
        /// <remarks/>
        public forInvoiceType vendor;
        
        /// <remarks/>
        public taxesType declarations;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateRelease;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateReleaseSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateActualExport;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateActualExportSpecified;
        
        /// <remarks/>
        public taxesType taxes;
        
        public provider() {
            this.providerStatus = providerStatusType.SELLER;
            this.dependentPerson = false;
            this.residentsOfOffshore = false;
            this.specialDealGoods = false;
            this.bigCompany = false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum providerStatusType {
        
        /// <remarks/>
        SELLER,
        
        /// <remarks/>
        CONSIGNOR,
        
        /// <remarks/>
        COMMISSIONAIRE,
        
        /// <remarks/>
        TAX_DEDUCTION_PAYER,
        
        /// <remarks/>
        TRUSTEE,
        
        /// <remarks/>
        FOREIGN_ORGANIZATION,
        
        /// <remarks/>
        AGENT,
        
        /// <remarks/>
        DEVELOPER,
    }
}
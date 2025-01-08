using System.Xml.Serialization;

namespace Fourlane.CodeTest.XmlDeserialization.Models;

[XmlRoot(ElementName="CustomerRef")]
	public class CustomerRef 
	{
		[XmlElement(ElementName="ListID")]
		public string? ListId { get; set; }
		[XmlElement(ElementName="FullName")]
		public string? FullName { get; set; }
	}

	[XmlRoot(ElementName="ClassRef")]
	public class ClassRef 
	{
		[XmlElement(ElementName="ListID")]
		public string? ListId { get; set; }
		[XmlElement(ElementName="FullName")]
		public string? FullName { get; set; }
	}

	[XmlRoot(ElementName="ItemRef")]
	public class ItemRef 
	{
		[XmlElement(ElementName="ListID")]
		public string? ListId { get; set; }
		[XmlElement(ElementName="FullName")]
		public string? FullName { get; set; }
	}

	[XmlRoot(ElementName="OverrideUOMSetRef")]
	public class OverrideUomSetRef 
	{
		[XmlElement(ElementName="ListID")]
		public string? ListId { get; set; }
		[XmlElement(ElementName="FullName")]
		public string? FullName { get; set; }
	}

	[XmlRoot(ElementName="DataExtRet")]
	public class DataExtRet 
	{
		[XmlElement(ElementName="OwnerID")]
		public Guid? OwnerId { get; set; }
		[XmlElement(ElementName="DataExtName")]
		public required string DataExtName { get; set; }
		[XmlElement(ElementName="DataExtType")]
		public required DataExtTypeEnum DataExtType { get; set; }
		[XmlElement(ElementName="DataExtValue")]
		public required string DataExtValue { get; set; }
	}

	[XmlRoot(ElementName="InvoiceLineRet")]
	public class InvoiceLineRet 
	{
		[XmlElement(ElementName="TxnLineID")]
		public required string TxnLineId { get; set; }
		[XmlElement(ElementName="ItemRef")]
		public ItemRef? ItemRef { get; set; }
		[XmlElement(ElementName="Desc")]
		public string? Desc { get; set; }
		[XmlElement(ElementName="Quantity")]
		public decimal? Quantity { get; set; }
		[XmlElement(ElementName="UnitOfMeasure")]
		public string? UnitOfMeasure { get; set; }
		[XmlElement(ElementName="OverrideUOMSetRef")]
		public OverrideUomSetRef? OverrideUomSetRef { get; set; }
		[XmlElement(ElementName="Rate")]
		public decimal? Rate { get; set; }
		[XmlElement(ElementName="RatePercent")]
		public decimal? RatePercent { get; set; }
		[XmlElement(ElementName="ClassRef")]
		public ClassRef? ClassRef { get; set; }
		[XmlElement(ElementName="Amount")]
		public decimal? Amount { get; set; }
		[XmlElement(ElementName="Other1")]
		public string? Other1 { get; set; }
		[XmlElement(ElementName="Other2")]
		public string? Other2 { get; set; }
		[XmlElement(ElementName="DataExtRet")]
		public List<DataExtRet>? DataExtRet { get; set; }
		
		public bool ShouldSerializeRate() => Rate.HasValue && !RatePercent.HasValue; 
		
		public bool ShouldSerializeRatePercent() => RatePercent.HasValue;
	}

	[XmlRoot(ElementName="ItemGroupRef")]
	public class ItemGroupRef 
	{
		[XmlElement(ElementName="ListID")]
		public string? ListId { get; set; }
		[XmlElement(ElementName="FullName")]
		public string? FullName { get; set; }
	}

	[XmlRoot(ElementName="InvoiceLineGroupRet")]
	public class InvoiceLineGroupRet 
	{
		[XmlElement(ElementName="TxnLineID")]
		public required string TxnLineId { get; set; }
		[XmlElement(ElementName="ItemGroupRef")]
		public required ItemGroupRef ItemGroupRef { get; set; }
		[XmlElement(ElementName="Desc")]
		public string? Desc { get; set; }
		[XmlElement(ElementName="Quantity")]
		public decimal? Quantity { get; set; }
		[XmlElement(ElementName="UnitOfMeasure")]
		public string? UnitOfMeasure { get; set; }
		[XmlElement(ElementName="OverrideUOMSetRef")]
		public OverrideUomSetRef? OverrideUomSetRef { get; set; }
		[XmlElement(ElementName="IsPrintItemsInGroup")]
		public required bool IsPrintItemsInGroup { get; set; }
		[XmlElement(ElementName="TotalAmount")]
		public required decimal TotalAmount { get; set; }
		[XmlElement(ElementName="InvoiceLineRet")]
		public List<InvoiceLineRet>? InvoiceLineRet { get; set; }
		[XmlElement(ElementName="DataExtRet")]
		public List<DataExtRet>? DataExtRet { get; set; }
	}

	[XmlRoot(ElementName="InvoiceRet")]
	public class InvoiceRet 
	{
		[XmlElement(ElementName="TxnID")]
		public required string TxnId { get; set; }
		[XmlElement(ElementName="TimeCreated")]
		public required DateTime TimeCreated { get; set; }
		[XmlElement(ElementName="TimeModified")]
		public required DateTime TimeModified { get; set; }
		[XmlElement(ElementName="EditSequence")]
		public required string EditSequence { get; set; }
		[XmlElement(ElementName="TxnNumber")]
		public int? TxnNumber { get; set; }
		[XmlElement(ElementName="CustomerRef")]
		public required CustomerRef CustomerRef { get; set; }
		[XmlElement(ElementName="ClassRef")]
		public ClassRef? ClassRef { get; set; }
		[XmlElement(ElementName="InvoiceLineRet")]
		public InvoiceLineRet? InvoiceLineRet { get; set; }
		[XmlElement(ElementName="InvoiceLineGroupRet")]
		public InvoiceLineGroupRet? InvoiceLineGroupRet { get; set; }
		[XmlElement(ElementName="DataExtRet")]
		public List<DataExtRet>? DataExtRet { get; set; }
	}

	[XmlRoot(ElementName="InvoiceQueryRs")]
	public class InvoiceQueryRs 
	{
		[XmlElement(ElementName="InvoiceRet")]
		public List<InvoiceRet>? InvoiceRet { get; set; }
		[XmlAttribute(AttributeName="statusCode")]
		public required int StatusCode { get; set; }
		[XmlAttribute(AttributeName="statusSeverity")]
		public required string StatusSeverity { get; set; }
		[XmlAttribute(AttributeName="statusMessage")]
		public required string StatusMessage { get; set; }
		[XmlAttribute(AttributeName="retCount")]
		public required int RetCount { get; set; }
		[XmlAttribute(AttributeName="iteratorRemainingCount")]
		public required int IteratorRemainingCount { get; set; }
		[XmlAttribute(AttributeName="iteratorID")]
		public required Guid IteratorId { get; set; }
	}

    /// <summary>
    /// enum for DataExtType as specified in XML comments
    /// </summary>
	public enum DataExtTypeEnum
	{
		[XmlEnum("AMTTYPE")]
		AmtType, 
		[XmlEnum("DATETIMETYPE")]
		DateTimeType, 
		[XmlEnum("INTTYPE")]
		IntType,
		[XmlEnum("PERCENTTYPE")]
		PercentType, 
		[XmlEnum("PRICETYPE")]
		PriceType, 
		[XmlEnum("QUANTYPE")]
		QuanType,
		[XmlEnum("STR1024TYPE")]
		Str1024Type, 
		[XmlEnum("STR255TYPE")]
		Str255Type
	}
	
using System.Xml.Serialization;
using FluentAssertions;
using Fourlane.CodeTest.XmlDeserialization.Models;

namespace Fourlane.CodeTest.UnitTests;

public class XmlDeserializationTests
{
    [Fact] public void TestXmlDeserialization_WithAllOptionalFields_UsingRate_Success() 
    { 
        // Arrange
        // ensure file exists at specified location 
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(basePath, "Data", "SampleInput.xml");
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
      
        // Act
        var result = DeserializeXml<InvoiceQueryRs>(filePath); 
        
        // Assert
        result.Should().NotBeNull();
        // check that provided optional fields are present
        result.InvoiceRet?.FirstOrDefault()?.ClassRef?.Should().NotBeNull();
        result.InvoiceRet?.FirstOrDefault().Should().NotBeNull();
        // check that the XML uses Rate and not Rate Percent
        result.InvoiceRet?.FirstOrDefault()?.InvoiceLineRet?.Rate.Should().NotBeNull();
        result.InvoiceRet?.FirstOrDefault()?.InvoiceLineRet?.RatePercent.Should().BeNull();
        // verify enum successfully deserialized
        result.InvoiceRet?.FirstOrDefault()?.DataExtRet?.FirstOrDefault()?.DataExtType.Should().Be(DataExtTypeEnum.Str255Type);
    }
    
    [Fact] public void TestXmlDeserialization_WithoutOptionalFields_UsingRatePercent_Success() 
    { 
        // Arrange
        // ensure file exists at specified location 
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(basePath, "Data", "SampleInput_OptionalSections.xml");
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
      
        // Act
        var result = DeserializeXml<InvoiceQueryRs>(filePath); 
        
        // Assert
        result.Should().NotBeNull();
        // check that excluded optional fields are not present and included fields are present
        result.InvoiceRet?.FirstOrDefault()?.ClassRef?.Should().BeNull();
        result.InvoiceRet?.FirstOrDefault()?.InvoiceLineRet?.Other1?.Should().BeNull();
        result.InvoiceRet?.FirstOrDefault().Should().NotBeNull();
        // check that the XML uses Rate Percent and not Rate
        result.InvoiceRet?.FirstOrDefault()?.InvoiceLineRet?.Rate.Should().BeNull();
        result.InvoiceRet?.FirstOrDefault()?.InvoiceLineRet?.RatePercent.Should().NotBeNull();
        // verify enum successfully deserialized
        result.InvoiceRet?.FirstOrDefault()?.DataExtRet?.FirstOrDefault()?.DataExtType.Should().Be(DataExtTypeEnum.AmtType);
    }
    
    [Fact] public void TestXmlDeserialization_WithInvalidXml_ThrowsInvalidOperationException() 
    { 
        // Arrange
        // ensure file exists at specified location 
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(basePath, "Data", "SampleInvalidXml.xml");
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }
      
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => DeserializeXml<InvoiceQueryRs>(filePath)); 
    }

    // XML deserialization helper method
    private static T DeserializeXml<T>(string filePath)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StreamReader(filePath);
        var result = serializer.Deserialize(reader); 
        return result switch
        {
            T value => value, 
            _ => throw new InvalidOperationException("Failed to deserialize provided XML.")
        };
    }
}
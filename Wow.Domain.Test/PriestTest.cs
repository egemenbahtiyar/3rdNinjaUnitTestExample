using Wow.SharedKernel;
using Xunit;

namespace Wow.Domain.Test;

public class PriestTest
{
   
    public PriestTest()
    {
        
    }

    [Fact]
    public void Should_Have_Create_Priest()
    {
        // Arrange
         Priest _priest;
        // Act
        _priest = Priest.CreatePriest("beko", 100);
        // Assert
        Assert.Equal(100,_priest.Mana);
        Assert.Equal("beko", _priest.Name);
        
    }

    [Fact]
    public void Should_Have_Thrown_DomainException_When_CharName_IsNull()
    {
        // Arrange
        Priest _priest;
        // Assert && Actvar 
        var message =Assert.Throws<DomainException>(() =>
        {
            _priest = Priest.CreatePriest(null, 100);
        });
        Assert.Equal("Name should not be null!",  message.Message);
    }

    [Fact]
    public void Should_Have_Resurrection_Friend()
    {
        // Arrange
        Priest _priest;
        // Act
        _priest = Priest.CreatePriest("beko", 100);
        _priest.CastResurrection(50);
        // Assert
        Assert.Equal(50,_priest.Mana);
    }
    
    [Fact]
    public void Should_Have_ThrownBusinessRuleViolation_When_CastResurrection_OnFriend()
    {
        // Arrange
        Priest _priest;
        // Act
        _priest = Priest.CreatePriest("beko", 20);

        Assert.Throws<BusinessRuleViolationException>(() =>
        {
            _priest.CastResurrection(50);
        });
    }
}
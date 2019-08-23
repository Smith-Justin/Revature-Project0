using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    public class CrustTests
    {
        [Fact]
        public void Test_Info()
        {
        //Given
        string expectedName = "test";
        decimal expectedPrice = 20;
        
        Crust testCrust = new Crust(expectedName, expectedPrice);


        //When
        string actualName = testCrust.Name;
        decimal actualPrice = testCrust.Price;

        //Then
        Assert.True(expectedName == actualName);
        Assert.True(expectedPrice == actualPrice);
        }
    }
}
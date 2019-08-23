using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    public class SizeTests
    {
        [Fact]
        public void Test_Info()
        {
        //Given
        string expectedName = "test";
        decimal expectedPrice = 20;
        
        Size testSize = new Size(expectedName, expectedPrice);


        //When
        string actualName = testSize.Name;
        decimal actualPrice = testSize.Price;

        //Then
        Assert.True(expectedName == actualName);
        Assert.True(expectedPrice == actualPrice);
        }
    }
}
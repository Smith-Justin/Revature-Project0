using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    public class ToppingTests
    {
        [Fact]
        public void Test_Info()
        {
        //Given
        string expectedName = "test";
        decimal expectedPrice = 20;
        
        Topping testTopping = new Topping(expectedName, expectedPrice);


        //When
        string actualName = testTopping.Name;
        decimal actualPrice = testTopping.Price;

        //Then
        Assert.True(expectedName == actualName);
        Assert.True(expectedPrice == actualPrice);
        }
    }
}
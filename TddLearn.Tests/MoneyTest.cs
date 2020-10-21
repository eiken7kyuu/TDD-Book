using System;
using System.Collections.Generic;
using Xunit;
using TddLearn;


namespace TddLearn.Tests
{
    public class MoneyTest
    {
        [Fact]
        public void testMultiplication()
        {
            var five = new Dollar(5);
            five.Times(2);
            Assert.Equal(10, five.Amount);
        }
    }
}
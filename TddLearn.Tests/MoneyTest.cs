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
            Assert.Equal(new Dollar(10), five.Times(2));
            Assert.Equal(new Dollar(15), five.Times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));
            Assert.False(new Dollar(5).Equals(new Dollar(6)));
            Assert.True(new Franc(5).Equals(new Franc(5)));
            Assert.False(new Franc(5).Equals(new Franc(6)));
            Assert.False(new Franc(5).Equals(new Dollar(5)));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            var five = new Franc(5);
            Assert.Equal(new Franc(10), five.Times(2));
            Assert.Equal(new Franc(15), five.Times(3));
        }
    }
}
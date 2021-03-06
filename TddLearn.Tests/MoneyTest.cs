using System;
using Xunit;
using TddLearn;


namespace TddLearn.Tests
{
    public class MoneyTest
    {
        private readonly Expression _fiveBucks;
        private readonly Expression _tenFrancs;
        private readonly Bank _bank;

        public MoneyTest()
        {
            _fiveBucks = Money.Dollar(5);
            _tenFrancs = Money.Franc(10);
            _bank = new Bank();
            _bank.AddRate("CHF", "USD", 2); // 為替レート
        }

        [Fact]
        public void testMultiplication()
        {
            Money five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void testCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void testSimpleAddtion()
        {
            Money five = Money.Dollar(5);
            Expression sum = five.Plus(five);

            // 為替レートを適用してそのレート換算にする レート換算処理は銀行の責務とする
            Money reduced = _bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(10), reduced);
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            Money five = Money.Dollar(5);
            Expression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void testReduceSum()
        {
            Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Money result = _bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7), result);
        }

        [Fact]
        public void testReduceMoney()
        {
            Money result = _bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }


        [Fact]
        public void testReduceMoneyDifferentCurrency()
        {
            Money result = _bank.Reduce(Money.Franc(2), "USD");
            Assert.Equal(Money.Dollar(1), result);
        }

        [Fact]
        public void testIndetityRate()
        {
            Assert.Equal(1, new Bank().Rate("USD", "USD"));
        }

        [Fact]
        public void testMixedAddtion()
        {
            Money result = _bank.Reduce(_fiveBucks.Plus(_tenFrancs), "USD");
            Assert.Equal(Money.Dollar(10), result);
        }

        [Fact]
        public void testSumPlusMoney()
        {
            Expression sum = new Sum(_fiveBucks, _tenFrancs).Plus(_fiveBucks);
            Money result = _bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(15), result);
        }

        [Fact]
        public void testSumTimes()
        {
            Expression sum = new Sum(_fiveBucks, _tenFrancs).Times(2);
            Assert.Equal(Money.Dollar(20), sum.Reduce(_bank, "USD"));
        }
    }
}
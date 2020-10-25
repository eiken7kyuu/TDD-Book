using System;

namespace TddLearn
{
    public class Money : Expression
    {
        protected internal int Amount { get; }

        public string Currency { get; }

        public Money(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return Amount == money.Amount
                && Currency == money.Currency;
        }

        public Expression Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        public Expression Plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount / rate, to);
        }
    }
}
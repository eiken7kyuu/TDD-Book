using System;

namespace TddLearn
{
    public abstract class Money
    {
        protected internal int Amount { get; }

        public string Currency { get; }

        public abstract Money Times(int multiplier);

        public Money(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return Amount == money.Amount
                && this.GetType() == money.GetType();
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }
    }
}
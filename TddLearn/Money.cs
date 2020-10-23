using System;

namespace TddLearn
{
    public abstract class Money
    {
        protected internal int amount { get; set; }

        public abstract Money Times(int multiplier);

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return amount == money.amount
                && this.GetType() == money.GetType();
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }
    }
}
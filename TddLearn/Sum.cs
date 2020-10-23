using System;
using System.Collections.Generic;

namespace TddLearn
{
    public class Sum : Expression
    {
        public Money Augend { get; }
        public Money Addend { get; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(string to)
        {
            return new Money(Augend.Amount + Addend.Amount, to);
        }
    }
}
using System;
using System.Collections.Generic;

namespace TddLearn
{
    public class Sum : Expression
    {
        public Expression Augend { get; }
        public Expression Addend { get; }

        public Sum(Expression augend, Expression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            return new Money(
                Augend.Reduce(bank, to).Amount +
                Addend.Reduce(bank, to).Amount, to);
        }

        public Expression Plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public Expression Times(int multiplier)
        {
            return new Sum(Augend.Times(multiplier), Addend.Times(multiplier));
        }
    }
}
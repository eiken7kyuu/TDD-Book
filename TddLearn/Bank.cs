

using System;

namespace TddLearn
{
    public class Bank
    {
        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(to);
        }
    }
}
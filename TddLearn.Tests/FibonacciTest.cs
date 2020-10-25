using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TddLearn.Tests
{
    public class FibonacciTest
    {
        int Fib(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(6, 8)]
        public void TestFibonacci(int n, int result)
        {
            Assert.Equal(result, Fib(n));
        }

    }
}
using System;
using CalculatorApp;
using Xunit;



namespace TestProject2
{
    public class CalcTest
    {
        [Theory]
        [InlineData(0, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MinValue)]
        [InlineData(5, 0, 5)]
        [InlineData(1, int.MaxValue -1, int.MaxValue)]
        [InlineData(-1, int.MinValue + 1, int.MinValue)]
        public void Test1(int initial, int x, int expected)
        {

            ICalculator c = new Calc();

            c.Add(initial);
            c.Add(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Add_Overflow_Expect_OverFlowException()
        {
            ICalculator c = new Calc();
            c.Add(1);

            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Add(int.MaxValue);
            });

            Assert.True(e.Message == "Overflow by addition");
        }
        
        
        [Fact]
        public void Add_Underflow_Expect_OverFlowException()
        {
            ICalculator c = new Calc();
            c.Add(-1);

            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Add(int.MinValue);
            });

            Assert.True(e.Message == "Underflow by addition");
        }

        [Theory]
        [InlineData(int.MaxValue, int.MinValue, 1)]
        [InlineData(int.MaxValue, -int.MaxValue, 0)]
        [InlineData(2, -2, 0)]
        public void SubtractTest(int initial, int x, int expected)
        {
            ICalculator c = new Calc();
            c.Subtract(initial);
            c.Subtract(x);
            Assert.Equal(expected, c.Result);

        }
        
        
        [Fact]
        public void Subtract_Overflow_Expect_OverFlowException()
        {
            ICalculator c = new Calc();
            c.Subtract(1);

            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Subtract(int.MinValue);
            });

            Assert.True(e.Message == "Overflow by subtraction");
        }

        
        
        
    }
}
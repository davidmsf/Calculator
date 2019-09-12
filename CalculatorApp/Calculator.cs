using System;
using CalculatorApp;

namespace CalculatorApp
{
    public class Calc : ICalculator
    {
        private int _result;
        
        int ICalculator.Result => _result;

        public void Reset()
        {
            _result = 0;
        }

        public void Add(int x)
        {
            if (x > 0 && (_result + x) < _result)
            {
                throw new OverflowException("Overflow by addition");
            }
            
            if (x < 0 && (_result + x) > _result)
            {
                throw new OverflowException("Underflow by addition");
            }
            _result += x;
        }

        public void Subtract(int x)
        {
            if (x < 0 && (_result - x) < _result)
            {
                throw new OverflowException("Overflow by subtraction");
            }
            _result -= x;
        }

        public void Multiply(int x)
        {
            throw new System.NotImplementedException();
        }

        public void Divide(int x)
        {
            throw new System.NotImplementedException();
        }

        public void Modulus(int x)
        {
            throw new System.NotImplementedException();
        }
    }
}
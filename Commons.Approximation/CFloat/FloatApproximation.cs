using System;
using System.Collections.Generic;

namespace Commons.Approximation.CFloat
{
    public class FloatApproximation
    {
        private readonly float _tolerance;
        
        internal FloatApproximation(float tolerance)
        {
            _tolerance = tolerance;
        }
        
        public IEqualityComparer<float> GetEqualityComparer()
        {
            return new FloatEqualityComparer(this);
        }
        
        public bool EqualTo(float a, float b)
        {
            return Math.Abs(a - b) <= _tolerance;
        }
		
        public bool LessOrEqualTo(float a, float b)
        {
            return a < b || EqualTo(a, b);
        }
		
        public bool MoreOrEqualTo(float a, float b)
        {
            return a > b || EqualTo(a, b);
        }
    }
}
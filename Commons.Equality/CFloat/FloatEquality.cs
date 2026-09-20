using System;
using System.Collections.Generic;

namespace Commons.Equality.CFloat
{
    public class FloatEquality
    {
        private readonly float _tolerance;
        
        internal FloatEquality(float tolerance)
        {
            _tolerance = tolerance;
        }
        
        public IEqualityComparer<float> GetComparer()
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
        
        // TODO: add SequenceEqual
    }
}
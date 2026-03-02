using System;
using Commons.Equality.CFloat;
using Commons.Equality.CVector2;
using Commons.Equality.CVector3;

namespace Commons.Equality
{
    public class Equality
    {
        public FloatEquality Float { get; }
        public Vector2Equality Vector2 { get; }
        public Vector3Equality Vector3 { get; }
        
        public Equality(float tolerance)
        {
            if (!float.IsFinite(tolerance) || float.IsNegative(tolerance)) 
                throw new ArithmeticException($"'{nameof(tolerance)}' should be finite and positive.");
            Float = new FloatEquality(tolerance);
            Vector2 = new Vector2Equality(Float);
            Vector3 = new Vector3Equality(Float);
        }
    }
}
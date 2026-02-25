using System;
using Commons.Approximation.CFloat;
using Commons.Approximation.CVector2;
using Commons.Approximation.CVector3;

namespace Commons.Approximation
{
    public class Approximation
    {
        public FloatApproximation Float { get; }
        public Vector2Approximation Vector2 { get; }
        public Vector3Approximation Vector3 { get; }
        
        public Approximation(float tolerance)
        {
            if (!float.IsFinite(tolerance) || float.IsNegative(tolerance)) 
                throw new ArithmeticException($"'{nameof(tolerance)}' should be finite and positive.");
            Float = new FloatApproximation(tolerance);
            Vector2 = new Vector2Approximation(Float);
            Vector3 = new Vector3Approximation(Float);
        }
    }
}
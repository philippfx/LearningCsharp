using System.Security.Cryptography;

namespace BAL.Classes
{
    public class Rectangle : IRectangle
    {
        private const double PiConst = 3.143;
        private readonly double PiReadOnly;

        public Rectangle()
        {
            PiReadOnly = 3.143134;
        }

        public double SideLengthA;
        public double SideLengthB;

        public virtual double GetArea()
        {
            return SideLengthA * SideLengthB;
        }

        // Accessable withing child classes
        protected double GetProtectedCircumReference()
        {
            return 2 * (SideLengthA + SideLengthB);
        }

        // Accessable within same assembly (project)
        internal double GetInternalCircumReference()
        {
            return 2 * (SideLengthA + SideLengthB);
        }

        // Accessable withing child classes and same assembly (project)
        protected internal double GetProtectedInternalCircumReference()
        {
            return 2 * (SideLengthA + SideLengthB);
        }

        // Ref and Out
        public void GetCircumReference(ref double refCircumReference, out double outCircumReference)
        {
            refCircumReference = 2 * (SideLengthA + SideLengthB);
            outCircumReference = 2 * (SideLengthA + SideLengthB);
        }

    }
}

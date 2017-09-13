using System;
using System.Collections.Generic;
using System.Text;
using BAL.Classes;

namespace LearningCsharp.PresentationClass
{
    public class Square : Rectangle
    {
        // Data Encapsulation
        private int sideLength;
        public int SideLength { get => sideLength; set => sideLength = value; }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }

        // Hiding method of base class
        protected new double GetCircumReference()
        {
            var protectedCR = base.GetProtectedCircumReference();
            var protectedInternal = base.GetProtectedInternalCircumReference();
            //var internalCR = base.GetInternalCircumReference();

            return protectedCR;
        }

        private void PrivateVirtualMethod()
        //private virtual void PrivateVirtualMethod()
        {
            Console.WriteLine("PrivateVirtualMethod");
        }
    }
}

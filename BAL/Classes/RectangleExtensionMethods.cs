using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Classes
{
    class RectangleExtensionMethods
    {
        public bool IsRectangleASquare()
        {
            var rectangle = new Rectangle()
            {
                SideLengthA = 5,
                SideLengthB = 5
            };

            //var protectedCR = rectangle.GetProtectedCircumReference();
            var protectedInternalCR = rectangle.GetProtectedInternalCircumReference();
            var internalCR = rectangle.GetInternalCircumReference();

            bool isRectangleASquare = rectangle.SideLengthA == rectangle.SideLengthB ? true : false;

            return isRectangleASquare;
        }

    }
}

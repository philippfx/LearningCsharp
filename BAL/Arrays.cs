using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class Arrays
    {
        public void CompareArrays()
        {
            int[] marks = new int[] { 99, 98, 92, 97, 95 };
            int[] score = marks; // This copies the array and score and marks are references to same array!

            //score[0] = 5;

            int[] numbers = new int[] { 99, 98, 92, 97, 95 };

            bool isEqualMarks = marks == score; // true
            bool isEqualMarksToo = marks.Equals(score); // true

            // For Arrays it only compares references, no matter == or .Equals() 
            bool isEqualNumbers = numbers == marks; // false
            bool isEqualNumbersToo = numbers.Equals(marks); // false
            bool isEqual = marks.SequenceEqual(score); // true
        }

        public void CopyCloneArray()
        {
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[6];
            int[] array3 = new int[10];
            
            array1.CopyTo(array3,3); // copies to existing array, copy array 1 into array3 at index 3

            array2 = (int[])array1.Clone(); // creates completey new array, cast is important because .Clone() creates object

        }
    }
}

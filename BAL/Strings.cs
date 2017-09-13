using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class Strings
    {
        public void TestStringBuilder()
        {
            var TestBuilder = new StringBuilder("Hello");
            TestBuilder.Remove(2, 3); // result - "He"
            TestBuilder.Insert(2, "lp"); // result - "Help"
            TestBuilder.Replace('l', 'a'); // result - "Heap"

            var TestBuilder2 = TestBuilder;

            var isEqual = TestBuilder == TestBuilder2; // true
            var isEqualToo = TestBuilder.Equals(TestBuilder2); // true

            //////////////////

            var TestBuilder3 = new StringBuilder("Hello");
            var TestBuilder4 = new StringBuilder("Hello");

            var isEqual3 = TestBuilder3 == TestBuilder4; // false
            var isEqualToo3 = TestBuilder3.Equals(TestBuilder4); // true

            var TestBuilder5 = TestBuilder3;
            var TestBuilder6 = TestBuilder3;

            var isEqual5 = TestBuilder5 == TestBuilder6; // true
            var isEqualToo5 = TestBuilder5.Equals(TestBuilder6); //true
        }

        public void TestStrings()
        {
            // string is reference type that behaves like value type
            string string1 = "test";
            string string2 = "test";
            var isEqual = string1 == string2; // true because it's overloaded
            var isEqualToo = string1.Equals(string2); // true

            string string3 = string1;
            string string4 = string1;
            var isEqual3 = string3 == string4; // true
            var isEqualToo3 = string3.Equals(string4); // true

            string string5 = string1;
            string string6 = string4;
            var isEqual5 = string5 == string4; // true
            var isEqualToo6 = string6.Equals(string4); // true

            ////////////////////

            string name = "sandeep";
            string myName = name;
            var string7 = name == myName; // true
            var string8 = name.Equals(myName); // true

            object name2 = "sandeep";
            char[] values2 = { 's', 'a', 'n', 'd', 'e', 'e', 'p' };
            object myName2 = new string(values2);
            var string9 = name2 == myName2; // false
            var string10 = name2.Equals(myName2); // true
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using BAL;
using BAL.Classes;
using LearningCsharp.PresentationClass;

// Includes System namespace. Namespace is a container of classes

namespace LearningCsharp
{
    public class SecondClass
    {
        public SecondClass(string car)
        {
            Car = car;
        }

        public string Car { get; set; }

        protected bool Equals(SecondClass other)
        {
            return string.Equals(Car, other.Car);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SecondClass) obj);
        }

        public override int GetHashCode()
        {
            return (Car != null ? Car.GetHashCode() : 0);
        }
    }
    public class MyClass
    {
        public MyClass(string name)
        {
            Name = name;
            SecondClass = new SecondClass("Audi");
        }

        public string Name { get; set; }
        public SecondClass SecondClass { get; set; }

        protected bool Equals(MyClass other)
        {
            return string.Equals(Name, other.Name) && Equals(SecondClass, other.SecondClass);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (SecondClass != null ? SecondClass.GetHashCode() : 0);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string myString = "";
            //var variable = "hello";
            //var stopWatch = new Stopwatch();
            //stopWatch.Start();

            ////AsynchronousNumbers.MultipleAsyncMethodsWithCombinators();

            //var asyncNumberTest = new AsynchronousNumbers();
            //var listResult = asyncNumberTest.GetNumbers(1);

            //var t = stopWatch.Elapsed;
            //foreach (var number in listResult)
            //{
            //    Console.WriteLine(number);
            //}

            //Console.Write(stopWatch.Elapsed);
            //Console.Read();



            //// Reference Type Equality
            //var x1 = new MyClass("Philipp");
            //var x2 = new MyClass("Philipp");

            //Console.WriteLine("{0}", x1 == x2);
            //Console.WriteLine("{0}", x1.Equals(x2));

            //var l1 = new List<string>() { "Test1", "Test2" };
            //var l2 = new List<string>() { "Test1", "Test2" };
            //Console.WriteLine("{0}", l1 == l2);
            //Console.WriteLine("{0}", l1.Equals(l2));

            //Console.Read();

            //// Events and Delegates
            
            // Void WithInput and custom delegate
            //var voidWithInput = new EventsAndDelegatesVoidWithInput();
            //voidWithInput.Run();

            //// Void WithInput and C# delegate custom EventArgs
            //var voidWithInputCdelegate = new EventsAndDelegatesVoidWithInputStandardConventionNET();
            //voidWithInputCdelegate.Run();

            //// Void WithInput, C# delegate custom EventArgs and Anonymous Methods
            //var eventArgsAnonymousTypes = new EventsAndDelegatesVoidWithStandardConventionNETAnonymousMethods();
            //eventArgsAnonymousTypes.Run();

            // Action<T>
            var actionT = new EventsAndDelegatesAction();
            actionT.Run();

            // ReturnValue WithInput
            var returnValueWithInput = new EventsAndDelegatesReturnValueWithInput();
            returnValueWithInput.Run();

            

            //var eventsAndDelegates = new EventsAndDelegates();
            //eventsAndDelegates.Run();

            // Void noParams
            //var simpleEventsAndDelegatesNoInputParams = new EventsAndDelagtesNoInputParams();
            //simpleEventsAndDelegatesNoInputParams.MainRun();

            var simpleEventsAndDelagtesWithInputParams = new EventsAndDelagtesWithInputParams();
            simpleEventsAndDelagtesWithInputParams.OnSomethingIsDone();


            Console.Read();

            ////////// Generics //////////

            // Inefficient, because code is not reuseable and requires boxing / unboxing!
            var employee0 = new Employee("Philipp", "Seifert", 28);
            var employee1 = new Employee("Hans", "Zimmer", 54);

            var employeeCollection = new EmployeesCollection();
            employeeCollection.AddEmployee(employee0);
            employeeCollection.AddEmployee(employee1);

            var employeeFromArray1 = employeeCollection.GetEmployee(1);

            // Better are generics!
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.Add(new Employee("Philipp", "Seifert", 28));
            listEmployees.Add(new Employee("Hans", "Zimmer", 54));

            // Even better generics
            MyGenericClass<int> c1 = new MyGenericClass<int>(5, 10, 15);
            c1.ResetValues();

            MyGenericClass<string> c2 = new MyGenericClass<string>("a", "b", "c");
            c2.ResetValues();



            ////////// Arrays //////////
            var arrays = new Arrays();
            arrays.CompareArrays();
            arrays.CopyCloneArray();





            ////////// Strings //////////
            var strings = new Strings();
            strings.TestStringBuilder();
            strings.TestStrings();

            ////////// REF and OUT //////////
            double refCircumReference = 0; // MUST BE intialized
            double outCircumReference;

            var RectangleRefOut = new Rectangle()
            {
                SideLengthA = 5,
                SideLengthB = 5
            };

            RectangleRefOut.GetCircumReference(ref refCircumReference, out outCircumReference);


            


            ////////// Exceptions //////////
            var myExceptionClass = new Exceptions();
            myExceptionClass.MainMethod();


            

        }
    }
}
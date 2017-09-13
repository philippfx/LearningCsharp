using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    interface IVariantNoConstraint<R, A>
    {
        R GetSomething();
        void SetSomething(A sampleArg);
        R GetSetSometings(A sampleArg);
        A GetSomethingWrong(R sampleArg);
    }

    interface IVariant<out R, in A>
    {
        R GetSomething();
        void SetSomething(A sampleArg);
        R GetSetSometings(A sampleArg);

        // Compiler Error
        // A GetSomethingWrong(R sampleArg);
    }

    public class CoContraVariants : IVariant<string, string>
    {
        public string GetSomething()
        {
            throw new NotImplementedException();
        }

        public void SetSomething(string sampleArg)
        {
            throw new NotImplementedException();
        }

        public string GetSetSometings(string sampleArg)
        {
            throw new NotImplementedException();
        }
    }

    public class RunMe
    {
        public void Run()
        {
            CoContraVariants instance = new CoContraVariants();
            
        }
    }

    
    //////////////////

    public interface IOurTemplate<T, U>
        where T : class
        where U : class
    {
        IEnumerable<T> List();
        T Get(U id);
    }

    public class OurClass<T, U> : IOurTemplate<T, U>
        where T : class
        where U : class
    {
        public IEnumerable<T> List()
        {
            yield return default(T); // put implementation here
        }

        public T Get(U id)
        {

            return default(T); // put implementation here
        }
    }

    public class OurConcreteClass : IOurTemplate<string, string>
    {
        public IEnumerable<string> List()
        {
            yield return "Some String"; // put implementation here
        }

        public string Get(string id)
        {

            return id; // put implementation here
        }
    }
}

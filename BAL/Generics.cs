using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class Generics
    {
    }

    public class Employee
    {
        string FirstName;
        string LastName;
        int Age;

        public Employee() { }
        public Employee(string fName, string lName, int Age)
        {
            this.Age = Age;
            this.FirstName = fName;
            this.LastName = lName;
        }
        //public override string ToString()
        //{
        //    return String.Format("{0} {1} is {2} years old", FirstName, LastName, Age);
        //}
    }

    public class EmployeesCollection : IEnumerable
    {
        private List<Employee> allEmployees = new List<Employee>();
        public EmployeesCollection() { }

        //Insert Employee type
        public void AddEmployee(Employee e)
        {
            //boxing
            allEmployees.Add(e);
        }

        //get the employee type
        public Employee GetEmployee(int index)
        {
            //unboxing
            return (Employee)allEmployees[index];
        }

        //to use foreach
        IEnumerator IEnumerable.GetEnumerator()
        {
            return allEmployees.GetEnumerator();
        }
    }

    public class MyGenericClass<T>
    {
        //Generic variables
        private T d1;
        private T d2;
        private T d3;

        public MyGenericClass() { }

        //Generic constructor  
        public MyGenericClass(T a1, T a2, T a3)
        {
            d1 = a1;
            d2 = a2;
            d3 = a3;
        }

        //Generic properties
        public T D1
        {
            get { return d1; }
            set { d1 = value; }
        }

        public T D2
        {
            get { return d2; }
            set { d2 = value; }
        }

        public T D3
        {
            get { return d3; }
            set { d3 = value; }
        }

        public void ResetValues()
        {
            d1 = default(T);
            d2 = default(T);
            d3 = default(T);
        }
    }


}

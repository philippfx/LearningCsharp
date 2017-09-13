using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BAL
{
    public class Exceptions
    {
        public void ThrowMethod()
        {
            Exceptions p = new Exceptions();
            try
            {
                p.ExceptionMethod();
            }
            catch (Exception ex)
            {
                // Keeps stack trace
                throw;
            }
        }

        public void ThrowExMethod()
        {
            Exceptions p = new Exceptions();
            try
            {
                p.ExceptionMethod();
            }
            catch (Exception ex)
            {
                // Resets stack trace
                throw ex;
            }
        }


        public void ExceptionMethod()
        {
            throw new Exception("Original Exception occurred in ExceptionMethod");
        }

        public void MainMethod()
        {
            Exceptions p = new Exceptions();
            try
            {
                p.ThrowMethod(); // Stack Trace says exception thrown at ExceptionMethod() CORRECT
                p.ThrowExMethod(); // Stack Trace says exception thrown at ThrowMethod()
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("This is written after Exception was thrown");
            }

            p.ThrowMethod();
            
        }
    }
}

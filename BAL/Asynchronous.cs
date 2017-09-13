using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAL
{
    public class AsynchronousNumbers
    {
        private int result1, result2, result3, result4, result5, result6 = 0;

        public Task<int> GetMultiple2Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 1;
                Thread.Sleep(input * 2000);
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 1000);
                Console.WriteLine("End Task " + input);
                return input * 2;
            });
        }

        public Task<int> GetMutliple3Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 2;
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 1000);
                Console.WriteLine("End Task " + input);
                return input * 3;
            });
        }

        public Task<int> GetMultiple4Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 3;
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 1000);
                Console.WriteLine("End Task " + input);
                return input * 4;
            });
        }

        public Task<int> GetMultiple5Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 4;
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 1000);
                Console.WriteLine("End Task " + input);
                return input * 5;
            });
        }

        public Task<int> GetMultiple6Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 5;
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 100);
                Console.WriteLine("End Task " + input);
                return input * 6;
            });
        }

        public Task<int> GetMultiple7Number(int input)
        {
            return Task.Run<int>(() =>
            {
                input += 6;
                Console.WriteLine("Begin Task " + input);
                Thread.Sleep(input * 100);
                Console.WriteLine("End Task " + input);
                return input * 7;
            });
        }

        List<int> listNumbers;
        public void GetNumbersAsynchronously(int input)
        {

            Task<int> t1 = GetMultiple2Number(input);

            Task<int> t2 = GetMutliple3Number(input);

            Task<int> t3 = GetMultiple4Number(input);

            Task<int> t4 = GetMultiple5Number(input);

            Task<int> t5 = GetMultiple6Number(input);

            Task<int> t6 = GetMultiple7Number(input);

            listNumbers = new List<int>() { t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result};
        }

        public List<int> GetNumbers(int input)
        {
            GetNumbersAsynchronously(input);
            return listNumbers;
        }


        ////////////////////////////////

        static string Greeting(string name)
        {
            Thread.Sleep(3000);

            return string.Format("Hello, {0}", name);
        }

        static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                return Greeting(name);
            });
        }
        
    }
}

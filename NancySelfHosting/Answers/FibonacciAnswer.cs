using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NancySelfHosting.Answers
{
    public class FibonacciAnswer: IAnswer
    {

        private int[] _parameters;

        public FibonacciAnswer(string parameters)
        {
            _parameters = JsonConvert.DeserializeObject<int[]>(parameters);
        }

        public string GetAnswer()
        {
            return GetNthFibonacciNumber(_parameters[0]).ToString();
        }



        // Q1)
        //
        // Return the Nth Fibonacci number in the sequence
        //
        // Input: uint n (which number to get)
        // Output: The nth fibonacci number
        //

        public static int GetNthFibonacciNumber(int z)
        {

            // Return the nth fibonacci number based on n.
            int n = 0;

            if (z == 0 || z == 1)
            {
                return 1;
            }

            // The basic Fibonacci sequence is 
            // 1, 1, 2, 3, 5, 8, 13, 21, 34...
            // f(0) = 1
            // f(1) = 1
            // f(n) = f(n-1) + f(n-2)
            ///////////////
            //my code is below this comment

            int a = 0;
            int b = 1;

            for (int i = 0; i < z; i++)
            {
                n = b + a;
                a = b;
                b = n;
            }
            return n;

        }
    }
}

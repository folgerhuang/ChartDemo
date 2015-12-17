using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MathWorks.MATLAB.NET.Arrays;

using MathWorks.MATLAB.NET.Utility;
using myplus;

namespace MatlabTest
{
    class Program 
    {
      
        static void Main(string[] args)
        {
            Class1 myplus = new Class1();

            MWArray i = 3;
            MWArray result;

            result = myplus.myplus(i);

            Console.WriteLine("Mathlab test:result:" + result);
            
        
            Console.ReadKey();
        }

      
    }
}

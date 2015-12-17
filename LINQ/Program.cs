using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] strArray = { "Sxdlsi", "SeYU", "3sdsfseE" };
            var ChangeWord = from word in strArray
                             select new { Upper = word.ToUpper(), Lower = word.ToLower() };
            foreach (var word in ChangeWord)
            {
                Console.WriteLine("Uper:{0},Lower:{1}", word.Upper, word.Lower);
            }
            Console.ReadKey();
             */

            /*
            string[] strLists = new string[] { "C#经典实例教程", "C#宝典", "C语言程序开发" };
            string[] strList = Array.FindAll(strLists,S=>(S.IndexOf("C#")>=0));
            foreach (string str in strList)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();*/

            /*
            string[] strLists = new string[] { "C#经典实例教程", "C#宝典", "C语言程序开发" };
            IEnumerable<string> strList = from str in strLists
                                          where str.Length < 6
                                          select str;
            foreach(string str in strList)
            {
                Console.WriteLine(str);
            }
             */

            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> intA = from i in intArray
                         where (i % 2) == 0 && i > 2
                         orderby i descending
                         select i;
            foreach (int i in intA)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}

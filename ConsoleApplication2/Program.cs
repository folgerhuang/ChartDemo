using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Car
    {
        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        private string _doors;

        public string Doors
        {
            get { return _doors; }
            set { _doors = value; }
        }
        public int Go()
        {
            int speedMhp = 100;
            return speedMhp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            bool b = false;

            var tern = x > 10 ? b = true : b = false;


            if ( x> 10 ) {
                b = true;
            }
            else
            {
                b = false;
            }

        }
    }
}

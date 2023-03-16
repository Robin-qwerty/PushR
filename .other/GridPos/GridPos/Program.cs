using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridPos
{
    public class Program
    {
        public static List<int> Mylist { get; set; }
        static int Cols;
        static int Rows;

        static void Main(string[] args)
        {
            Mylist = new List<int>();

            Cols = 10;
            Rows = 10;

            for (int i = 0; i < Cols*Rows; i++)
            {
                Mylist.Add(i);
            }

            //var result = GridPosition(101);

            //Console.WriteLine("row = {0}, col = {1}", result[0], result[1]);

            DriehoekBerekenen(3, 4);

            Console.ReadLine();
        }

        static int[] GridPosition(int num)
        {
            int[] arr = new int[2];

            arr[0] = num / Cols;
            arr[1] = num % Cols;

            return arr;
        }

        static int DriehoekBerekenen(int a, int b)
        {
            int c = (a*a)+(b*b);

            return c;
        }
    }
}

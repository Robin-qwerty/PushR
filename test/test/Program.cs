using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Model> list2 = new List<Model>();

            List<Model> list = new List<Model>
            {
                new Model
                {
                    Id= 1,
                    Name = "paul"
                },
                new Model
                {
                    Id= 2,
                    Name = "Piet"
                },
                new Model
                {
                    Id= 3,
                    Name = "Anna"
                },
                new Model
                {
                    Id= 4,
                    Name = "Jan"
                },
                new Model
                {
                    Id= 5,
                    Name = "Tim"
                }
            };

            var v = SortedList(list, 7);

            Console.WriteLine(v);
            Console.ReadLine();
        }

        public static List<Model> SortedList(List<Model> list, int Id)
        {
            List<Model> l = new List<Model>();

            try
            {
                var v = list.Where(x => x.Id == Id).First();

                l.Add(v);
                list.Remove(v);

                foreach (var item in list)
                {
                    l.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            return l;
        }
    }
}

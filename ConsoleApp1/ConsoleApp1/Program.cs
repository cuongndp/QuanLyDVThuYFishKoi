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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int[] t31 = { 1, 3, 5, 7, 8, 10, 12 };
            int[] t30 = { 4, 6, 9, 11 };
            int thang = int.Parse(Console.ReadLine());
            foreach (int i in t31)
            {
                if (thang == i)
                    Console.WriteLine("31 ngay");
            }
            foreach (int i in t30)
            {
                if (thang == i)
                    Console.WriteLine("30 ngay");
            }
            if (thang == 2)
                Console.WriteLine("thang 28");
            Console.ReadKey();
        }
    }
}

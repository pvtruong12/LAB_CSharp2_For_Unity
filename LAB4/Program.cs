using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LAB4
{
    class Program
    {
        public class SinhVien
        {
            public string Name { get; set; }
            public int Point { get; set; }
        }
        private static List<SinhVien> list = new List<SinhVien>();
        static void Main(string[] args)
        {
            for(int i = 0; i< 5; i++)
            {
                Console.WriteLine($"Sinh vien {i+1}input Name: ");
                string a = Console.ReadLine();
                Console.WriteLine($"Sinh vien {i + 1}input Point: ");
                int b = int.Parse(Console.ReadLine());
                list.Add(new SinhVien() { Name = a, Point = b });
            }
            List<SinhVien> list1 = list.Where(x => x.Point >= 5).ToList();
            list1.ForEach(x => Console.WriteLine(x.Name + "  "+x.Point));
        }
    }
}

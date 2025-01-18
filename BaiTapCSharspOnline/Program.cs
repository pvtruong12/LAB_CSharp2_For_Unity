using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaiTapCSharspOnline
{
    class Program
    {
        public static class UserData
        {
            public static string UserName;
            public static int ID;
            public static int Gold;
            public static int Point;

            static UserData()
            {
                UserName = "Accc";
                ID = 123;
                Gold = 234;
                Point = 345;
            }
        }
        public class Maps
        {
            public int ID;
            public string Name;
            public static string _inGame = "Liên Minh huyển thoại";
        }

        public partial class Calculator
        {
            public int soA;
            public int soB;
        }
        public partial class Calculator
        {
            public string Cong()
            {
                return "Dap an Cong: "+(soA + soB);
            }public string Tru()
            {
                return "Dap an tru: " + (soA - soB);
            }public string Nhan()
            {
                return "Dap an nhan: " + (soA * soB);
            }public string Chia()
            {
                double a = (soA / soB);
                return "Dap an Chia: " + a;
            }
            public override string ToString()
            {
                return $"{Cong()} - {Tru()} - {Nhan()} - {Chia()}";
            }
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 1:
                    //object Obja = new
                    //{
                    //    user = UserData.UserName,
                    //    id = UserData.ID,
                    //    gold = UserData.Gold,
                    //    point = UserData.Point
                    //};
                    //HashSet<object> hassets = new HashSet<object>();
                    //hassets.Add(Obja);

                    Console.WriteLine($"Name: {UserData.UserName}, ID: {UserData.ID}, Gold: {UserData.Gold}, Point: {UserData.Point}");
                    break;
                case 2:
                    {
                        Maps map = new Maps() { ID = 0, Name = "truong12" };
                        LinkedList<Maps> listMaps = new LinkedList<Maps>();
                        listMaps.AddLast(map);
                        foreach(Maps maps in listMaps)
                        {
                            if(maps != null)
                                Console.WriteLine($"ID {maps.ID}, Name: {maps.Name}, inGame {Maps._inGame}");
                        }
                        break;
                    }
                case 3:
                    Calculator cals = new Calculator() { soA = 12, soB = 23 };
                    List<Calculator> list = new List<Calculator>();
                    list.Add(cals);
                    foreach (Calculator ca in list)
                        Console.WriteLine(cals);
                    break;
            }
        }
    }
}

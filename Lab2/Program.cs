using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        public static void bai1aa()
        {
            var a = 10;
            Console.WriteLine("x ="+a);
        } public static void bai1b()
        {
            getDeltai(10);
            getDeltai("game");
            getDeltai(9.5);
            getDeltai(false);
        }

        public static void getDeltai(dynamic x)
        {
            Console.WriteLine("value "+ x);
        }

        public class UserData
        {
            public int ID;
            public string userName;
            public int level;
            public override string ToString()
            {
                return $"ID : {ID}, Name: {userName}, Level{level}";
            }
        }public class userData
        {
            public int ID;
            public string userName;
            public List<float> Scores;
            public override string ToString()
            {
                string x = string.Join(", ",Scores);
                return $"ID : {ID}, Name: {userName}, Danh sách điểm: {x}";
            }
        }
        public static void bai2a()
        {
            var userInfo = new
            {
                id = "2024",
                name = "faker",
                isPlaying = false,
                bag = new
                {
                    skins = 0,
                    cups = 20
                }
            };
            Console.WriteLine($"id: { userInfo.id}");
            Console.WriteLine($"Name: { userInfo.name}");
            Console.WriteLine($"isPlaying: { userInfo.isPlaying}");
            Console.WriteLine($"bag skins: { userInfo.bag.skins}");
            Console.WriteLine($"bag cups: { userInfo.bag.cups}");
        }
        public static void bai2b()
        {
            int y = 10;
            Action<int> AnonimousMethod = delegate (int x)
            {
                int sum = x + y;
                int sub = x - y;
                Console.WriteLine($"Sum {sum} \n Sub {sub}");
            };
            AnonimousMethod(5);
        }
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 1:
                    {
                        var x = 10;
                        Action<int> bai1a = delegate (int g)
                        {
                            Console.WriteLine($"x ={g}");
                        };
                        bai1a(x);
                        break;
                    }
                case 2: bai1b();break;
                case 3:
                    {
                        UserData user = new UserData() { ID = 0, userName = "truong", level = 5 };
                        if(user != null)
                            Console.WriteLine(user);
                        break;
                    }
                case 4:bai2a();break;
                case 5: bai2b(); break;
                case 6:
                    {

                        userData user = new userData() { ID = 0, userName = "truong", Scores = new List<float>() { 10, 9, 8, 7.5f, 2, 1.4f } };
                        Console.WriteLine(user);

                    }break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace BTTrenLop
{
    class Program
    {
        public class Player
        {
            public Player(int iD, string userPlayer, long power, int maxHP)
            {
                ID = iD;
                UserPlayer = userPlayer;
                Power = power;
                MaxHP = maxHP;
            }

            public int ID { get; set; }
            public string UserPlayer { get; set; }
            public long Power { get; set; }
            public int MaxHP { get; set; }
            public override string ToString()
            {
                return $"{ID} \t {UserPlayer} \t {Power} \t {MaxHP}\n";
            }


        }
        public static List<Player> Players = new List<Player> { };
        static void Main(string[] args)
        {
            string arrayItem = "";
            using (StreamReader strw = new StreamReader("Data.txt"))
            {
                string length="";
                while((length = strw.ReadLine()) !=null)
                {
                    if (length.StartsWith("ID"))
                    {
                        arrayItem = length;
                        continue;
                    }
                    string[] array = length.Split('\t');
                    Players.Add(new Player(int.Parse(array[0]), array[1], long.Parse(array[2]), int.Parse(array[3])));
                }
            }
            Console.WriteLine(arrayItem);
            foreach(Player pl in Players)
            {
                Console.WriteLine(pl);
            }
        }
    }
}

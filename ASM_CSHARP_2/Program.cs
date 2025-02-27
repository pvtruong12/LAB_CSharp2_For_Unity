using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASM_CSHARP_2
{
    class Program
    {
        public static List<Game> listGame = new List<Game> { };
        public static List<Player> listPlayer = new List<Player> { };
        public class Game
        {
            public static int IDCount = 1;
            public int ID { get; set; }
            public string GameName { get; set; }
            public Game(string gameName)
            {
                ID = IDCount++;
                GameName = gameName;
            }
            public override string ToString()
            {
                return $"{ID}\t{GameName}";
            }

        }
        public class Player
        {
            public static int IDCount = 1;

            public Player(string userName, string email, int score)
            {
                ID = IDCount++;
                this.userName = userName;
                this.email = email;
                this.score = score;
            }
            public int ID { get; set; }

            public string userName { get; set; }
            public string email { get; set; }
            public int score { get; set; }

            public string GetRank()
            {
                if (score < 100)
                    return "Hạng đồng";
                else if (score < 500)
                    return "Hạng Bạc";
                else if (score < 1000)
                    return "Hạng Vàng";
                else if (score < 5000)
                    return "Hạng Kim cương";
                else if (score < 10000)
                    return "Hạng Cao thủ";
                else
                    return "Thách đấu";
            }
            public override string ToString()
            {
                return $"{userName}\t{email}\t{score}\t{ID}";
            }
            public string OutPutString()
            {
                return $"{userName}\t{email}\t{score}\t{ID}\t{GetRank()}";
            }
        }
        public static void AddPlayerToList(Player player, string path)
        {
            //File.AppendAllText(path, $"{player}\n");
            using (StreamWriter strw = new StreamWriter(path, true))
            {
                strw.WriteLine(player);
            }
        }
        private static List<Player> GetPlayerFormFile()
        {
            string[] text = File.ReadAllLines("players.txt");
            List<Player> list = text.Select(x =>
            {
                string[] text1 = x.Split('\t');
                Player player = new Player(text1[0], text1[1], int.Parse(text1[2]));
                return player;
            }).ToList();
            return list.OrderByDescending(x => x.score).ToList();
        }

        public static void AddPGameToList(Game player, string path)
        {
            using (StreamWriter strw = new StreamWriter(path, true))
            {
                strw.WriteLine(player);
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            int bt = int.Parse(Console.ReadLine());
            switch (bt)
            {
                case 0:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            string gName = Console.ReadLine();
                            AddPGameToList(new Game(gName), "game.txt");
                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            string gName = Console.ReadLine();
                            string email = Console.ReadLine();
                            int score = int.Parse(Console.ReadLine());
                            AddPlayerToList(new Player(gName, email, score), "players.txt");
                        }
                        break;
                    }
                case 2:
                    List<Player> list = GetPlayerFormFile();
                    foreach (Player player in list)
                    {
                        Console.WriteLine(player.OutPutString());
                    }
                    break;
                case 3:
                    File.Delete("players.txt");
                    break;
            }
        }
    }
}

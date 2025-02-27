using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace LAB__5
{
    class Program
    {
        public class Player
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int IDSkill { get; set; }
            public int Mastery { get; set; }
            public override string ToString()
            {
                return $"ID {ID}, Name {Name}, IDSKILL {IDSkill}, Masterry {Mastery}";
            }
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Effectiveness { get; set; }
            public string Rank { get; set; }
            public override string ToString()
            {
                return $"ID {ID}, Name {Name}, Eff {Effectiveness}, Rank {Rank}";
            }
        }
        public static List<Player> listPlayers = new List<Player> { };
        public static List<Skill> listSkill = new List<Skill> { };
        public static void AddPlayerSkill()
        {
            string pathPlayer = "PlayerSkills.txt";
            string pathSkill = "SkillDB.txt";
            string[] array = File.ReadAllLines(pathPlayer);
            string[] array2 = File.ReadAllLines(pathSkill);
            IEnumerable<Player> list = array.Skip(1).Select(x =>
            {
                var data = x.Split('\t');
                return new Player()
                {
                    ID = int.Parse(data[0]),
                    Name = data[1],
                    IDSkill = int.Parse(data[2]),
                    Mastery = int.Parse(data[3])

                };
            });
            IEnumerable<Skill> list2 = array2.Skip(1).Select(x =>
            {
                var data2 = x.Split('\t');
                return new Skill()
                {
                    ID = int.Parse(data2[0]),
                    Name = data2[1],
                    Effectiveness = int.Parse(data2[2]),
                    Rank = data2[3]

                };
            });
            listPlayers = list.ToList();
            listSkill = list2.ToList();
            listPlayers.ForEach(x => Console.WriteLine($"Add Sucsses {x}"));
            listSkill.ForEach(x => Console.WriteLine($"Add Sucsses {x}"));
        }
        public static Player FindPlayer(int id)
        {
            return listPlayers.FirstOrDefault(x => x.ID.Equals(id));
        }
        public static List<Player> AcctionThread1()
        {
            return listPlayers.SkipWhile(x => x.Mastery > 90).ToList();
        }
        public static List<Skill> AcctionThread2()
        {
            return listSkill.Where(x => x.Rank.Equals("a", StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        public static void SaveFIlePlayer(string path, List<Player> list, bool isCreatFile)
        {
            using (StreamWriter strw = new StreamWriter(path, isCreatFile))
            {
                strw.WriteLine("player_id\tplayer_name\tskill_id\tmastery");
                for(int  i = 0; i< list.Count; i++)
                {
                    Player player = list[i];
                    string conten = $"{player.ID}\t{player.Name}\t{player.IDSkill}\t{player.Mastery}";
                    strw.WriteLine(conten);
                }
                strw.Close();
            }
        }
        public static void SaveFIleSkill(string path, List<Skill> G, bool isCreatFile)
        {
            using (StreamWriter strw = new StreamWriter(path, isCreatFile))
            {
                strw.WriteLine("skill_id\tskill_name\teffectiveness\rank");
                for (int i = 0; i < G.Count; i++)
                {
                    Skill player = G[i];
                    string conten = $"{player.ID}\t{player.Name}\t{player.Effectiveness}\t{player.Rank}";
                    strw.WriteLine(conten);
                }
                strw.Close();
            }
        }
        public static List<Skill> FindCharWithRank(string Rank)
        {
            return listSkill.FindAll(x => x.Rank.Equals(Rank));
        }

        public static int TongRankB()
        {
            return listSkill.Count(x => x.Rank.Equals("B"));
        }
        public static List<Skill> NewListSkill()
        {
            return listSkill.Where(x => x.Effectiveness > 200).OrderByDescending(x => x.Effectiveness).ToList();
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 0:
                    AddPlayerSkill();
                    Thread thre1 = new Thread(() =>
                    {
                        AcctionThread1().ForEach(x => Console.WriteLine(x));
                    });
                    Thread thre2 = new Thread(() =>
                    {
                        AcctionThread2().ForEach(x => Console.WriteLine(x));
                    });
                    thre1.Start();thre1.Join();
                    thre2.Start();thre2.Join();
                    break;
                case 1:
                    AddPlayerSkill();
                    break;
                case 2:
                    AddPlayerSkill();
                    Thread.Sleep(500);
                    Player player = FindPlayer(3);
                    if(player == null)
                    {
                        Console.WriteLine($"dont found player with ID = {2}");
                        return;
                    }
                    player.Mastery = 80;
                    SaveFIlePlayer("PlayerSkills.txt", listPlayers, false);
                    break;
                case 3:
                    AddPlayerSkill();
                    Console.WriteLine("Tong so ng rank B "+ TongRankB());
                    break;
                case 4:
                    AddPlayerSkill();
                    SaveFIleSkill("HighMasteryPlayers.txt", NewListSkill(), false);
                    break;
            }
        }
    }
}

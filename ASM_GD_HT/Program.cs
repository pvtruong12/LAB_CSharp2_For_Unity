using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASM_GD_HT
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
                return $"{ID}\t{Name}\t{IDSkill}\t{Mastery}";
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
                return $"{ID}\t{Name}\t{Effectiveness}\t{Rank}";
            }
        }
        public static List<Player> listPlayer = new List<Player>();
        public static List<Skill> listSkill = new List<Skill>();
        static readonly string pathPlayer = "NewPlayerSkills.txt"; 
        static readonly string pathSkill = "NewSkillDB.txt";
        static string sDefaultCollumPlayer, sCDefaultollumSkill;
        public static void AddDataFormFile()
        {
            try
            {
                string[] array = File.ReadAllLines(pathPlayer);
                string[] array2 = File.ReadAllLines(pathSkill);
                sDefaultCollumPlayer = array[0];
                sCDefaultollumSkill = array2[0];
                var a = array.Skip(1).Where(x => !string.IsNullOrEmpty(x)).Select(x =>
                {
                    var ab = x.Split('\t');
                    return new Player() { ID = int.Parse(ab[0]), Name = ab[1], IDSkill = int.Parse(ab[2]), Mastery = int.Parse(ab[3]) };
                });var a2 = array2.Skip(1).Where(x => !string.IsNullOrEmpty(x)).Select(x =>
                {
                    var a = x.Split('\t');
                    return new Skill() { ID = int.Parse(a[0]), Name = a[1], Effectiveness = int.Parse(a[2]), Rank = a[3] };
                });
                listPlayer = a.ToList();
                listSkill = a2.ToList();
                listPlayer.ForEach(x => Console.WriteLine($"Add thành công:{x}"));
                listSkill.ForEach(x => Console.WriteLine($"Add thành công:{x}"));
                //Console.WriteLine($"Add thành công {listPlayer.Count} Player\nAdd thành công {listSkill.Count} Skil\n");
            }catch(Exception ex)
            {
                File.AppendAllText("ErrorLog.txt", ex.Message+Environment.NewLine);
            }
        }
        public static void GenericSaveFile<T>(IEnumerable<T> list)
        {
            string text = "";
            string path = "";
            if (typeof(T) == typeof(Player)) { 
                text = sDefaultCollumPlayer + "\n"; path = pathPlayer; }
            else { 
                text = sCDefaultollumSkill + "\n"; path = pathSkill; }
            var text2 = list.Select(x =>
            {
                string a = $"{x}";
                return a;
            });
            text = text + string.Join("\n", text2.ToArray());
            File.WriteAllText(path, text);
        }
        public static void FuncBT3()
        {
            List<int> listID = listSkill.Where(x => x.Rank.Equals("S")).Select(x => x.ID).Distinct().ToList();
            var a = listPlayer.Where(x => listID.Contains(x.IDSkill)).ToList();
            var b =  a.GroupBy(x => x.Name).Select(x => new { Name= x.Key, count =x.Count() }).ToList();
            Console.WriteLine(a.Count);
            b.ForEach(x => Console.WriteLine($"Nguời chơi {x.Name} có {x.count} kỹ năng rank S"));
        }
        public static void FuncBT4()
        {
            var a = listPlayer.GroupBy(x => x.Name).Select(x => new { Name = x.Key, Tong = x.Sum(y => y.Mastery) }).Where(x =>x.Tong >= 250).OrderByDescending(x => x.Tong).ToList();
            string x =a.Aggregate(seed: "", func: (a, b) => a+ $"{b.Name}\t{b.Tong}\n").TrimEnd('\n');
            Console.WriteLine(x);
            File.WriteAllText("TopMasteryPlayers.txt", x);
        }
        public static void FuncBT2()
        {
            var a = listPlayer.Where(x => x.Mastery <= 95).ToList();
            a.ForEach(x => x.Mastery += 5);
            GenericSaveFile(listPlayer);
        }
        public static void Func5_1()
        {
            listPlayer.Where(x => x.Mastery >= 90).ToList().ForEach(x => Console.WriteLine("case5_1 "+x));
        }public static void Func5_2()
        {
            listSkill.Where(x => x.Effectiveness >= 250).ToList().ForEach(x => Console.WriteLine("case5_2 " + x));
        }public static void Func5_3()
        {
            var a = listPlayer.GroupBy(x => x.Name).Select(x => new { Name = x.Key, count = x.Select(x => x.IDSkill).Distinct().Count() });
            var b = a.OrderByDescending(x => x.count).FirstOrDefault();
            Console.WriteLine($"case5_1 Name: {b.Name}, tổng số skill: {b.count}");
        }
        public static async void Func5()
        {
            List<Task> listTask = new List<Task>
            {
                Task.Run(Func5_1),
                Task.Run(Func5_2),
                Task.Run(Func5_3)

            };
            await Task.WhenAll(listTask);
            Console.WriteLine("Done!!!!!!!!!!!!!!!!!!!");
        }
        static void Main(string[] args)
        {
            AddDataFormFile();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 1: AddDataFormFile();break;
                case 2:FuncBT2();break;
                case 3: FuncBT3();break;
                case 4:FuncBT4();break;
                case 5:Func5();break;
            }
        }
    }
}

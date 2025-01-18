using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace LAB3
{
    class Program
    {
        public static void AddDataAccount(string account, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (StreamWriter strw = new StreamWriter(path, true))
            {
                strw.WriteLine(account);
            }
        }
        public static void ReadAccount(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (StreamReader str = new StreamReader(path, UTF8Encoding.UTF8))
                {
                    string textline = "";
                    while ((textline = str.ReadLine()) != null)
                    {
                        Console.WriteLine(textline);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Not exits file");
            }
        }

        public class PlayerData
        {
            public PlayerData(int iD, string cName, int skillID, string mastery)
            {
                ID = iD;
                this.cName = cName;
                this.skillID = skillID;
                this.mastery = mastery;
            }

            public int ID { get; set; }
            public string cName { get; set; }
            public int skillID { get; set; }
            public string mastery { get; set; }
            public string dataAccount()
            {
                return $"{ID}\t{cName}\t{skillID}\t{mastery}";
            }
        }

        public static void WriteUTF(List <PlayerData> list,string path)
        {
            if(list.Count <= 0)
            {
                Console.WriteLine("Erro add player");
                return;
            }
            string Itemdata = "player_id\tplayer_name\tskill_id\tmasterry\n";
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(Itemdata);
                bw.Write(list.Count);
                for(int i = 0; i< list.Count; i++)
                {
                    PlayerData pl = list[i];
                    if (pl == null)
                        continue;
                    bw.Write(pl.ID);
                    bw.Write("\t");
                    bw.Write(pl.cName);
                    bw.Write("\t");
                    bw.Write(pl.skillID);
                    bw.Write("\t");
                    bw.Write(pl.mastery);
                    bw.Write("\n");
                }
            };
        }
        public static void ReadUTF(string path)
        {
            using (BinaryReader bw = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string itemData = bw.ReadString();
                int length = bw.ReadInt32();
                string text = itemData;
                for(int i = 0; i< length; i++)
                {
                    int id = bw.ReadInt32();
                    string tab1 = bw.ReadString();
                    string name = bw.ReadString();
                    string tab2 = bw.ReadString();
                    int idSkill = bw.ReadInt32();
                    string tab3 = bw.ReadString();
                    string mastery = bw.ReadString();
                    string enter = bw.ReadString();
                    text += id + tab1 + name + tab2 + idSkill + tab3 + mastery + enter;
                }
                Console.WriteLine(text);
            };
        }
        public static string convertToAccount(string acc, string pass)
        {
            return acc + "|" + pass;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 1:
                    {
                        string path = "dataAccount.txt";
                        if (File.Exists(path))
                            File.Delete(path);
                        for (int i = 0; i< 3; i++)
                        {
                            string acc = "acc" + i;
                            string pass = "pass" + i;
                            AddDataAccount(convertToAccount(acc, pass), path);
                        }
                        ReadAccount(path);

                    }
                    break;
                case 2:
                    {
                        string path2 = "DATA2.txt";
                        List<PlayerData> list = new List<PlayerData>();
                        list.Add(new PlayerData(1, "Quinn1", 90, "null"));
                        list.Add(new PlayerData(2, "Ryan 2", 85, "null"));
                        list.Add(new PlayerData(3, "Sophie", 3, "95"));
                        list.Add(new PlayerData(4, "Tyler 4", 80, "null"));
                        WriteUTF(list, path2);
                        Thread.Sleep(500);
                        ReadUTF(path2);
                    }
                    break;
            }
        }
    }
}

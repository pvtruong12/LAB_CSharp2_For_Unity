using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LAB_6
{
    class Program
    {
        class GameAccount
        {
            public string Username { get; set; }
            public int Score { get; set; }

            public GameAccount(string username, int score)
            {
                Username = username;
                Score = score;
            }
        }
        static void Main(string[] args)
        {
            var gameAccounts = new ArrayList();
            gameAccounts.Add(new GameAccount("AceGamer", 1200));
            gameAccounts.Add(new GameAccount("AlphaWarrior", 800));
            gameAccounts.Add(new GameAccount("AresKnight", 1500));
            gameAccounts.Add(new GameAccount("ShadowNinja", 2000));
            gameAccounts.Add(new GameAccount("ArcherX", 950));
            gameAccounts.Add(new GameAccount("AceGamer1", 111));
            gameAccounts.Add(new GameAccount("AlphaWarrior2", 222));
            gameAccounts.Add(new GameAccount("AresKnight3", 333));
            gameAccounts.Add(new GameAccount("ShadowNinja4", 444));
            gameAccounts.Add(new GameAccount("ArcherX5", 555));
            IEnumerable<GameAccount> query = gameAccounts.Cast<GameAccount>().SkipWhile(x => x.Score < 500).Where(y => y.Username.StartsWith("A") && y.Score > 200).Take(2);
            foreach (var account in query)
            {
                Console.WriteLine($"{account.Username} - Score: {account.Score}");
            }
        }
        private static int DequyTong(int[] a, int b, int num)
        {
            if (b >= a.Length)
                return num;
            return DequyTong(a, b+1, a[b]*num);
        }
    }
}

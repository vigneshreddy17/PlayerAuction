using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Auction
{
    class Auction
    {
        string soldPlayers = Path.soldPlayersPath;
        public Auction(dynamic vignesh, dynamic naveen, dynamic yash, dynamic sasank, dynamic varun, dynamic venky, dynamic unsold)
        {
            Console.WriteLine("####### Welcome to Auction #######");
            string path = Path.PlayersPath;
            Path soldPlayerspath = new Path();
            
            string[] players = File.ReadAllLines(path);
            List<string> playerList = new List<string>(players);

            int cnt = playerList.Count;

            List<string> soldPlayersList = new List<string>();

            double? soldFor = null;
            string soldTo = null;

            //string pth = @"C:\Users\harry\source\repos\Auction\FIFA21_official_data.csv";
            //var csvdata = File.ReadAllLines(pth);


            while(cnt > 0)
            {
                var rand = new Random();
                int index = rand.Next(playerList.Count);
                string player = playerList[index];
                cnt--;
                int baseValue = GetBaseValue(player);

                
                Console.WriteLine(player);
                Console.WriteLine("Base value : {0}", baseValue);
                try
                {
                    Console.Write("Sold for : ");
                    soldFor = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Sold to : ");
                    soldTo = Console.ReadLine();
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    soldFor = null;
                    soldTo = null;
                }
                if (soldTo != null && soldFor != null)
                {
                    if (soldTo.ToLower().Equals("vignesh") || soldTo.ToLower().Equals("vig"))
                    {
                        generateData(vignesh, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.vigneshSold, vignesh.players);
                        using (StreamWriter sw = File.AppendText(Path.vigneshSold))
                        {
                            sw.WriteLine();
                            sw.Write(player +" ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }
                    else 
                    if (soldTo.ToLower().Equals("naveen") || soldTo.ToLower().Equals("nav"))
                    {
                        generateData(naveen, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.naveenSold, naveen.players);
                        using (StreamWriter sw = File.AppendText(Path.naveenSold))
                        {
                            sw.WriteLine();
                            sw.Write(player + " ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }

                    else if (soldTo.ToLower().Equals("sasank") || soldTo.ToLower().Equals("sas"))
                    {
                        generateData(sasank, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.sasankSold, sasank.players);
                        using (StreamWriter sw = File.AppendText(Path.sasankSold))
                        {
                            sw.WriteLine();
                            sw.Write(player + " ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }

                    else if (soldTo.ToLower().Equals("varun") || soldTo.ToLower().Equals("var"))
                    {
                        generateData(varun, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.varunSold, varun.players);
                        using (StreamWriter sw = File.AppendText(Path.varunSold))
                        {
                            sw.WriteLine();
                            sw.Write(player + " ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }

                    else if (soldTo.ToLower().Equals("venky") || soldTo.ToLower().Equals("venk") || soldTo.ToLower().Equals("ven"))
                    {
                        generateData(venky, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.venkySold, venky.players);
                        using (StreamWriter sw = File.AppendText(Path.venkySold))
                        {
                            sw.WriteLine();
                            sw.Write(player + " ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }

                    else if (soldTo.ToLower().Equals("yash") || soldTo.ToLower().Equals("yas"))
                    {
                        generateData(yash, soldFor, player, soldTo);
                        //File.WriteAllLines(Path.yashSold, yash.players);
                        using (StreamWriter sw = File.AppendText(Path.yashSold))
                        {
                            sw.WriteLine();
                            sw.Write(player + " ");
                            sw.WriteLine(soldFor + "");
                            sw.Close();
                        }
                        soldPlayersList.Add(player);
                    }

                    File.WriteAllLines(soldPlayers, soldPlayersList);

                }

                else
                {
                    string unsoldPath = Path.unsoldPlayersPath;
                    unsold.players.Add(player);
                    File.WriteAllLines(unsoldPath, unsold.players);
                }

                playerList.Remove(player);
                File.WriteAllLines(path, playerList);
                Console.ReadLine();
            }

        }

        public int GetBaseValue(string player)
        {
            string[] b = player.Split('(', ')');
            int rating;
            try
            {
                rating = Convert.ToInt32(b[1]);
            }
            
            catch (Exception e)
            {
                rating = 83;
            }

            if (rating >= 90)
            {
                return 5;
            }
            else if (rating > 86 && rating < 90)
            {
                return 4;
            }
            else if (rating > 84 && rating < 87)
            {
                return 3;
            }
            else if (rating == 84)
            {
                return 2;
            }
            else
                return 1;                
        }

        public void generateData(dynamic v, double? soldFor, string player, string soldTo)
        {
            double balance = v.balance - soldFor;
            v.balance = balance;
            v.players.Add(player);

            Console.WriteLine("Current Squad : \n");
            
            foreach(string a in v.players)
            {
                Console.Write("* ");
                Console.WriteLine(a);
            }

            generateLogFile(player, soldFor, soldTo, balance);

            Console.WriteLine();
            Console.Write("=> ");
            v.balance = Math.Round(v.balance, 2);
            Console.WriteLine("Balance: {0} \n", v.balance);
            Console.WriteLine("##############################################################");
        }

        public void generateLogFile(string player, double? soldFor, string soldTo, double budget)
        {
            using (StreamWriter sw = File.AppendText(Path.logFile))
            {
                sw.WriteLine(player + "");
                sw.WriteLine(soldFor + "");
                sw.WriteLine(soldTo + "");
                sw.WriteLine(budget + "");
                sw.WriteLine("************************");
                sw.Close();
            }
        }

    }
}

///To-do
//Create a text file to store unsold players and sold players - Done
//Remove the player from the PlayersList - Done
//Add players to separate textFiles i.e Vignesh.txt -Done

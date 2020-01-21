using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UPS_Project
{
    class LoadDepots
    {
        LatestDepotCSV function = new LatestDepotCSV();
        UPSAPI upsFunction = new UPSAPI();
        SaveCurrentDepot saveCurrentDepot = new SaveCurrentDepot();

        public List<Depot> getCurrentDepots()//WORKS DO NOT TOUCH
        {

            List<Depot> currentDepots = new List<Depot>();
            StreamReader inputFile;
            char[] delim = { ',' };
            string line;

            inputFile = File.OpenText("CurrentDepots.txt");

            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                string[] token = line.Split(delim);

                currentDepots.Add(new Depot(token[0], token[1],token[2],upsFunction.getLatestUPSupdate(token[2]),upsFunction.itemDelivered(token[2])));
            }
            inputFile.Close();


            return currentDepots;

        }
        public List<Depot> getNewDepots(string latestFile)
        {

            List<Depot> newDepots = new List<Depot>();
            StreamReader inputFile;
            char[] delim = { ',' };
            string line;
            string path = @"M:\Depot Spreadsheets\CSV\";
            inputFile = File.OpenText(path + latestFile);

            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                string[] token = line.Split(delim);
                if (token[5].Length == 18)
                {
                    newDepots.Add(new Depot(token[0], token[3], token[5], upsFunction.getLatestUPSupdate(token[5]), upsFunction.itemDelivered(token[5])));
                }
                
            }
            inputFile.Close();

            return newDepots;

        }

        public List<Depot> getNewDepotsTest(string latestFile)
        {

            List<Depot> newDepots = new List<Depot>();
            StreamReader inputFile;
            char[] delim = { ',' };
            string line;
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            inputFile = File.OpenText(path + latestFile);

            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                string[] token = line.Split(delim);
                if (token[5].Length == 18)
                {
                    newDepots.Add(new Depot(token[0], token[3], token[5], upsFunction.getLatestUPSupdate(token[5]), upsFunction.itemDelivered(token[5])));
                }

            }
            inputFile.Close();

            return newDepots;

        }
    }
}



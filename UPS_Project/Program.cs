using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace UPS_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            //Class calls - could make a class library instead
            LatestDepotCSV latestDepotCSV = new LatestDepotCSV();
            LoadDepots loadDepots = new LoadDepots();
            UPSAPI upsAPI = new UPSAPI();
            SaveCurrentDepot SaveCurrentDepot = new SaveCurrentDepot();

            //Initiate 3 lists that will be used
            List<Depot> CurrentDepots = new List<Depot>();
            List<Depot> newDepots = new List<Depot>();
            List<Depot> toBeMailed = new List<Depot>();
            
            

            //Load Current Depots (from project folder bin\currentdepot.txt)
            CurrentDepots = loadDepots.getCurrentDepots();
            File.Delete("CurrentDepots.txt");//delete file after loading list
            CurrentDepots.Insert(0,new Depot("0000", "Dummy", "1Z5V87A91369279029", "Dummy", false));//instert  dummy depot @ position 0 to always keep
            //Loads New Depots (from M:\Depot Spreadsheets\CSV - Jaime updates this folder)
            //newDepots = loadDepots.getNewDepots(latestDepotCSV.getLatestCSVfile()); <<<<<<<<<<<<<<<<<<<<<<< WORKING!!!
            newDepots = loadDepots.getNewDepotsTest(@"\CSV\01172021.csv");//testing only
            

            //Testing Loading currentDepots - No issues
            Console.WriteLine(@"Current Depots in bin\CurrentDepots.txt");
            foreach (Depot depot in CurrentDepots)
            {
                Console.WriteLine(depot.Store + "," +depot.Item+ "," +depot.TrackingNum + "," +depot.Status + "," +depot.Delivered );               
            }
            //Testing loading newDepots - No isses
            Console.WriteLine("\n" + @"New Depots in M:\CSV\");// + latestDepotCSV.getLatestCSVfile());           
            foreach (Depot depot in newDepots)
            {
                Console.WriteLine(depot.Store + "," + depot.Item + "," + depot.TrackingNum + "," + depot.Status + "," + depot.Delivered);
            }
            //Comparing New depots and current depots, adds new depots to current depots if trackingnumb is not present
            //This should be a method with two lists passed and one returned.
            Console.WriteLine("\nTesting object compare");//WORKING!!!!!!!
            foreach (Depot depot1 in newDepots)
            {
                string foundTracking = "";
                if (CurrentDepots.Any(depot => depot.TrackingNum == depot1.TrackingNum)) 
                {
                    Console.WriteLine("Found " + depot1.Store +","+depot1.TrackingNum);
                    foundTracking = depot1.TrackingNum;

                }
                else
                {
                    CurrentDepots.Add(depot1);
                    Console.WriteLine("Added: "+depot1.Store + "," + depot1.Item + "," + depot1.TrackingNum + "," + depot1.Status + "," + depot1.Delivered
                        +"\nTo currendt depots");
                }   
            }
            //Gets all the delivered = true in current depots and adds to "tobemailes" list
            Console.WriteLine("\nTesting conbining new and current list");
            foreach (Depot depot in CurrentDepots)
            {
                Console.WriteLine(depot.Store + "," + depot.Item + "," + depot.TrackingNum + "," + depot.Status + "," + depot.Delivered);
                if (depot.Delivered == true)
                {
                    toBeMailed.Add(depot);
                }
            }
            //Testing the "tobemailed" depot list
            //Send email for each delivered item
            Console.WriteLine("\nThe following depots have been delivered");
            foreach (Depot depot in toBeMailed)
            {             
                
                if (depot.Store != "0000")
                {
                    Console.WriteLine(depot.Store + "," + depot.Item + "," + depot.TrackingNum + "," + depot.Status + "," + depot.Delivered);
                    //EmailLogic.SendEmail(depot);
                }
                //EmailLogic.SendEmail(depot);
            }

            Console.WriteLine();
            Console.WriteLine("Testing Removal of Depot if delivered");
            //Removes all depots in current depots that have "delviered = true"
            CurrentDepots.RemoveAll(x => x.Delivered == true); ;
            //Testing to make sure delivered objects have been removed
            foreach (Depot depot in CurrentDepots)
            {
                Console.WriteLine(depot.Store + "," + depot.Item + "," + depot.TrackingNum + "," + depot.Status + "," + depot.Delivered);
            }

            //Addrecord should be called here to update the currentdepots.txt
            foreach (Depot depot in CurrentDepots)
            {
                SaveCurrentDepot.AddRecord(depot);
            }
            
            Console.ReadLine();
            


        }



    }
    
}

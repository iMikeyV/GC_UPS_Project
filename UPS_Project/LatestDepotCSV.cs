using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS_Project
{
    class LatestDepotCSV
    {
        public string getLatestCSVfile()
        {
            DirectoryInfo d = new DirectoryInfo(@"M:\Depot Spreadsheets\CSV");//Test Folder
            FileInfo[] Files = d.GetFiles("*.csv");//gets csv files
            string latestfile = "";//holds file name

            DateTime lastModified = DateTime.MinValue;

            foreach (FileInfo file in Files)
            {
                if (file.LastWriteTime > lastModified)
                {
                    lastModified = file.LastWriteTime;
                    latestfile = file.Name;
                }
            }
            //To see the value of latest variable, You can remove both lines
            //outPutLabel.Text += "Latest File Name: " + latestfile;
            return latestfile;
        }
    }
}

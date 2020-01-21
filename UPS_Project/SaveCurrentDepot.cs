using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UPS_Project
{
    class SaveCurrentDepot
    {
        public void AddRecord(Depot depot)
        {
            try
            {
                StreamWriter file = new StreamWriter("CurrentDepots.txt", true);
                file.WriteLine(depot.Store+","+depot.Item + ","+depot.TrackingNum + "," +depot.Status + "," +depot.Delivered);
                file.Close();
            }
            catch(Exception)
            {
                throw new ApplicationException("Add record failed");
            }
        }
    }
}


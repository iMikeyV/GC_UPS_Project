using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS_Project
{
    class Depot
    {
        public string Store { get; set; }
        public string Item { get; set; }
        public string TrackingNum { get; set; }
        public string Status { get; set; }
        public bool Delivered { get; set; }

        public Depot(string storeNum, string itemsShipped, string trackingNum, string status, bool delivered)
        {
            Store = storeNum;
            Item = itemsShipped;
            TrackingNum = trackingNum;
            Status = status;
            Delivered = delivered;
        }
    }
}

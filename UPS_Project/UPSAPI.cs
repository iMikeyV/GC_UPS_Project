using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UPS_Project.UPSTrackingProxy;

namespace UPS_Project
{
    class UPSAPI
    {
        public string getLatestUPSupdate(string trackingNumb)
        {
            string latestUpdate = "";

            try
            {
                //create the client proxy
                TrackPortTypeClient track = new TrackPortTypeClient();

                //create username token
                UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
                //this is my UPS userid
                upssUsrNameToken.Username = "**UPS ACCOUNT HERE**";
                //this is my UPS password
                upssUsrNameToken.Password = "**PADDWORD HERE***";

                UPSSecurityServiceAccessToken upssSvcAccessToken =
                new UPSSecurityServiceAccessToken();
                //this is my UPS access key
                upssSvcAccessToken.AccessLicenseNumber = "CD6DBC4A27FE8C15";
                //create UPS security object
                UPSSecurity upss = new UPSSecurity();
                //set the user name token
                upss.UsernameToken = upssUsrNameToken;
                //set the service access token
                upss.ServiceAccessToken = upssSvcAccessToken;

                //create the request object
                RequestType request = new RequestType();
                //must be hard coded to 15
                String[] requestOption = { "15" };
                //set the request option
                request.RequestOption = requestOption;

                TrackRequest tr = new TrackRequest();
                tr.Request = request;
                //this is your UPS tracking id (normally 18 digit)
                //TODO: Make a list and use the strin.join function to create a comma separated list to pass for tracking numbers***********

                tr.InquiryNumber = trackingNumb;//trackingNumListBox.SelectedItem.ToString();//gets tracking # from listbox
                                                //tr.InquiryNumber = "1Z5V87A90369535127";//Hardcoded test tracking number 
                                                /*1Z5V87A90369535127 has a status of : 
                                                "In transit  
                                                Scheduled Delivery:
                                                Wednesday
                                                11 / 06 / 2019
                                                Estimated Time
                                                by End of Day
                                                per UPS tracking website
                                                 */



                //added to handle the intermittent error with SSL/TLS connection
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls12;

                //open channel
                track.Open();

                //invoke the service
                TrackResponse trackResponse = track.ProcessTrack(upss, tr);

                //close channel
                track.Close();

                //store activities
                List<string> actList = new List<string>();
                List<string> dateList = new List<string>();

                List<string> timeList = new List<string>();
                foreach (ShipmentType shipment in trackResponse.Shipment)
                {
                    foreach (PackageType package in shipment.Package)
                    {

                        foreach (ActivityType Act in package.Activity)
                        {
                            //Adds description of last activity to actList
                            actList.Add(Act.Status.Description);

                            //Output testing
                            //testConsole.Text += ("\nStatus: "+
                            //Act.ActivityLocation.Address.City,
                            //Act.ActivityLocation.Address.StateProvinceCode, Act.Date, Act.Time,
                            //Act.Status.Description);

                        }

                    }

                }
                latestUpdate = actList[0];


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return latestUpdate;
        }

        public bool itemDelivered(string trackingNumb)
        {
            bool delivered = false;

            try
            {
                //create the client proxy
                TrackPortTypeClient track = new TrackPortTypeClient();

                //create username token
                UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
                //this is my UPS userid
                upssUsrNameToken.Username = "**UPS ACCOUNT HERE**";
                //this is my UPS password
                upssUsrNameToken.Password = "**PADDWORD HERE***";

                UPSSecurityServiceAccessToken upssSvcAccessToken =
                new UPSSecurityServiceAccessToken();
                //this is my UPS access key
                upssSvcAccessToken.AccessLicenseNumber = "CD6DBC4A27FE8C15";
                //create UPS security object
                UPSSecurity upss = new UPSSecurity();
                //set the user name token
                upss.UsernameToken = upssUsrNameToken;
                //set the service access token
                upss.ServiceAccessToken = upssSvcAccessToken;

                //create the request object
                RequestType request = new RequestType();
                //must be hard coded to 15
                String[] requestOption = { "15" };
                //set the request option
                request.RequestOption = requestOption;

                TrackRequest tr = new TrackRequest();
                tr.Request = request;
                //this is your UPS tracking id (normally 18 digit)
                
                tr.InquiryNumber = trackingNumb;

                //added to handle the intermittent error with SSL/TLS connection
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls12;

                //open channel
                track.Open();

                //invoke the service
                TrackResponse trackResponse = track.ProcessTrack(upss, tr);

                //close channel
                track.Close();

                //store activities
                List<string> actList = new List<string>();
                List<string> dateList = new List<string>();

                List<string> timeList = new List<string>();
                foreach (ShipmentType shipment in trackResponse.Shipment)
                {
                    foreach (PackageType package in shipment.Package)
                    {

                        foreach (ActivityType Act in package.Activity)
                        {
                            //Adds description of last activity to actList
                            actList.Add(Act.Status.Description);

                            //Output testing
                            //testConsole.Text += ("\nStatus: "+
                            //Act.ActivityLocation.Address.City,
                            //Act.ActivityLocation.Address.StateProvinceCode, Act.Date, Act.Time,
                            //Act.Status.Description);

                        }

                    }

                }

                if (String.Equals(actList[0], "Delivered"))
                {
                    delivered = true;
                }

            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            
            }

            return delivered;
        }
    }
}


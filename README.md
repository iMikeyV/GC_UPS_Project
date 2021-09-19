# GC_UPS_Project
 UPS API delivery notification for Golden Corral HelpDesk


### Introduction.  

This guide will detail all of the features and requirements of the UPS Project, an application that will notify the help desk every time a depot has been delivered.

All of the source code has been commented to be fully understood.




### Problem:  

Help desk analysts receive a daily email containing a spreadsheet with multiple shipping details.
They manually input data from the spreadsheet into a Heatcall, then individually update each shipping status by checking the UPS website periodically


### Solution:  

Using the UPS API this program will keep a running list of “Depots” and notify the HelpDesk whenever an item has been delivered.


   ### How:  
   -Daily email spreadsheet is now saved as a CSV file, the program reads data from CSV file and if there is a UPS tracking number present it creates a
    “Depot” object.  
    
   -The program keeps a running list of all Depots and receives direct tracking status from the UPS servers  
   
   -Once a “Depot.Status” changes to “Delivered”, it removes it from the running list and sends an email notification to the Helpdesk

            
### Files  

Filename: UPS_Project.exe
File path: H:\UPS Project\UPS_Project\bin\Release\UPS_Project.exe  

Source code(visual studio project): H:\UPS Project\UPS_Project.sln
UPS API Documentation: H:\UPS Project\UPS_Project\TrackingAPI

Currently running from a Local copy on PC41 to test as a scheduled event




### Programming Language:  

C#




### Input:  

Last modified “.csv” file that is at least 8 hours old in M:\Depot Spreadsheets\CSV - Updated by Jaime
”CurrentDepots.txt” in H:\UPS Project\UPS_Project\bin\Release\
”TodayCSV.txt” in H:\UPS Project\UPS_Project\bin\Release\   (simple txt file with one word)

 Example CSV file from POS department:
![Alt text](https://i.ibb.co/3WSJhky/CSV.png)

Example CurrentDepots.txt:  

![Alt text](https://i.ibb.co/X48dyP1/Current-Depots.png)





### Output:  

Log file: “Log_MMDDYYY_HHMMSS.txt” in H:\UPS Project\UPS_Project\bin\Debug\Log
Email to “michel.villafan” and openticket@goldencorral.net
An updated "CurrentDepots.txt" same as the one in input
 
Example LogFile output:  

![Alt text](https://i.ibb.co/5Gqsb7Z/log.png)  

Example Email output:  

![Alt text](https://i.ibb.co/NZCQXWf/email.png)




### Specifications and Rules:  
  
“NTLM Authentication failure” usually means that UPS' servers are down for maintenance or you have internet problems - Try again in 5-10 minutes

"Failure due to client data” most likely due to a tracking number that has no information available yet, not even in the UPS servers. (this is why I added an 8 hour buffer to the latest CSV file)
    Could also be a human error (typo in POS depot file)


### Instruction:  

Simply run the executable.
Ideally, we want to run the application every 10-15 mins. 
I have been testing it for the past 3-4 weeks as a scheduled event.

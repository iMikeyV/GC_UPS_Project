# GC_UPS_Project
 UPS API delivery notification


### Introduction.  

This guide will detail all of the features and requirements of the UPS Project, an application that will notify the help desk every time a depot has been delivered.

All of the source code has been commented to be fully understood.




### Problem:  

HD Analysts receive a daily email containing a spreadsheet with multiple shipping details.
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


Example CurrentDepots.txt
![Alt text](https://api.media.atlassian.com/file/ef43679d-19a1-4263-b729-a609310f1c70/image?mode=full-fit&client=406ab4e6-57b8-4dc5-af1e-1b1693335348&token=eyJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI0MDZhYjRlNi01N2I4LTRkYzUtYWYxZS0xYjE2OTMzMzUzNDgiLCJhY2Nlc3MiOnsidXJuOmZpbGVzdG9yZTpmaWxlOmVmNDM2NzlkLTE5YTEtNDI2My1iNzI5LWE2MDkzMTBmMWM3MCI6WyJyZWFkIl19LCJleHAiOjE1OTU1NDYwMzMsIm5iZiI6MTU5NTU0MjY3M30.Sc05Y6m1AIIqJ4-zRQEbsVqu6o1_hDv2zBAIa7Je4xg)





### Output:  

Log file: “Log_MMDDYYY_HHMMSS.txt” in H:\UPS Project\UPS_Project\bin\Debug\Log
Email to “michel.villafan” and openticket@goldencorral.net
An updated "CurrentDepots.txt" same as the one in input

Example LogFile output:
![Alt text](https://api.media.atlassian.com/file/ba87b003-6f86-47f7-b2f7-e7912ef8fe3c/image?mode=full-fit&client=406ab4e6-57b8-4dc5-af1e-1b1693335348&token=eyJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI0MDZhYjRlNi01N2I4LTRkYzUtYWYxZS0xYjE2OTMzMzUzNDgiLCJhY2Nlc3MiOnsidXJuOmZpbGVzdG9yZTpmaWxlOmJhODdiMDAzLTZmODYtNDdmNy1iMmY3LWU3OTEyZWY4ZmUzYyI6WyJyZWFkIl19LCJleHAiOjE1OTU1NDYwOTgsIm5iZiI6MTU5NTU0MjczOH0.uQgELjtmMYlymhPnjNIMaUAMacrLm0JTnoPSHB15EpI)


Example Email output:
![Alt text](https://api.media.atlassian.com/file/3f88d668-a6d4-442f-9897-6c48d0bcf823/image?mode=full-fit&client=406ab4e6-57b8-4dc5-af1e-1b1693335348&token=eyJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI0MDZhYjRlNi01N2I4LTRkYzUtYWYxZS0xYjE2OTMzMzUzNDgiLCJhY2Nlc3MiOnsidXJuOmZpbGVzdG9yZTpmaWxlOjNmODhkNjY4LWE2ZDQtNDQyZi05ODk3LTZjNDhkMGJjZjgyMyI6WyJyZWFkIl19LCJleHAiOjE1OTU1NDYxMTUsIm5iZiI6MTU5NTU0Mjc1NX0.C2uyEGxSYFshTyDhapYD2B0BXl9y4J0xN2rWhag3lTE)




### Specifications and Rules:  

0. “NTLM Authentication failure” usually means that UPS' servers are down for maintenance or you have internet problems - Try again in 5-10 minutes

1.” Failure due to client data” most likely due to a tracking number that has no information available yet, not even in the UPS servers. (this is why I added an 8 hour buffer to the latest CSV file)
    Could also be a human error (typo in POS depot file)


### Instruction:  

Simply run the executable.
Ideally, we want to run the application every 10-15 mins. 
I have been testing it for the past 3-4 weeks as a scheduled event.

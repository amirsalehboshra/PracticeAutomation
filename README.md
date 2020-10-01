# PracticeAutomation
PracticeAutomation

Project Structure
* Files
** Logs
** Screenshots
** TestData
** TestReports
* PagesModels
.. For DataModels
* PagesObjects
.. for Pages 
* Tests
.. Test scenaios
* Utility
.. Driver, Logging, Reporting and Helper


Ho to configure Test data, Environment and Browser?

Testing data for registration: \PracticeAutomation\Files\TestData\RegistrationData.xlsx
Testing data for login: \PracticeAutomation\appsettings.json
Environments : \PracticeAutomation\appsettings.json
Browsers: \PracticeAutomation\appsettings.json

How to run?

Download the project
Extract it to a folder path
Find the project path like "C:\Users\amir.saleh\Documents\GitHub\PracticeAutomation\PracticeAutomation\bin\Debug\netcoreapp3.1"
Open CMD as administrator
open the project path
write this commant line: dotnet test PracticeAutomation.dll --logger "Console;verbosity=detailed"

How to open Reports?
You can find the report of last run here: \PracticeAutomation\Files\TestReports

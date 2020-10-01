# PracticeAutomation
PracticeAutomation

Project Structure
- Files(Logs, Screenshots, TestData and TestReports)
- PagesModels (For DataModels... )
- PagesObjects (for Pages...)
- Tests (Test scenaios...)
- Utility(Driver, Logging, Reporting and Helper)


Ho to configure Test data, Environment and Browser?

1. Testing data for registration: \PracticeAutomation\Files\TestData\RegistrationData.xlsx
2. Testing data for login: \PracticeAutomation\appsettings.json
3. Environments : \PracticeAutomation\appsettings.json
4. Browsers: \PracticeAutomation\appsettings.json

How to run?

1. Download the project
2. Extract it to a folder path
3. Find the project path like "C:\Users\amir.saleh\Documents\GitHub\PracticeAutomation\PracticeAutomation\bin\Debug\netcoreapp3.1"
4. Open CMD as administrator
5. open the project path
6. write this commant line: dotnet test PracticeAutomation.dll 

How to open Reports?

You can find the report of last run here: \PracticeAutomation\Files\TestReports



--------------------------------------------------------------------------------------------------


Nugets used
"nunit": Unittest
"NUnit3TestAdapter": Unittest
"Selenium.Chrome.WebDriver": ChromeDriver
"Selenium.Firefox.WebDriver": FirefoxDriver
"Selenium.Support": Selenium Support (select from dropdown)
"Selenium.WebDriver": Selenium webdriver
"DotNetSeleniumExtras.WaitHelpers": for future use (Wait Conditions)
"ExcelDataReader": Reading excel 
"ExcelDataReader.DataSet": Reading excel
"ExtentReports.Core": Reporting
"Microsoft.Extensions.Configuration": Configuration
"Microsoft.Extensions.Configuration.FileExtensions": Configuration
"Microsoft.Extensions.Configuration.Json": Configuration
"System.Configuration.ConfigurationManager": Configuration
"System.Runtime.Extensions": Runtime




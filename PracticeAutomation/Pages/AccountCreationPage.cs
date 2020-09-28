using ExcelDataReader;
using OpenQA.Selenium;
using PracticeAutomation.Models;
using PracticeAutomation.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using OpenQA.Selenium.Support.UI;


namespace PracticeAutomation.Pages
{
    class AccountCreationPage
    {
        #region Properties
        private IWebDriver driver;

      
        By TitleMrRadioBtn = By.CssSelector("label[for='id_gender1']");
        By TitleMrsRadioBtn = By.CssSelector("label[for='id_gender2']");

        By FirstNameTxtBox = By.Id("customer_firstname");
        By LastNameTxtBox = By.Id("customer_lastname");
        By PasswordTxtBox = By.Id("passwd");
        By BirthDateSelectDay = By.Id("days");
        By BirthDateSelectMonth = By.Id("months");
        By BirthDateSelectYear = By.Id("years");
        By NewsletterChkBox = By.Id("newsletter");
        By OptinChkBox = By.Id("optin");
        By AddressFirstNameTxtBox = By.Id("firstname");
        By AddressLastNameTxtBox = By.Id("lastname");
        By CompanyTxtBox = By.Id("company");
        By Address1TxtBox = By.Id("address1");
        By Address2TxtBox = By.Id("address2");
        By CityTxtBox = By.Id("city");
        By StateSelect = By.Id("id_state");
        By PostalCodeTxtBox = By.Id("postcode");
        By CountrySelect = By.Id("id_country");
        By AdditionalInfoTxtArea = By.Id("other");
        By HomePhoneTxtBox = By.Id("phone");
        By MobilePhoneTxtBox = By.Id("phone_mobile");
        By AddressAlLiasTxtBox = By.Id("alias");
        By RegisterBtn = By.Id("submitAccount");
        #endregion

        #region Constructor
        public AccountCreationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Methods
        public string FillRegistrationDataAndSubmit()
        {
          

            AccountCreationPageModel obj = ReadExcelSheet();
            if (obj.Title == "Mr")
                driver.FindElement(TitleMrRadioBtn).Click();
            else if (obj.Title=="Mrs")
                driver.FindElement(TitleMrsRadioBtn).Click();

            driver.FindElement(FirstNameTxtBox).SendKeys(obj.FirstName);
            driver.FindElement(LastNameTxtBox).SendKeys(obj.LastName);
            driver.FindElement(PasswordTxtBox).SendKeys(obj.Password);
            SelectElement drpDay = new SelectElement(driver.FindElement(BirthDateSelectDay));
            drpDay.SelectByValue(obj.Day);
            SelectElement drpMonth= new SelectElement(driver.FindElement(BirthDateSelectMonth));
            drpMonth.SelectByValue(obj.Month);
            SelectElement drpYear = new SelectElement(driver.FindElement(BirthDateSelectYear));
            drpYear.SelectByValue(obj.Year);
            if (obj.Newsletter == "TRUE")
                driver.FindElement(NewsletterChkBox).Click();
            if (obj.Optin == "TRUE")
                driver.FindElement(OptinChkBox).Click();
            driver.FindElement(CompanyTxtBox).SendKeys(obj.Company);
            driver.FindElement(Address1TxtBox).SendKeys(obj.Address);
            driver.FindElement(Address2TxtBox).SendKeys(obj.Address2);
            driver.FindElement(CityTxtBox).SendKeys(obj.City);
            SelectElement drpState = new SelectElement(driver.FindElement(StateSelect));
            drpState.SelectByText(obj.State);
            driver.FindElement(PostalCodeTxtBox).SendKeys(obj.PostalCode);
            SelectElement drpCountry = new SelectElement(driver.FindElement(CountrySelect));
            drpCountry.SelectByText(obj.Country);
            driver.FindElement(AdditionalInfoTxtArea).SendKeys(obj.AdditionalInfo);
            driver.FindElement(HomePhoneTxtBox).SendKeys(obj.HomePhone);
            driver.FindElement(MobilePhoneTxtBox).SendKeys(obj.MobilePhone);
            driver.FindElement(AddressAlLiasTxtBox).SendKeys(obj.AddressAllias);

            driver.FindElement(RegisterBtn).Click();

            return obj.FirstName + " " + obj.LastName;


        }
        
        static public AccountCreationPageModel ReadExcelSheet()
        {
            int RowNumber = Helper.GetRandomNumber(0, 10);
            AccountCreationPageModel RegData = new AccountCreationPageModel();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //open file and returns as Stream

            var stream = File.Open(@"..\..\..\Files\TestData\RegistrationData.xlsx", FileMode.Open, FileAccess.Read);
            using (var excelReader = ExcelReaderFactory.CreateReader(stream))
            {
                DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                DataTable dt = result.Tables[0];


                int coulmnCount = result.Tables[0].Columns.Count;
                RegData.Title = dt.Rows[RowNumber][0].ToString();
                RegData.FirstName = dt.Rows[RowNumber][1].ToString();
                RegData.LastName = dt.Rows[RowNumber][2].ToString();
                RegData.Email = dt.Rows[RowNumber][3].ToString();
                RegData.Password = dt.Rows[RowNumber][4].ToString();
                RegData.Day = dt.Rows[RowNumber][5].ToString();
                RegData.Month = dt.Rows[RowNumber][6].ToString();
                RegData.Year = dt.Rows[RowNumber][7].ToString();
                RegData.Newsletter = dt.Rows[RowNumber][8].ToString();
                RegData.Optin = dt.Rows[RowNumber][9].ToString();
                RegData.Company = dt.Rows[RowNumber][10].ToString();
                RegData.Address = dt.Rows[RowNumber][11].ToString();
                RegData.Address2 = dt.Rows[RowNumber][12].ToString();
                RegData.City = dt.Rows[RowNumber][13].ToString();
                RegData.State = dt.Rows[RowNumber][14].ToString();
                RegData.PostalCode = dt.Rows[RowNumber][15].ToString();
                RegData.Country = dt.Rows[RowNumber][16].ToString();
                RegData.AdditionalInfo = dt.Rows[RowNumber][17].ToString();
                RegData.HomePhone = dt.Rows[RowNumber][18].ToString();
                RegData.MobilePhone = dt.Rows[RowNumber][19].ToString();
                RegData.AddressAllias = dt.Rows[RowNumber][20].ToString();


                //for (int i=0; i< result.Tables[0].Columns.Count;i++)
                //{
                //    if(result.Tables[0].Columns[i].ColumnName=='')

                //}
                //foreach (DataColumn col in result.Tables[0].Columns)
                //{
                //    foreach (DataRow row in result.Tables[0].Rows)
                //    {
                //        var x= row[col.ColumnName].ToString();
                //    }
                //}
                excelReader.Close(); excelReader.Close();
            }


            //FileStream stream = File.Open(@"D:\Projects\PracticeAutomation\PracticeAutomation\Files\TestData\RegistrationData.xlsx", FileMode.Open, FileAccess.Read);
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            return RegData;
        }
        #endregion

    }
}

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

        private IWebElement TitleMrRadioBtnElement => driver.FindElement(By.CssSelector("label[for='id_gender1']"));
        private IWebElement TitleMrsRadioBtnElement => driver.FindElement(By.CssSelector("label[for='id_gender2']"));
        private IWebElement FirstNameTxtBoxElement => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement LastNameTxtBoxElement => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement PasswordTxtBoxElement => driver.FindElement(By.Id("passwd"));
        private IWebElement BirthDateSelectDayElement => driver.FindElement(By.Id("days"));
        private IWebElement BirthDateSelectMonthElement => driver.FindElement(By.Id("months"));
        private IWebElement BirthDateSelectYearElement => driver.FindElement(By.Id("years"));
        private IWebElement NewsletterChkBoxElement => driver.FindElement(By.Id("newsletter"));
        private IWebElement OptinChkBoxElement => driver.FindElement(By.Id("optin"));
        private IWebElement AddressFirstNameTxtBoxElement => driver.FindElement(By.Id("firstname"));
        private IWebElement AddressLastNameTxtBoxElement => driver.FindElement(By.Id("lastname"));
        private IWebElement CompanyTxtBoxElement => driver.FindElement(By.Id("company"));
        private IWebElement Address1TxtBoxElement => driver.FindElement(By.Id("address1"));
        private IWebElement Address2TxtBoxElement => driver.FindElement(By.Id("address2"));
        private IWebElement CityTxtBoxElement => driver.FindElement(By.Id("city"));
        private IWebElement StateSelectElement => driver.FindElement(By.Id("id_state"));
        private IWebElement PostalCodeTxtBoxElement => driver.FindElement(By.Id("postcode"));
        private IWebElement CountrySelectElement => driver.FindElement(By.Id("id_country"));
        private IWebElement AdditionalInfoTxtAreaElement => driver.FindElement(By.Id("other"));
        private IWebElement HomePhoneTxtBoxElement => driver.FindElement(By.Id("phone"));
        private IWebElement MobilePhoneTxtBoxElement => driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AddressAlLiasTxtBoxElement => driver.FindElement(By.Id("alias"));
        private IWebElement RegisterBtnElement => driver.FindElement(By.Id("submitAccount"));
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
                TitleMrRadioBtnElement.Click();
            else if (obj.Title=="Mrs")
                TitleMrsRadioBtnElement.Click();

            FirstNameTxtBoxElement.SendKeys(obj.FirstName);
            LastNameTxtBoxElement.SendKeys(obj.LastName);
            PasswordTxtBoxElement.SendKeys(obj.Password);
            SelectElement drpDay = new SelectElement(BirthDateSelectDayElement);
            drpDay.SelectByValue(obj.Day);
            SelectElement drpMonth= new SelectElement(BirthDateSelectMonthElement);
            drpMonth.SelectByValue(obj.Month);
            SelectElement drpYear = new SelectElement(BirthDateSelectYearElement);
            drpYear.SelectByValue(obj.Year);
            if (obj.Newsletter == "TRUE")
                NewsletterChkBoxElement.Click();
            if (obj.Optin == "TRUE")
                OptinChkBoxElement.Click();
            CompanyTxtBoxElement.SendKeys(obj.Company);
            Address1TxtBoxElement.SendKeys(obj.Address);
            Address2TxtBoxElement.SendKeys(obj.Address2);
            CityTxtBoxElement.SendKeys(obj.City);
            SelectElement drpState = new SelectElement(StateSelectElement);
            drpState.SelectByText(obj.State);
            PostalCodeTxtBoxElement.SendKeys(obj.PostalCode);
            SelectElement drpCountry = new SelectElement(CountrySelectElement);
            drpCountry.SelectByText(obj.Country);
            AdditionalInfoTxtAreaElement.SendKeys(obj.AdditionalInfo);
            HomePhoneTxtBoxElement.SendKeys(obj.HomePhone);
            MobilePhoneTxtBoxElement.SendKeys(obj.MobilePhone);
            AddressAlLiasTxtBoxElement.SendKeys(obj.AddressAllias);

            RegisterBtnElement.Click();

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

                excelReader.Close(); excelReader.Close();
            }

            return RegData;
        }
        #endregion

    }
}

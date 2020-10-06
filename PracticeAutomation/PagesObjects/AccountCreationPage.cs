using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticeAutomation.PagesModels;
using PracticeAutomation.Utility;
using System.Data;


namespace PracticeAutomation.PagesObjects
{
    public class AccountCreationPage
    {
        #region Elements
        private IWebElement TitleMrRadioBtnElement => Driver.FindElement(By.CssSelector("label[for='id_gender1']"));
        private IWebElement TitleMrsRadioBtnElement => Driver.FindElement(By.CssSelector("label[for='id_gender2']"));
        private IWebElement FirstNameTxtBoxElement => Driver.FindElement(By.Id("customer_firstname"));
        private IWebElement LastNameTxtBoxElement => Driver.FindElement(By.Id("customer_lastname"));
        private IWebElement PasswordTxtBoxElement => Driver.FindElement(By.Id("passwd"));
        private IWebElement BirthDateSelectDayElement => Driver.FindElement(By.Id("days"));
        private IWebElement BirthDateSelectMonthElement => Driver.FindElement(By.Id("months"));
        private IWebElement BirthDateSelectYearElement => Driver.FindElement(By.Id("years"));
        private IWebElement NewsletterChkBoxElement => Driver.FindElement(By.Id("newsletter"));
        private IWebElement OptinChkBoxElement => Driver.FindElement(By.Id("optin"));
        private IWebElement AddressFirstNameTxtBoxElement => Driver.FindElement(By.Id("firstname"));
        private IWebElement AddressLastNameTxtBoxElement => Driver.FindElement(By.Id("lastname"));
        private IWebElement CompanyTxtBoxElement => Driver.FindElement(By.Id("company"));
        private IWebElement Address1TxtBoxElement => Driver.FindElement(By.Id("address1"));
        private IWebElement Address2TxtBoxElement => Driver.FindElement(By.Id("address2"));
        private IWebElement CityTxtBoxElement => Driver.FindElement(By.Id("city"));
        private IWebElement StateSelectElement => Driver.FindElement(By.Id("id_state"));
        private IWebElement PostalCodeTxtBoxElement => Driver.FindElement(By.Id("postcode"));
        private IWebElement CountrySelectElement => Driver.FindElement(By.Id("id_country"));
        private IWebElement AdditionalInfoTxtAreaElement => Driver.FindElement(By.Id("other"));
        private IWebElement HomePhoneTxtBoxElement => Driver.FindElement(By.Id("phone"));
        private IWebElement MobilePhoneTxtBoxElement => Driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AddressAlLiasTxtBoxElement => Driver.FindElement(By.Id("alias"));
        private IWebElement RegisterBtnElement => Driver.FindElement(By.Id("submitAccount"));
        #endregion

        #region Methods
        public string FillRegistrationDataAndSubmit()
        {
            int RowNumber = Helper.GetRandomNumber(0, 10);

            string filePath = @"..\..\..\Files\TestData\RegistrationData.xlsx";
            ExcelReader excelReader = new ExcelReader();
            DataTable dataTable = excelReader.ReadExcelSheet(filePath);

            AccountCreationPageModel obj = new AccountCreationPageModel();

            obj.Title = dataTable.Rows[RowNumber][0].ToString();
            obj.FirstName = dataTable.Rows[RowNumber][1].ToString();
            obj.LastName = dataTable.Rows[RowNumber][2].ToString();
            obj.Email = dataTable.Rows[RowNumber][3].ToString();
            obj.Password = dataTable.Rows[RowNumber][4].ToString();
            obj.Day = dataTable.Rows[RowNumber][5].ToString();
            obj.Month = dataTable.Rows[RowNumber][6].ToString();
            obj.Year = dataTable.Rows[RowNumber][7].ToString();
            obj.Newsletter = dataTable.Rows[RowNumber][8].ToString();
            obj.Optin = dataTable.Rows[RowNumber][9].ToString();
            obj.Company = dataTable.Rows[RowNumber][10].ToString();
            obj.Address = dataTable.Rows[RowNumber][11].ToString();
            obj.Address2 = dataTable.Rows[RowNumber][12].ToString();
            obj.City = dataTable.Rows[RowNumber][13].ToString();
            obj.State = dataTable.Rows[RowNumber][14].ToString();
            obj.PostalCode = dataTable.Rows[RowNumber][15].ToString();
            obj.Country = dataTable.Rows[RowNumber][16].ToString();
            obj.AdditionalInfo = dataTable.Rows[RowNumber][17].ToString();
            obj.HomePhone = dataTable.Rows[RowNumber][18].ToString();
            obj.MobilePhone = dataTable.Rows[RowNumber][19].ToString();
            obj.AddressAllias = dataTable.Rows[RowNumber][20].ToString();


            if (obj.Title == "Mr")
                TitleMrRadioBtnElement.Click();
            else if (obj.Title == "Mrs")
                TitleMrsRadioBtnElement.Click();

            FirstNameTxtBoxElement.SendKeys(obj.FirstName);
            LastNameTxtBoxElement.SendKeys(obj.LastName);
            PasswordTxtBoxElement.SendKeys(obj.Password);
            SelectElement drpDay = new SelectElement(BirthDateSelectDayElement);
            drpDay.SelectByValue(obj.Day);
            SelectElement drpMonth = new SelectElement(BirthDateSelectMonthElement);
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
        #endregion

    }
}

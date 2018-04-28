/* SeleniumTest.cs
 * 
 * SeleniumTest for Assignment 4
 * 
 * Revision History
 *      Jaden Ahn, 2018.04.06: Created
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Assignment04
{
    [TestFixture]
    public class SeleniumTest
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //If using the same URL several times
            baseURL = "http://localhost:8080/#pgRegister";
        }

        [TearDown]
        public void TeardownTest()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Test]
        public void QualityCarSalesSearchPage_H2TitleSaysRegisteredUsedCars()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/#pgSearch");
            string title = driver.FindElement(By.Id("searchTitle")).Text;
            //This test will pass
            Assert.AreEqual("Registered used cars", title);
        }


        [Test]
        public void QualityCarSales_InputDodgeJourney2013_DodgeJourney2013AppearsInJDCpageTitle()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("Jaden Ahn");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("123 Brookfield Drive");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Kitchener");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("236-879-2457");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("jahn2488@conestogac.on.ca");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Dodge");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Journey");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2013");
            driver.FindElement(By.Id("btnRegister")).Click();
            driver.FindElement(By.Id("linkToJDC")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.Contains("2013 Dodge Journey"));
        }

        [Test]
        public void QualityCarSales_InputWrongPhoneFormat_txtPhoneErrorSaysWrongFormat()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("Aubrey");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("456 Kingway Drive");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Guelph");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("1234567890");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("aub@gmail.com");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Lamborghini");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Murcielago");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2010");
            driver.FindElement(By.Id("btnRegister")).Click();

            string error = driver.FindElement(By.Id("txtPhone-error")).Text;
            Assert.AreEqual("Wrong format", error);
        }

        [Test]
        public void QualityCarSales_NotInputName_txtNameErrorSaysSellerNameRequired()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("456 Kingway Drive");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Waterloo");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("(236)879-2458");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("aub@gmail.com");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Lamborghini");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Murcielago");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2010");
            driver.FindElement(By.Id("btnRegister")).Click();

            string error = driver.FindElement(By.Id("txtName-error")).Text;
            Assert.AreEqual("Seller Name required", error);
        }

        [Test]
        public void QualityCarSales_NotInputAddress_txtAddressErrorSaysAddressRequired()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("Chevy");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Waterloo");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("236-879-2458");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("aub@gmail.com");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Lamborghini");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Murcielago");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2010");
            driver.FindElement(By.Id("btnRegister")).Click();

            string error = driver.FindElement(By.Id("txtAddress-error")).Text;
            Assert.AreEqual("Address required", error);
        }

        [Test]
        public void QualityCarSales_NotInputCity_txtCityErrorSaysCityRequired()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("Chevy");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("456 Kingway Drive");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("236-879-2458");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("aub@gmail.com");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Lamborghini");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Murcielago");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2010");
            driver.FindElement(By.Id("btnRegister")).Click();

            string error = driver.FindElement(By.Id("txtCity-error")).Text;
            Assert.AreEqual("City required", error);
        }

        [Test]
        public void QualityCarSales_InputWrongEmailFormat_txtEmailErrorSaysWrongFormat()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtName")).Clear();
            driver.FindElement(By.Id("txtName")).SendKeys("Brad");
            driver.FindElement(By.Id("txtAddress")).Clear();
            driver.FindElement(By.Id("txtAddress")).SendKeys("789 Somewhere Street");
            driver.FindElement(By.Id("txtCity")).Clear();
            driver.FindElement(By.Id("txtCity")).SendKeys("Cambridge");
            driver.FindElement(By.Id("txtPhone")).Clear();
            driver.FindElement(By.Id("txtPhone")).SendKeys("245-121-2451");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("brad.gmail.com");
            driver.FindElement(By.Id("txtMake")).Clear();
            driver.FindElement(By.Id("txtMake")).SendKeys("Porsche");
            driver.FindElement(By.Id("txtModel")).Clear();
            driver.FindElement(By.Id("txtModel")).SendKeys("Cayman");
            driver.FindElement(By.Id("txtYear")).Clear();
            driver.FindElement(By.Id("txtYear")).SendKeys("2012");
            driver.FindElement(By.Id("btnRegister")).Click();

            string error = driver.FindElement(By.Id("txtEmail-error")).Text;
            Assert.AreEqual("Please enter a valid email address.", error);
        }
    }
}

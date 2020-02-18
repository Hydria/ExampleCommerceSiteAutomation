using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumPractice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExampleCommerceSiteAutomation
{
    class Methods
    {
        private IWebDriver driver = PropertiesCollection.driver; //initalise the driver

        public void TestLinkID(string value, string link)
        {
            IWebElement LinkTest = driver.FindElement(By.Id(value)); //find element by ID
            LinkTest.Click(); //click element
            if (driver.Url != link)
            {   //if the url of the page does not match the link provided, fail test
                Assert.Fail(value + " did not link to " + link + ", it linked to " + driver.Url);
            }
            driver.Navigate().Back(); //start next test from homepage
        }

        public void TestLinkClass(string value, string link)
        {
            IWebElement LinkTest = driver.FindElement(By.ClassName(value)); //find element by class
            LinkTest.Click(); //click element
            if (driver.Url != link)
            {   //if the url of the page does not match the link provided, fail test
                Assert.Fail(value + " did not link to " + link + ", it linked to " + driver.Url);
            }
            driver.Navigate().Back(); //start next test from homepage
        }

        public void TestLinkName(string value, string link)
        {
            IWebElement LinkTest = driver.FindElement(By.Name(value)); //find element by name
            LinkTest.Click(); //click element
            if (driver.Url != link)
            {   //if the url of the page does not match the link provided, fail test
                Assert.Fail(value + " did not link to " + link + ", it linked to " + driver.Url);
            }
            driver.Navigate().Back(); //start next test from homepage
        }

        public void TestLinkXPath(string value, string link, string hoverlink = "")
        {
            if (hoverlink == "") //if link isn't in a hoverlist
            {
                IWebElement LinkTest = driver.FindElement(By.XPath(value));//find element by xpath
                LinkTest.Click();//click element
            }
            else
            {   // test for hover lists (doesn't work)
                Actions actions = new Actions(driver); //initalise that mouse movement
                IWebElement LinkTest = driver.FindElement(By.XPath(hoverlink)); //find element that hovers
                actions.MoveToElement(LinkTest).Perform(); //move to hover element so it activates
                WaitForXPath(value); //wait for element that we need to show up
                LinkTest = driver.FindElement(By.XPath(value)); //find element
                LinkTest.Click(); //click element
            }

            if (driver.Url != link)
            {   //if the url of the page does not match the link provided, fail test
                Assert.Fail(value + " did not link to " + link + ", it linked to " + driver.Url);
            }
            driver.Navigate().Back(); //start next test from homepage
        }

        /*public void TestLinkCSS(string value, string link) //doesn't work
        {
            string cssinput = "css=input[class='" + value + "']";
            IWebElement LinkTest = driver.FindElement(By.CssSelector(cssinput));
            LinkTest.Click();
            if (driver.Url != link)
            {
                Assert.Fail(value + " did not link to " + link + ", it linked to " + driver.Url);
            }
            driver.Navigate().Back();
        }*/

        public void ClickXPath(string value)
        {
            IWebElement LinkTest = driver.FindElement(By.XPath(value)); //find element by xpath
            LinkTest.Click(); //click element
        }

        public void ClickID(string value)
        {
            IWebElement LinkTest = driver.FindElement(By.Id(value)); //find element by ID
            LinkTest.Click(); //click element
        }

        public void DropDownSelect(string value, string text)
        {
            IWebElement DropDownSelection = driver.FindElement(By.Id(value)); //find dropdown list by id
            new SelectElement(DropDownSelection).SelectByText(text); //select the drop down option that matches the text
        }

        public void WaitForXPath(string value)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10)); //waiting init
            wait.Until(x => x.FindElement(By.XPath(value))); //wait until the element is found
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(value))); //wait until the element can be clicked
        }

        public void WaitForID(string value)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10)); //waiting init
            wait.Until(x => x.FindElement(By.Id(value))); //wait until the element is found
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(value))); //wait until the element can be clicked
        }

        public void SetPopUp(bool Popup)
        {
            //test for windows-based popups (like they exist anymore)
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles; //init multiple windows
            if (Popup == true) //if popup is shown
                driver.SwitchTo().Window(windowHandles[1]); //switch to popup
            else if (Popup == false) //if popup no longer there
                driver.SwitchTo().Window(windowHandles[0]); //switch to main window
        }

        public void EnterText(string textbox, string text)
        {
            IWebElement element = PropertiesCollection.driver.FindElement(By.Id(textbox)); //find textbox by ID
            element.SendKeys(text); //enter the text into the textbox
        }

        public void GetTextXPath(string value, string text)
        {
            IWebElement LinkTest = driver.FindElement(By.XPath(value)); //find element by xpath
            string insidetext = LinkTest.Text; //put the text in the element into a string
            if (insidetext != text)
            {   //test string against user provided text, if not matching, fail the test
                Assert.Fail(text + " does not match " + insidetext);
            }
        }

        public void CheckAddress(string FullName, string Company, string Street, string Town, string Country, string PhoneNumber)
        {   //tests fullname, company, street, town, country and placeholder to what the user expected in that order
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_firstname address_lastname']", FullName);
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_company']", Company);
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_address1 address_address2']", Street);
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_city address_state_name address_postcode']", Town);
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_country_name']", Country);
            GetTextXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/div[@class='addresses clearfix']/div[@class='row'][2]/div[@class='col-xs-12 col-sm-6'][1]/ul[@id='address_delivery']/li[@class='address_phone']", PhoneNumber);
        }
    }
}

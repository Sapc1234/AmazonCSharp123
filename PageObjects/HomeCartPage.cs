using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
    public class HomeCartPage
    {
        private By homePageCart = By.CssSelector("a[id='nav-cart']");
        private By clickonAmazonLogo = By.XPath("//div[@id='nav-logo']/a");
       
        public IWebDriver driver;
      
        public HomeCartPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        public void backToCart()

        {
            driver.FindElement(homePageCart).Click();

            Thread.Sleep(5000);
            driver.FindElement(clickonAmazonLogo).Click();

           


        }
    }
}

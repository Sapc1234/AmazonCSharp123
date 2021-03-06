using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
    public class ProductDescription
    {
        private By selectquantity = By.XPath("//select[@id='quantity']");
        private By clickaddToCart = By.XPath("//input[@name='submit.add-to-cart']");
        
        public IWebDriver driver;
       
        public ProductDescription(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void selecttQuantity()
        {
            IWebElement staticdropDown = driver.FindElement(selectquantity);
            SelectElement sd = new SelectElement(staticdropDown);
            sd.SelectByValue("3");
        }

        public void clickonAddToCart()
        {
            driver.FindElement(clickaddToCart).Click();
        }

    }
}

﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
    public class scrollDown
    {
        private IWebDriver driver;
        private By cScroll = By.XPath("//div[@class='navFooterLine']");
        private By selectLang = By.XPath("//a[@id='icp-touch-link-language']");
        //private By selectLanguage = By.XPath("//div[@class='navFooterLine']/a[@id='icp-touch-link-language']");


        public scrollDown(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void footer()
        {
            IWebElement cs = driver.FindElement(cScroll);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", cs);

            Thread.Sleep(5000);
            Actions a1 = new Actions(driver);
            a1.MoveToElement(driver.FindElement(selectLang)).Click().Perform();

           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selectLang));
        }
    }
}
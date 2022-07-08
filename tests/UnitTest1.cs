using Amazon.PageObjects;
using Amazon.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon
{
   
    public class Tests : Base 
    {
        [Test, Order(1)]
        [TestCase("8073048760", "Sapc@1234")]

        public void validLoginCredential(String UsrName, String Password)
        {
            LoginPage lp = new LoginPage(getDriver());
            lp.pointerMoveOnsignIn();
            lp.amazonuserName(UsrName);
            lp.clickOnContinue();
            lp.amazonPassword(Password);
            lp.clickOnSigninButton();

            var actualName = driver.FindElement(By.XPath("//div[@class='nav-line-1-container']/span[@id='nav-link-accountList-nav-line-1']"));
            Assert.AreEqual("Hello, sharanabasappa", actualName.Text); ;



        }

        [Test, Order(2)]
        public void productSearch()

        {

            ItemSearch itemSearch = new ItemSearch(getDriver());
            itemSearch.searchItem("Samsung Galaxy M53 5G");
            itemSearch.clickOnSearchbutton();
          
            String atext = itemSearch.getText().Text;
            String[] splittedText = atext.Split("(");
            String trimmedAText = splittedText[0].Trim();

            itemSearch.clickOnSearchbutton();
            Assert.AreEqual("Samsung Galaxy M53 5G", trimmedAText);



        }
        [Test, Order(3)]

        public void productAddedintoTheCart()

        {

            String parentWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.XPath("//div[contains(@class,'rush-component s-featured-result-item')]//span[@class='a-size-medium a-color-base a-text-normal'][contains(text(),'Samsung Galaxy M53 5G (Mystique Green, 6GB, 128GB ')]")).Click();


            String childWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);
            addToCart atc = new addToCart(getDriver());
            atc.selecttQuantity();
            atc.clickonAddToCart();
            driver.SwitchTo().Window(parentWindow);
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }

        [Test, Order(4)]

        public void goBackToCart()

        {
            HomeCartPage hcp = new HomeCartPage(getDriver());
            hcp.backToCart();
            Assert.IsTrue(driver.FindElement(By.CssSelector("a[id='nav-cart']")).Enabled);

        }

        [Test,Order(5)]

        public void scrollUptoFooter()
        {
            scrollDown sd = new scrollDown(getDriver());
            sd.footer();
         
        }

        [Test,Order(6)]

        public void clickOnRadioButtons()
        {
            driver.SwitchTo().DefaultContent();
            RadioButtons rd = new RadioButtons(getDriver());
            rd.radioButton();
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='a-radio a-radio-fancy']/label/input[@value='kn_IN']")).Selected);
        }

      





        //driver.FindElement(By.XPath("//input[@name='submit.delete.C92499178-c959-49f6-afd5-5a94424eaa3a']")).Click();
        //submit.delete.C92499178-c959-49f6-afd5-5a94424eaa3a


        // String confirText = driver.FindElement(By.XPath("//div[@class='a-section a-spacing-mini sc-list-body sc-java-remote-feature']//div[2]")).Text;

        //TestContext.Progress.WriteLine(confirText);

        //StringAssert.Contains("Samsung Galaxy M53 5G (Mystique Green, 6GB, 128GB Storage) | 108... was removed from Shopping Cart.", confirText);







    }
}

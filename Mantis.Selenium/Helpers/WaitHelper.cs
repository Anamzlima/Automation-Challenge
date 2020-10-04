using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Mantis.Selenium.Helpers
{
    public class WaitHelper
    {
        private IWebDriver driver;
        private WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UntilIsVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}

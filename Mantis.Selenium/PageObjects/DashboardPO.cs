using Mantis.Selenium.Helpers;
using OpenQA.Selenium;

namespace Mantis.Selenium.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By byReportIssue;
        private By byViewIssues;

        public DashboardPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);
            byReportIssue = By.LinkText("Report Issue");
            byViewIssues = By.LinkText("View Issues");            
        }

        public void ClicarLinkReportIssues()
        {
            wait.UntilIsVisible(byReportIssue);

            driver.FindElement(byReportIssue).Click();
        }

        public void ClicarLinkViewIssues()
        {
            wait.UntilIsVisible(byViewIssues);

            driver.FindElement(byViewIssues).Click();
        }
    }
}

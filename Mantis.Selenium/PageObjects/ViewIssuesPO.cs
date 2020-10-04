using Mantis.Selenium.Helpers;
using OpenQA.Selenium;

namespace Mantis.Selenium.PageObjects
{
    public class ViewIssuesPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By byIssuesTable;

        public ViewIssuesPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);

            byIssuesTable = By.Id("buglist");
        }

        public bool TabelaBugsEstaVisivel()
        {
            wait.UntilIsVisible(byIssuesTable);
            return driver.FindElement(byIssuesTable).Displayed;
        }
    }
}

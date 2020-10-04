using Mantis.Selenium.Helpers;
using OpenQA.Selenium;

namespace Mantis.Selenium.PageObjects
{
    public class SelecionarProjetoDoErroPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By bySelectProject;
        private By byBotaoSubmeter;

        public SelecionarProjetoDoErroPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);

            bySelectProject = By.Name("project_id");
            byBotaoSubmeter = By.ClassName("button");
        }

        public void SelecionaProjeto(string projeto)
        {
            wait.UntilIsVisible(bySelectProject);

            driver.FindElement(bySelectProject).SendKeys(projeto);
        }

        public void SubmeteFormulario()
        {
            wait.UntilIsVisible(byBotaoSubmeter);

            driver.FindElement(byBotaoSubmeter).Submit();
        }
    }
}

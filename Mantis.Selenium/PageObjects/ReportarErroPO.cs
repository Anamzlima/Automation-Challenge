using Mantis.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mantis.Selenium.PageObjects
{
    public class ReportarErroPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By bySelectCategoria;
        private By byInputSummary;
        private By byInputDescription;
        private By byBotaoSubmit;

        public ReportarErroPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);

            bySelectCategoria = By.Name("category_id");
            byInputSummary = By.Name("summary");
            byInputDescription = By.Name("description");
            byBotaoSubmit = By.ClassName("button");
        }

        public void PreencherFormulario(string categoria,string resumo, string descricao)
        {
            wait.UntilIsVisible(bySelectCategoria);
            wait.UntilIsVisible(byInputSummary);
            wait.UntilIsVisible(byInputDescription);

            var categoriaSelect = new SelectElement(driver.FindElement(bySelectCategoria));
            categoriaSelect.SelectByText(categoria);

            driver.FindElement(byInputSummary).SendKeys(resumo);
            driver.FindElement(byInputDescription).SendKeys(descricao);
        }

        public void SubmeteFormulario()
        {
            wait.UntilIsVisible(byBotaoSubmit);

            driver.FindElement(byBotaoSubmit).Click();
        }
    }
}
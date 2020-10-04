using Mantis.Selenium.Helpers;
using OpenQA.Selenium;

namespace Mantis.Selenium.PageObjects
{
    public class ResetSenhaPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By byInputUsuario;
        private By byInputEmail;
        private By byBotaoEnviar;

        public ResetSenhaPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);

            byInputUsuario = By.Name("username");
            byInputEmail = By.Name("email");
            byBotaoEnviar = By.ClassName("button");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/lost_pwd_page.php");
        }

        public void PreencheLogin(string login)
        {
            wait.UntilIsVisible(byInputUsuario);
            driver.FindElement(byInputUsuario).SendKeys(login);
        }

        public void PreencheEmail(string senha)
        {
            wait.UntilIsVisible(byInputEmail);
            driver.FindElement(byInputEmail).SendKeys(senha);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBotaoEnviar).Submit();
        }
    }
}

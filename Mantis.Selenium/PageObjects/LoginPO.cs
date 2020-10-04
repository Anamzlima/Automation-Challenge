using Mantis.Selenium.Helpers;
using OpenQA.Selenium;

namespace Mantis.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private WaitHelper wait;

        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);

            byInputLogin = By.Name("username");
            byInputSenha = By.Name("password");
            byBotaoLogin = By.ClassName("button");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/");
        }

        public void PreencheLogin(string login)
        {
            wait.UntilIsVisible(byInputLogin);
            driver.FindElement(byInputLogin).SendKeys(login);
        }

        public void PreencheSenha(string senha)
        {
            wait.UntilIsVisible(byInputSenha);
            driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            wait.UntilIsVisible(byBotaoLogin);

            driver.FindElement(byBotaoLogin).Click();
        }

        public void LoginValido()
        {
            PreencheLogin("ana.lima");
            PreencheSenha("ana1234");
            SubmeteFormulario();            
        }
    }
}
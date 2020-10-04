using Mantis.Selenium.Fixtures;
using Mantis.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Mantis.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoTentarLogar
    {
        private IWebDriver driver;

        public AoTentarLogar(TestFixture fixture)
        {
            this.driver = fixture.Driver;
            //Thread.Sleep(3000);
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheLogin("ana.lima");
            loginPO.PreencheSenha("ana1234");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Logged in as:", driver.PageSource);
        }

        [Fact]
        public void DadoCredenciaisInvalidasMostrarErro()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheLogin("ana");
            loginPO.PreencheSenha("ana12");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Your account may be disabled or blocked", driver.PageSource);
        }
    }
}

using Mantis.Selenium.Fixtures;
using Mantis.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Mantis.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoResetarSenha
    {
        private IWebDriver driver;

        public AoResetarSenha(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisInvalidas()
        {
            //arrange
            var resetPO = new ResetSenhaPO(driver);
            resetPO.Visitar();
            resetPO.PreencheLogin("maria");
            resetPO.PreencheEmail("maria@gmail.com");

            //act
            resetPO.SubmeterFormulario();

            //asssert
            Assert.Contains("APPLICATION ERROR #1903", driver.PageSource);
        }

        [Fact]
        public void DadoCredenciaisValidas()
        {
            //arrange
            var resetPO = new ResetSenhaPO(driver);
            resetPO.Visitar();
            resetPO.PreencheLogin("ana.lima");
            resetPO.PreencheEmail("anamzlima@gmail.com");

            //act
            resetPO.SubmeterFormulario();

            //asssert
            Assert.Contains("Password Message Sent", driver.PageSource);
        }
    }
}

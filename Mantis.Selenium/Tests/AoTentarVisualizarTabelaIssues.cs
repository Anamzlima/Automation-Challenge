using Mantis.Selenium.Fixtures;
using Mantis.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Mantis.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoTentarVisualizarTabelaIssues
    {
        private IWebDriver driver;

        public AoTentarVisualizarTabelaIssues(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void TabelaViewIssuesEstaVisivel()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.LoginValido();

            var dashboardPO = new DashboardPO(driver);
            dashboardPO.ClicarLinkViewIssues();

            var viewIssuesPO = new ViewIssuesPO(driver);

            //act
            var tabelaEstaVisivel = viewIssuesPO.TabelaBugsEstaVisivel();

            //assert
            Assert.True(tabelaEstaVisivel);
        }
    }
}

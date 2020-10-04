using Mantis.Selenium.Fixtures;
using Mantis.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Mantis.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoReportarIssue
    {
        private IWebDriver driver;

        public AoReportarIssue(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoReportComCamposValidos()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.LoginValido();

            var dashboardPO = new DashboardPO(driver);
            dashboardPO.ClicarLinkReportIssues();

            var projetoPO = new SelecionarProjetoDoErroPO(driver);
            projetoPO.SelecionaProjeto("Ana Lima´s Project");
            projetoPO.SubmeteFormulario();

            var reportErroPO = new ReportarErroPO(driver);
            reportErroPO.PreencherFormulario("[All Projects] General", "ana7", "ana7");

            //act
            reportErroPO.SubmeteFormulario();

            //assert
            Assert.Contains("Operation successful", driver.PageSource);
        }

        [Fact]
        public void DadoReportSemCategoria()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.LoginValido();

            var dashboardPO = new DashboardPO(driver);
            dashboardPO.ClicarLinkReportIssues();

            var projetoPO = new SelecionarProjetoDoErroPO(driver);
            projetoPO.SelecionaProjeto("Ana Lima´s Project");
            projetoPO.SubmeteFormulario();

            var reportErroPO = new ReportarErroPO(driver);
            reportErroPO.PreencherFormulario("(select)", "ana7", "ana7");

            //act
            reportErroPO.SubmeteFormulario();

            //assert
            Assert.Contains("A necessary field \"Category\" was empty.", driver.PageSource);
        }

        [Fact]
        public void DadoReportSemSummary()
        {
            ////arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.LoginValido();

            var dashboardPO = new DashboardPO(driver);
            dashboardPO.ClicarLinkReportIssues();

            var projetoPO = new SelecionarProjetoDoErroPO(driver);
            projetoPO.SelecionaProjeto("Ana Lima´s Project");
            projetoPO.SubmeteFormulario();

            var reportErroPO = new ReportarErroPO(driver);
            reportErroPO.PreencherFormulario("[All Projects] General", "", "ana7");

            //act
            reportErroPO.SubmeteFormulario();

            //assert
            Assert.Contains("A necessary field \"Summary\" was empty.", driver.PageSource);
        }

        [Fact]
        public void DadoReportSemDescription()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.LoginValido();

            var dashboardPO = new DashboardPO(driver);
            dashboardPO.ClicarLinkReportIssues();

            var projetoPO = new SelecionarProjetoDoErroPO(driver);
            projetoPO.SelecionaProjeto("Ana Lima´s Project");
            projetoPO.SubmeteFormulario();

            var reportErroPO = new ReportarErroPO(driver);
            reportErroPO.PreencherFormulario("[All Projects] General", "ana7", "");

            //act
            reportErroPO.SubmeteFormulario();

            //assert
            Assert.Contains("A necessary field \"Description\" was empty.", driver.PageSource);
        }
    }
}

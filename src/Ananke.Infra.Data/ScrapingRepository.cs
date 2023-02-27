using Ananke.Domain.Entities;
using Ananke.Domain.Repository;
using PuppeteerSharp;
using System.Runtime.InteropServices;

namespace Ananke.Infra.Data
{
    public class ScrapingRepository : IScrapingRepository
    {
        private readonly string _matricula = "20161003300711";
        private readonly string _senha = "92056248";
        private readonly string _HomePageSolUrl = "https://sol.pucgoias.edu.br/aluno/";

        //public Task<List<Course>> GetCoursesAsync()
        //{
        //    var mock = new List<Course>()
        //    {
        //        new Course(),
        //        new Course()
        //    };

        //    mock[0].Name= "A";
        //    mock[1].SetNoteExam(Domain.Enums.ExamsSemester.FirstExam, 5);
        //    mock[1].Name = "B";

        //    return Task.FromResult(mock);
        //}

        public async Task<List<Course>> GetCoursesAsync()
        {
            var browser = await InitializeBrowserAsync();
            var home = await Login(browser);

            await (await home.WaitForXPathAsync("//*[@id=\"menu-principal\"]/a[9]/div")).ClickAsync();
            await ObterValoresDaTabelaNotasFrequencia(home);

            TimeSpan ts = new TimeSpan(0, 1, 0);
            Thread.Sleep(ts);


            return new List<Course>();
        }

        public async Task<IPage> Login(IBrowser browser)
        {
            var page = await browser.NewPageAsync();

            await page.GoToAsync(_HomePageSolUrl);

            await page.WaitForSelectorAsync("#matricula");
            await page.TypeAsync("#matricula", _matricula);

            await page.WaitForSelectorAsync("#matricula");
            await page.TypeAsync("body > div.container > div > div > form > input.p-top", _senha);

            await page.WaitForSelectorAsync("body > div.container > div > div > form > button");
            var loginButton = await page.QuerySelectorAsync("body > div.container > div > div > form > button");
            await loginButton.ClickAsync();

            return page;
        }

        public async Task ObterValoresDaTabelaNotasFrequencia(IPage page)
        {
            var queryXpath = "//*[@id=\"wrap\"]/div[2]/div/div/div/table";

            await page.WaitForXPathAsync(queryXpath);
            var rows = await page.QuerySelectorAllAsync("#wrap > div.container > div > div > div > table > tbody > tr");

            var data = new Dictionary<string, Dictionary<string, string>>();
            var current = "";
            foreach (var row in rows)
            {
                var columns = await row.QuerySelectorAllAsync("td");

                var rowData = new Dictionary<string, string>();

                rowData["Disciplina"] = await columns[0].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Turma"] = await columns[1].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Aulas Previstas"] = await columns[2].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Aulas Ministradas"] = await columns[3].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Número de Presenças"] = await columns[4].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["N1"] = await columns[5].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["N2"] = await columns[6].EvaluateFunctionAsync<string>("node => node.innerText");
                
                current += $"{rowData["Disciplina"]} - {rowData["Turma"]} - {rowData["Aulas Previstas"]} - {rowData["Aulas Ministradas"]}- {rowData["Número de Presenças"]}- {rowData["N1"]}- {rowData["N2"]} \n";
                var key = $"{rowData["Disciplina"]} - {rowData["Turma"]}";
                data[key] = rowData;
            }
        }



        public static async Task<IBrowser> InitializeBrowserAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            var launchOptions = new LaunchOptions()
            {
                Headless = false
            };

            var browser = await Puppeteer.LaunchAsync(launchOptions);
            return browser;
        }

        public static async Task CloseBrowserAsync(IBrowser browser)
        {
            await browser.CloseAsync();
        }
    }
}

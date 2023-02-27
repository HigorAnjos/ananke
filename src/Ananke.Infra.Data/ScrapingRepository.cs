using Ananke.Domain.Entities;
using Ananke.Domain.Repository;
using PuppeteerSharp;

namespace Ananke.Infra.Data
{
    public class ScrapingRepository : IScrapingRepository
    {
        private readonly string _matricula = "20161003300711";
        private readonly string _senha = "92056248";
        private readonly string _HomePageSolUrl = "https://sol.pucgoias.edu.br/aluno/";
        private readonly string _GradesAttendanceQueryXpath = "//*[@id=\"menu-principal\"]/a[9]/div";

        public async Task<List<Course>> GetCoursesAsync()
        {
            var attempts = 0;
            var maxAttempts = 5;
            var error = "";
            while (attempts < maxAttempts)
            {
                try
                {
                    var courses = new List<Course>();

                    var browser = await InitializeBrowserAsync();

                    var home = await Login(browser);

                    home = await WaitAndClick(home, _GradesAttendanceQueryXpath);

                    var tableData = await ObterValoresDaTabelaNotasFrequencia(home);

                    DataTableCourse(ref courses, tableData);

                    await CloseBrowserAsync(browser);

                    return courses;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    attempts++;
                    error = err.Message;
                }
            }

            throw new Exception($"Scraping error: {error}");
        }

        public static async Task<IPage> WaitAndClick(IPage home, string selector)
        {
            var element = await home.WaitForXPathAsync(selector);
            await element.ClickAsync();
            return home;
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

        public async Task<Dictionary<string, Dictionary<string, string>>> ObterValoresDaTabelaNotasFrequencia(IPage page)
        {
            var queryXpath = "//*[@id=\"wrap\"]/div[2]/div/div/div/table";

            await page.WaitForXPathAsync(queryXpath);
            var rows = await page.QuerySelectorAllAsync("#wrap > div.container > div > div > div > table > tbody > tr");

            var data = new Dictionary<string, Dictionary<string, string>>();
            var current = "";

            var rowData = new Dictionary<string, string>();

            foreach (var row in rows)
            {
                var columns = await row.QuerySelectorAllAsync("td");

                rowData["Disciplina"] = await columns[0].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Turma"] = await columns[1].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Aulas Previstas"] = await columns[2].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Aulas Ministradas"] = await columns[3].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["Número de Presenças"] = await columns[4].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["N1"] = await columns[5].EvaluateFunctionAsync<string>("node => node.innerText");
                rowData["N2"] = await columns[6].EvaluateFunctionAsync<string>("node => node.innerText");

                current += $"{rowData["Disciplina"]} - {rowData["Turma"]} - {rowData["Aulas Previstas"]} - {rowData["Aulas Ministradas"]} - {rowData["Número de Presenças"]} - {rowData["N1"]} - {rowData["N2"]} \n";
                var key = $"{rowData["Disciplina"]} - {rowData["Turma"]}";
                data[key] = rowData;
            }

            return data;
        }

        public static void DataTableCourse(ref List<Course> courses, Dictionary<string, Dictionary<string, string>> dataTable)
        {
            foreach (var rowData in dataTable)
            {
                var disciplineAndClass = rowData.Key.Split(" - ");
                var discipline = disciplineAndClass[0];
                var classNumber = disciplineAndClass[1];

                var aulasPrevistas = Convert.ToInt32(rowData.Value["Aulas Previstas"]);
                var aulasMinistradas = Convert.ToInt32(rowData.Value["Aulas Ministradas"]);
                var numeroPresencas = Convert.ToInt32(rowData.Value["Número de Presenças"]);
                var n1 = (rowData.Value["N1"] == "x" || rowData.Value["N1"] == "X") ? 0.0 : Convert.ToDouble(rowData.Value["N1"]);
                var n2 = (rowData.Value["N2"] == "x" || rowData.Value["N2"] == "X") ? 0.0 : Convert.ToDouble(rowData.Value["N2"]);

                var course = new Course(discipline, classNumber, aulasPrevistas, aulasMinistradas, numeroPresencas, n1, n2);
                courses.Add(course);
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

            var page = await browser.NewPageAsync();
            await page.SetExtraHttpHeadersAsync(new Dictionary<string, string>()
            {
                { "Accept-Language", "en-US,en,pt-br;q=0.9" }
            });
            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36");

            return browser;
        }

        public static async Task CloseBrowserAsync(IBrowser browser)
        {
            await browser.CloseAsync();
        }
    }
}

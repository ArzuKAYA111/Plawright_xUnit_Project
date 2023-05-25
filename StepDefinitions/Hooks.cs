using Microsoft.Playwright;
using SpecFlow_Playwright.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace  SpecFlow_Playwright.StepDefinitions
{

    [Binding]

    public class Hooks : CommonMethods
    {

       public  IPage Driver { get; set; } = null!;

        public IBrowserContext context;
        public static int numberOfFailedTests;

        private ScenarioContext _scenarioContext;
       // public IPage _page;


public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }


        //before running each scenario it will be executed
        /*
         * initializing the playwright
         * 
         */

        [BeforeScenario]

        public async Task BeforeScenario()
        {
            var playwright =await Playwright.CreateAsync();
            var browser =await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Timeout=10000,
                SlowMo=50,


            });

          //  var context = await browser.NewContextAsync();!!!!!!!!!!!
            context = await browser.NewContextAsync();
            await context.Tracing.StartAsync(new()
            {
Screenshots=true,
Snapshots=true,
Sources=true,
            });


            Driver= await context.NewPageAsync();


            //Below code can be used in steps if URL will be different for testing
            // await _page.GotoAsync("https://www.amazon.com  ")

            // await _page.GotoAsync(ReadConfig("QAURL"));// >>we needd to create common method to read config file

            // await _page.GotoAsync(SetUpClass.URL);
            // await _page.WaitForLoadStateAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if(_scenarioContext.TestError !=null)
            {
              numberOfFailedTests++;   
        
                await context.Tracing.StopAsync(new()
                  {
                      //provide path where we would like to save screenshots
                      Path=$"{_scenarioContext.ScenarioInfo.Title}_{numberOfFailedTests}_trace.zip"
                  });


              //  await Driver.ScreenshotAsync(new PageScreenshotOptions
              //  { Path = $"{_scenarioContext.ScenarioInfo.Title}_{numberOfFailedTests}_trace.zip" });


                //      await context.CloseAsync(); 
                await Driver.CloseAsync() ;
            }
            else
            {
                // await context.CloseAsync();
                await Driver.CloseAsync();
            }
        }








    }
}

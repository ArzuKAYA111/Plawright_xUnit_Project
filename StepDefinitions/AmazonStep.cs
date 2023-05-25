using Microsoft.Playwright;
using SpecFlow_Playwright.Pages;
using SpecFlow_Playwright.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow_Playwright.StepDefinitions

{

    [Binding]
    public class AmazonStep :CommonMethods
    {
        private readonly IPage _page;
        private readonly AmazonPage _amazonPage;
        private ISpecFlowOutputHelper _specFlowOutputHelper;
        private ScenarioContext _scenarioContext;

        public AmazonStep(Hooks hooks, ISpecFlowOutputHelper  specFlowOutputHelper ,ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper= specFlowOutputHelper;
            _scenarioContext= scenarioContext;
            _page = hooks.Driver;
            _amazonPage= new AmazonPage(hooks, specFlowOutputHelper);
        }

        [Given(@"user navigetes to amazon")]
        public async void GivenUserNavigetesToAmazon()
        {
          
            await _page.GotoAsync("https://www.amazon.com");
            
        }

        [When(@"user cliks on the Todays Deal")]
        public async Task WhenUserCliksOnTheTodaysDeal()
        {

            await _amazonPage.TodaysDeal.ClickAsync();
        }

        [Then(@"user sees Todays Deal Text")]
        public async Task ThenUserSeesTodaysDealText()
        {

              var isVisiable=await  _amazonPage.AllDeals.IsVisibleAsync();

            _specFlowOutputHelper.WriteLine(await _amazonPage.AllDeals.TextContentAsync());
         
           
          //  Assert.True(isVisiable);
      
            Assert.Equal("Today's Deals", await _amazonPage.AllDeals.TextContentAsync());


        }


        [Then(@"Verify options are present")]
        public async Task ThenVerifyOptionsArePresent(Table table)
        {
            string prmErl = await _amazonPage.primeEarly.TextContentAsync();
            string prmExls = await _amazonPage.primeExclusive.TextContentAsync();


            List<string> expOpt=new List<string>();

            foreach (TableRow row in table.Rows)
            {
                foreach (string value in row.Values)
                {
                    _specFlowOutputHelper.WriteLine("Value :" + $"{value}");

                    expOpt.Add(value);

                }

            }



  /*          for (int i = 0;i<expOpt.Count;i++)
            {
                if (expOpt[i].Equals(prmErl)|| expOpt[i].Equals(prmExls))
                {
                    _specFlowOutputHelper.WriteLine("all options are present"); 
                }else
                {

                    _specFlowOutputHelper.WriteLine("options are not matching");
                }


            }*/



            List<string> actOpt = new List<string>();
            actOpt.Add(prmErl);

            actOpt.Add(prmExls);

            foreach (var item in actOpt)
            {
                _specFlowOutputHelper.WriteLine("options from acrual opt list " + item);
            }

            //     Assert.Exact(expOpt, actOpt);
            Assert.True(expOpt.SequenceEqual(actOpt));
            _specFlowOutputHelper.WriteLine("Test Copmleted ");



            
        }




    }
}

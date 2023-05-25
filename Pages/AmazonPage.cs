using Microsoft.Playwright;
using SpecFlow_Playwright.StepDefinitions;
using SpecFlow_Playwright.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow_Playwright.Pages
{
    public class AmazonPage: CommonMethods
    {
        private IPage _page;
        public ISpecFlowOutputHelper _specFlowOutputHelper;




        public AmazonPage(Hooks hooks, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _page = hooks.Driver;
            _specFlowOutputHelper = specFlowOutputHelper;

        }

        //initializing the elements 

        public ILocator TodaysDeal => _page.GetByRole(AriaRole.Link, new() { Name = "Today's Deals" });

        //  public ILocator AllDeals => _page.GetByTestId("grid-filter-AVAILABILITY");//.GetByRole(AriaRole.Button, new() { Name = "All deals" });
        public ILocator AllDeals => _page.Locator("//div[@id='slot-2']/div/h1");

        public ILocator primeEarly => _page.GetByText("Prime Early Access deals");
        public ILocator primeExclusive => _page.GetByText("Prime Exclusive deals");




    }
}

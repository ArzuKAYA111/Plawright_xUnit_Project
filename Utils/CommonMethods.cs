using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_Playwright.Utils
{
   public class CommonMethods
    {
        public static string GetConfig(string key)
        {

            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("app_set_data.json").Build().GetSection(key).v;
        }



    }
}

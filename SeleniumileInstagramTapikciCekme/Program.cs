using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SeleniumileInstagramTapikciCekme
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.instagram.com");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Siteye Hoşgeldiniz");
            Thread.Sleep(2000);

            IWebElement userName = webDriver.FindElement(By.Name("username"));
            IWebElement password = webDriver.FindElement(By.Name("password"));
            IWebElement login = webDriver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));

            userName.SendKeys("oguzgeylani");
            password.SendKeys("Oguzordu1.");
            login.Click();
            Console.WriteLine("Hesap bilgileri girildi");
            Thread.Sleep(3000);

            webDriver.Navigate().GoToUrl("https://www.instagram.com/oguzgeylani");
            Console.WriteLine("Profile yönlendirildi");
            Thread.Sleep(1000);

            IWebElement followerLink = webDriver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a"));
            followerLink.Click();
            Thread.Sleep(3000);



            string jsCommand = "" +
                "sayfa = document.querySelector('.isgrP');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfaSonu = sayfa.scrollHeight;" +
                "return sayfaSony";

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(1000);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                    break;
            }


            int sayac = 1;

            IReadOnlyCollection<IWebElement> followers = webDriver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));
            foreach (IWebElement follower in followers)
            {
                Console.WriteLine(sayac + "==>> " + follower.Text);
                sayac++;
            }



        }
    }
}

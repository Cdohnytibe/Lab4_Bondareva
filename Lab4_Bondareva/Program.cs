using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_Bondareva.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Lab4_Bondareva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(); // Создание объекта-браузера
            driver.Navigate().GoToUrl("https://pikabu.ru/best");
            var articles = driver.FindElements(By.ClassName("story"));

            Console.WriteLine(articles.Count);

            foreach (var article in articles)
            {
                var message = article.FindElement(By.ClassName("story__title")).Text;
                var name = article.GetAttribute("data-author-name");
                var id = article.GetAttribute("data-story-id");

                Console.WriteLine($"{id} - {name} - {message}");

                AppData.AddRecord(name, message);
            }
            driver.Quit();
        }
    }
}

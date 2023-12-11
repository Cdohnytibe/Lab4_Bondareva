using NUnit.Framework;
using System;
using Lab4_Bondareva.Models;
using Lab4_Bondareva;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void TestGetById(int id)
        {
            var actual = AppData.GetById(id);
            string expect = "Получение по ID";
            Assert.That(actual.ID, Is.EqualTo(expect));
        }

        [TestCase("bobrotermit")]
        [TestCase("specials")]
        [TestCase("Laukar")]
        public void TestGetByName(string name)
        {
            var actual = AppData.GetByName(name);
            string expect = "Получение по Name";
            Assert.That(actual.ID, Is.EqualTo(expect));
        }

        [TestCase("bobrotermit", "")]
        [TestCase("specials", "")]
        [TestCase("Laukar", "")]
        public void TestAddRecord(string name, string messege)
        {
            AppData.AddRecord(name, messege);
            Lab4Table actual = Controller.GoControl(name, messege);
            string expect = "Добавление";
            Assert.That(actual.ID, Is.EqualTo(expect));
        }
    }
}
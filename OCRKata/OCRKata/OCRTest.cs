using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRKata
{
    [TestFixture]
    public class OCRTest
    {
        Account _account;

        [SetUp]
        public void SetUp()
        {
            _account = new Account();
        }

        [Test]
        public void AccountTextWith3LinesAnd27CharactersInEachLineReturnsValid()
        {
            _account.AddLine("_________|_________|_______");
            _account.AddLine("_________|_________|_______");
            _account.AddLine("_________|_________|_______");
            Assert.IsTrue(_account.IsValidAccountText);
        }

        [Test]
        public void AccountTextWithNot3LinesReturnsInvalid()
        {
            _account.AddLine("_________|_________|_______");
            _account.AddLine("_________|_________|_______");
            Assert.IsFalse(_account.IsValidAccountText);
        }

        [Test]
        public void AccountTextWith3LinesButNot27CharactersInEachLineReturnsInValid()
        {
            _account.AddLine("_________|_________|_______");
            _account.AddLine("_________|_______|_______");
            _account.AddLine("_________|_________|_______");
            Assert.IsFalse(_account.IsValidAccountText);
        }

        [Test]
        public void AccountTextWithInvalidCharactersReturnsInvalid()
        {
            _account.AddLine("_________|_________|_______");
            _account.AddLine("_________|___g_____|_______");
            _account.AddLine("_________|_________|_______");
            Assert.IsFalse(_account.IsValidAccountText);
        }

        [Test]
        public void ReturnsAllZeros()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("| || || || || || || || || |");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            Assert.AreEqual("000000000", _account.Number);
        }

        [Test]
        public void ReturnsAllOnes()
        {
            _account.AddLine("                           ");
            _account.AddLine("  |  |  |  |  |  |  |  |  |");
            _account.AddLine("  |  |  |  |  |  |  |  |  |");
            Assert.AreEqual("111111111", _account.Number);
        }

        [Test]
        public void ReturnsAllTwos()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine(" _| _| _| _| _| _| _| _| _|");
            _account.AddLine("|_ |_ |_ |_ |_ |_ |_ |_ |_ ");
            Assert.AreEqual("222222222", _account.Number);
        }

        [Test]
        public void ReturnsAllThrees()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine(" _| _| _| _| _| _| _| _| _|");
            _account.AddLine(" _| _| _| _| _| _| _| _| _|");
            Assert.AreEqual("333333333", _account.Number);
        }

        [Test]
        public void ReturnsAllFours()
        {
            _account.AddLine("                           ");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            _account.AddLine("  |  |  |  |  |  |  |  |  |");
            Assert.AreEqual("444444444", _account.Number);
        }

        [Test]
        public void ReturnsAllFives()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("|_ |_ |_ |_ |_ |_ |_ |_ |_ ");
            _account.AddLine(" _| _| _| _| _| _| _| _| _|");
            Assert.AreEqual("555555555", _account.Number);
        }

        [Test]
        public void ReturnsAllSixes()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("|_ |_ |_ |_ |_ |_ |_ |_ |_ ");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            Assert.AreEqual("666666666", _account.Number);
        }

        [Test]
        public void ReturnsAllSevens()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("  |  |  |  |  |  |  |  |  |");
            _account.AddLine("  |  |  |  |  |  |  |  |  |");
            Assert.AreEqual("777777777", _account.Number);
        }

        [Test]
        public void ReturnsAllEights()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            Assert.AreEqual("888888888", _account.Number);
        }

        [Test]
        public void ReturnsAllNines()
        {
            _account.AddLine(" _  _  _  _  _  _  _  _  _ ");
            _account.AddLine("|_||_||_||_||_||_||_||_||_|");
            _account.AddLine(" _| _| _| _| _| _| _| _| _|");
            Assert.AreEqual("999999999", _account.Number);
        }

        [Test]
        public void ReturnsAllNumbers()
        {
            _account.AddLine("    _  _     _  _  _  _  _ ");
            _account.AddLine("  | _| _||_||_ |_   ||_||_|");
            _account.AddLine("  ||_  _|  | _||_|  ||_| _|");
            Assert.AreEqual("123456789", _account.Number);
        }

        private string digits[] = new string

    }
}

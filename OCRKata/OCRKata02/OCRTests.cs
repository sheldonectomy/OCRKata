using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace OCRKata02
{
    [TestFixture]
    public class OCRTests
    {
        private OCR _ocr;
        [SetUp]
        public void SetUp()
        {
            _ocr = new OCR();
        }

        [Test]
        public void OCRCanRecognise1()
        {
            string[] digit =
            {
                "   ",
                "  |",
                "  |"
            };

            Assert.AreEqual("1", _ocr.ScanDigit(digit));
        }

        [Test]
        public void OCRCanRecognise2()
        {
            string[] digit =
            {
                " _ ",
                " _|",
                "|_ "
            };

            Assert.AreEqual("2", _ocr.ScanDigit(digit));
        }

        [Test]
        public void OCRCanRecognise3()
        {
            string[] digit =
            {
                " _ ",
                " _|",
                " _|"
            };

            Assert.AreEqual("3", _ocr.ScanDigit(digit));
        }

        [Test]
        public void OCRReturnsErrorWhenDigitUnrecognised()
        {
            string[] digit =
            {
                "|_|",
                " _|",
                " _|"
            };
            Assert.AreEqual("?", _ocr.ScanDigit(digit));
        }

        [Test]
        public void OCRCanRecognise1234567890()
        {
            string line =
                "    _  _     _  _  _  _  _ " +
                "  | _| _||_||_ |_   ||_||_|" +
                "  ||_  _|  | _||_|  ||_| _|";
            Assert.AreEqual("123456789", _ocr.ScanLine(line));
        }

        [Test]
        public void OCRCanGenerateOCRDigitsFromNumber()
        {
            string line =
                "    _  _     _  _  _  _  _ " + Environment.NewLine +
                "  | _| _||_||_ |_   ||_||_|" + Environment.NewLine +
                "  ||_  _|  | _||_|  ||_| _|" + Environment.NewLine +
                "                           " + Environment.NewLine;
            Assert.AreEqual(line, _ocr.GenerateLine("123456789"));
        }

        [Test]
        public void OCRCanProcessFileWithAllValidAccountNumbers()
        {
            var accountNumbers = _ocr.ProcessAccountFile(testFile());
            accountNumbers.Should().BeEquivalentTo(testFileAccounts());
        }

        [Test]
        public void ChecksumReturnsValidWhenItShould()
        {
            Assert.IsTrue(_ocr.ValidChecksum("938495759"));
        }

        [Test]
        public void ChecksumReturnsInValidWhenItShould()
        {
            Assert.IsFalse(_ocr.ValidChecksum("938495769"));
        }

        [Test]
        public void OCRIncludesErrorFlagsWhenItShould()
        {
            var accountNumbers = _ocr.ProcessAccountFile(testFileWithFlags(), true);
            accountNumbers.Should().BeEquivalentTo(testFileAccountsWithFlags());
        }

        private List<string> testFileAccounts()
        {
            return new List<string>
            {
                "938495759",
                "123456789",
                "027402724",
                "039184456",
                "985033932",
                "393948299",
                "574883992",
                "665748839",
                "399384844",
                "928484848",
                "738749376",
                "662177005",
                "778049388",
                "647783747",
                "783204855",
                "778844059",
                "338488590",
                "399499500",
                "665774883",
                "112399234",
            };
        }

        private string testFile()
        {
            return
@" _  _  _     _  _  _  _  _ 
|_| _||_||_||_||_   ||_ |_|
 _| _||_|  | _| _|  | _| _|
                           
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
 _  _  _     _  _  _  _    
| | _|  ||_|| | _|  | _||_|
|_||_   |  ||_||_   ||_   |
                           
 _  _  _     _        _  _ 
| | _||_|  ||_||_||_||_ |_ 
|_| _| _|  ||_|  |  | _||_|
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_ | | _| _||_| _| _|
 _||_| _||_| _| _| _| _||_ 
                           
 _  _  _  _     _  _  _  _ 
 _||_| _||_||_||_| _||_||_|
 _| _| _| _|  ||_||_  _| _|
                           
 _  _     _  _  _  _  _  _ 
|_   ||_||_||_| _||_||_| _|
 _|  |  ||_||_| _| _| _||_ 
                           
 _  _  _  _     _  _  _  _ 
|_ |_ |_   ||_||_||_| _||_|
|_||_| _|  |  ||_||_| _| _|
                           
 _  _  _  _  _     _       
 _||_||_| _||_||_||_||_||_|
 _| _| _| _||_|  ||_|  |  |
                           
 _  _  _     _     _     _ 
|_| _||_||_||_||_||_||_||_|
 _||_ |_|  ||_|  ||_|  ||_|
                           
 _  _  _  _     _  _  _  _ 
  | _||_|  ||_||_| _|  ||_ 
  | _||_|  |  | _| _|  ||_|
                           
 _  _  _     _  _  _  _  _ 
|_ |_  _|  |  |  || || ||_ 
|_||_||_   |  |  ||_||_| _|
                           
 _  _  _  _     _  _  _  _ 
  |  ||_|| ||_||_| _||_||_|
  |  ||_||_|  | _| _||_||_|
                           
 _     _  _  _  _  _     _ 
|_ |_|  |  ||_| _|  ||_|  |
|_|  |  |  ||_| _|  |  |  |
                           
 _  _  _  _  _     _  _  _ 
  ||_| _| _|| ||_||_||_ |_ 
  ||_| _||_ |_|  ||_| _| _|
                           
 _  _  _  _        _  _  _ 
  |  ||_||_||_||_|| ||_ |_|
  |  ||_||_|  |  ||_| _| _|
                           
 _  _  _     _  _  _  _  _ 
 _| _||_||_||_||_||_ |_|| |
 _| _||_|  ||_||_| _| _||_|
                           
 _  _  _     _  _  _  _  _ 
 _||_||_||_||_||_||_ | || |
 _| _| _|  | _| _| _||_||_|
                           
 _  _  _  _  _     _  _  _ 
|_ |_ |_   |  ||_||_||_| _|
|_||_| _|  |  |  ||_||_| _|
                           
       _  _  _  _  _  _    
  |  | _| _||_||_| _| _||_|
  |  ||_  _| _| _||_  _|  |
                           
";
        }

        private List<string> testFileAccountsWithFlags()
        {
            return new List<string>
            {
                "938495759",
                "123456789 ERR",
                "027402746",
                "03918?455 ILL",
                "985033936",
                "39?948?98 ILL",
                "574883992",
                "665748839 ERR",
                "399384844 ERR",
                "928484848 ERR",
                "738749376 ERR",
                "662177005 ERR",
                "778049388 ERR",
                "647783747 ERR",
                "783204855 ERR",
                "778844059 ERR",
                "338488590",
                "399499500 ERR",
                "665774883 ERR",
                "112399234 ERR",
            };
        }

        private string testFileWithFlags()
        {
            return
@" _  _  _     _  _  _  _  _ 
|_| _||_||_||_||_   ||_ |_|
 _| _||_|  | _| _|  | _| _|
                           
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
 _  _  _     _  _  _     _ 
| | _|  ||_|| | _|  ||_||_ 
|_||_   |  ||_||_   |  ||_|
                           
 _  _  _     _        _  _ 
| | _||_|  ||_||_||_||_ |_ 
|_| _| _|  ||_| _|  | _| _|
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_ | | _| _||_| _||_ 
 _||_| _||_| _| _| _| _||_|
                           
 _  _  _  _     _  _  _  _ 
 _||_|| ||_||_||_| _||_||_|
 _| _| _| _|  ||_||_| _||_|
                           
 _  _     _  _  _  _  _  _ 
|_   ||_||_||_| _||_||_| _|
 _|  |  ||_||_| _| _| _||_ 
                           
 _  _  _  _     _  _  _  _ 
|_ |_ |_   ||_||_||_| _||_|
|_||_| _|  |  ||_||_| _| _|
                           
 _  _  _  _  _     _       
 _||_||_| _||_||_||_||_||_|
 _| _| _| _||_|  ||_|  |  |
                           
 _  _  _     _     _     _ 
|_| _||_||_||_||_||_||_||_|
 _||_ |_|  ||_|  ||_|  ||_|
                           
 _  _  _  _     _  _  _  _ 
  | _||_|  ||_||_| _|  ||_ 
  | _||_|  |  | _| _|  ||_|
                           
 _  _  _     _  _  _  _  _ 
|_ |_  _|  |  |  || || ||_ 
|_||_||_   |  |  ||_||_| _|
                           
 _  _  _  _     _  _  _  _ 
  |  ||_|| ||_||_| _||_||_|
  |  ||_||_|  | _| _||_||_|
                           
 _     _  _  _  _  _     _ 
|_ |_|  |  ||_| _|  ||_|  |
|_|  |  |  ||_| _|  |  |  |
                           
 _  _  _  _  _     _  _  _ 
  ||_| _| _|| ||_||_||_ |_ 
  ||_| _||_ |_|  ||_| _| _|
                           
 _  _  _  _        _  _  _ 
  |  ||_||_||_||_|| ||_ |_|
  |  ||_||_|  |  ||_| _| _|
                           
 _  _  _     _  _  _  _  _ 
 _| _||_||_||_||_||_ |_|| |
 _| _||_|  ||_||_| _| _||_|
                           
 _  _  _     _  _  _  _  _ 
 _||_||_||_||_||_||_ | || |
 _| _| _|  | _| _| _||_||_|
                           
 _  _  _  _  _     _  _  _ 
|_ |_ |_   |  ||_||_||_| _|
|_||_| _|  |  |  ||_||_| _|
                           
       _  _  _  _  _  _    
  |  | _| _||_||_| _| _||_|
  |  ||_  _| _| _||_  _|  |
                           
";
        }
    }
}

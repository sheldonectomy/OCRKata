using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRKata02
{
    class Program
    {
        static void Main(string[] args)
        {
            OCR ocr = new OCR();
            Console.Write(ocr.GenerateLine("938495738"));
            Console.Write(ocr.GenerateLine("123456789"));
            Console.Write(ocr.GenerateLine("027402724"));
            Console.Write(ocr.GenerateLine("039184456"));
            Console.Write(ocr.GenerateLine("985033932"));
            Console.Write(ocr.GenerateLine("393948299"));
            Console.Write(ocr.GenerateLine("574883992"));
            Console.Write(ocr.GenerateLine("665748839"));
            Console.Write(ocr.GenerateLine("399384844"));
            Console.Write(ocr.GenerateLine("928484848"));
            Console.Write(ocr.GenerateLine("738749376"));
            Console.Write(ocr.GenerateLine("662177005"));
            Console.Write(ocr.GenerateLine("778049388"));
            Console.Write(ocr.GenerateLine("647783747"));
            Console.Write(ocr.GenerateLine("783204855"));
            Console.Write(ocr.GenerateLine("778844059"));
            Console.Write(ocr.GenerateLine("338488590"));
            Console.Write(ocr.GenerateLine("399499500"));
            Console.Write(ocr.GenerateLine("665774883"));
            Console.Write(ocr.GenerateLine("112399234"));
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OCRKata02
{
    public class OCR
    {
        private string[][] _digit = 
        {
            new string[] {
                " _ ",
                "| |",
                "|_|"
            },
            new string[] {
                "   " ,
                "  |" ,
                "  |",
            },
            new string[] {
                " _ " ,
                " _|" ,
                "|_ ",
            },
            new string[] {
                " _ " ,
                " _|" ,
                " _|"
            },
            new string[] {
                "   " ,
                "|_|" ,
                "  |"
            },
            new string[] {
                " _ " ,
                "|_ " ,
                " _|"
            },
            new string[] {
                " _ " ,
                "|_ " ,
                "|_|"
            },
            new string[] {
                " _ " ,
                "  |" ,
                "  |"
            },
            new string[] {
                " _ " ,
                "|_|" ,
                "|_|"
            },
            new string[] {
                " _ " ,
                "|_|" ,
                " _|"
            }
        };

        public string ScanDigit(string[] digit)
        {
            int index = Array.FindIndex(_digit, a => string.Join("", a) == string.Join("", digit));
            return index == -1 ? "?" : index.ToString();
        }

        public string ScanLine(string line)
        {
            if(line.Length % 27 != 0)
            {
                throw new ArgumentException("Line is invalid");
            }

            var output = new StringBuilder();
            var illegible = false;
            var digitCount = line.Length / 9;
            for(int i = 0; i < digitCount; i++)
            {
                var newDigit = ScanDigit(getDigitAtScanLocation(i * 3, line));
                output.Append(newDigit);
            }

            return output.ToString();
        }

        private string addErrorFlags(string line)
        {
            var output = new StringBuilder(line);
            if(line.Contains('?'))
            {
                output.Append(" ILL");
            }
            else
            {
                output.Append(ValidChecksum(output.ToString()) ? "" : " ERR");
            }
            return output.ToString();
        }

        private string[] getDigitAtScanLocation(int index, string line)
        {
            int subLineLength = line.Length / 3;
            string[] result = new string[3];
            result[0] = line.Substring(index, 3);
            result[1] = line.Substring(index + subLineLength, 3);
            result[2] = line.Substring(index + (subLineLength * 2), 3);
            return result;
        }

        public List<string> ProcessAccountFile(string accountFile, bool includeErrorFlags = false)
        {
            using (StringReader reader = new StringReader(accountFile))
            {
                string textLine;
                var ocrLine = new StringBuilder();
                List<string> result = new List<string>();

                int count = 0;
                while ((textLine = reader.ReadLine()) != null)
                {
                    if(count == 3)
                    {
                        var newLine = ScanLine(ocrLine.ToString());
                        if(includeErrorFlags)
                        {
                            newLine = addErrorFlags(newLine);
                        }
                        result.Add(newLine);
                        ocrLine.Clear();
                        count = 0;
                    }
                    else
                    {
                        ocrLine.Append(textLine);
                        count++;
                    }
                }
                return result;
            }
        }

        public bool ValidChecksum(string accountNumber)
        {
            int totalSum = 0;
            for(int i = 8; i > 0; i--)
            {
                totalSum += int.Parse(accountNumber[i].ToString()) * (9 - i);
            }
            return totalSum % 11 == 0;
        }

        public string GenerateLine(string accountNumber)
        {
            var builder = new StringBuilder[3];
            builder[0] = new StringBuilder();
            builder[1] = new StringBuilder();
            builder[2] = new StringBuilder();
            for(int i = 0; i < accountNumber.Length; i++)
            {
                int digit = int.Parse(accountNumber.Substring(i, 1));
                builder[0].Append(_digit[digit][0]);
                builder[1].Append(_digit[digit][1]);
                builder[2].Append(_digit[digit][2]);
            }
            var result = new StringBuilder();
            result.Append(builder[0]).Append(Environment.NewLine);
            result.Append(builder[1]).Append(Environment.NewLine);
            result.Append(builder[2]).Append(Environment.NewLine);
            result.Append(' ', 27).Append(Environment.NewLine);
            return result.ToString();
        }



    }
}

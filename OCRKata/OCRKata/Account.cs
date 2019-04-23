using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRKata
{
    public class Account
    {
        List<string> _lines = new List<string>();
        Dictionary<string, int> _digitIndex = new Dictionary<string, int>
        {
            { " _ | ||_|", 0},
            { "     |  |", 1},
            { " _  _||_ ", 2},
            { " _  _| _|", 3},
            { "   |_|  |", 4},
            { " _ |_  _|", 5},
            { " _ |_ |_|", 6},
            { " _   |  |", 7},
            { " _ |_||_|", 8},
            { " _ |_| _|", 9}
        };
        
        public void AddLine(string line)
        {
            _lines.Add(line);
        }

        public bool IsValidAccountText
        {
            get
            {
                return
                    (_lines.Where(a => a.Length == 27).Count() == 3)
                    && (_lines.SelectMany(a => a.ToCharArray())
                            .Where(b => b != '_' && b != '|').Count() == 0);
            }
        }

        public string Number
        {
            get
            {
                var digits = new List<string>()
                {
                    "", "", "", "", "", "", "", "", ""
                };

                foreach (var line in _lines)
                {
                    for (int i = 0; i < 9; i += 1)
                    {
                        var builder = new StringBuilder(digits[i]);
                        digits[i] = builder.Append(line.Substring(i * 3, 3)).ToString();
                    }
                }
                return getNumbersFromDigits(digits);
            }
        }

        private string getNumbersFromDigits(List<string> digits)
        {
            var result = new StringBuilder();
            for(int i=0; i<9; i++)
            {
                result.Append(getNumber(digits[i]));
            }
            return result.ToString();
        }

        private string getNumber(string digit)
        {
            if(_digitIndex.ContainsKey(digit))
            {
                return _digitIndex[digit].ToString();
            }
            return "?";
        }

    }
}

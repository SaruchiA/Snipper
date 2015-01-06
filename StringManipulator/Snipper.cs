using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulator
{
    public class Snipper
    {
        private char[] specialChar = "()-\"\\//.',;? ".ToCharArray();
        public String result;
        private bool isSpecial(char c)
        {
            return specialChar.Contains(c);
        }

        public string Snip(string input, int cutoffVal)
        {

            if (cutoffVal > input.Length || cutoffVal == 0)
            {
                if (cutoffVal > input.Length)
                {
                    return input;
                }
                else
                {
                    return string.Empty;
                }

            }

            else
            {
                result = input.Substring(0, cutoffVal);

                if ((cutoffVal + 1) <= input.Length)
                {
                    result = input.Substring(0, cutoffVal + 1);
                    if (!isSpecial(result[cutoffVal - 1]))
                    {
                        if (isSpecial(input[cutoffVal]))
                        {
                            result = input;
                        }
                        else
                        {
                            for (int i = (cutoffVal); i > 0; i--)
                            {
                                if (input[i] == ' ')
                                {
                                    int d = i;
                                    result = input.Substring(0, d);
                                    break;
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }
    }
}

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
        public int CutOff;
        private bool isSpecial(char c)
        {
            return specialChar.Contains(c);
        }

        public string Snip(string input)
        {

            if (CutOff > input.Length || CutOff == 0)
            {
                if (CutOff > input.Length)
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
                result = input.Substring(0, CutOff);
                if ((CutOff + 1) <= input.Length)
                {
                    result = input.Substring(0, CutOff + 1);
                    if (!isSpecial(result[CutOff - 1]))
                    {
                        if (isSpecial(input[CutOff]))
                        {
                            result = input;
                        }
                        else
                        {
                            for (int i = (CutOff); i > 0; i--)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        #region Properties
        String str;
        
        char[] specialChar = "()-\"\\//.',;? ".ToCharArray();
        int cutOff;
        #endregion
        
        #region Event Handlers
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = textBox1.Text;
            String result="";
            
            List<String> linesOfText = new List<string>();
            linesOfText.AddRange(str.Split(new string[] { "\n", "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));
           
            /* BeginSection:-returing result if cutoff is some invalid value*/
            if (string.IsNullOrEmpty(textBox3 .Text ) || string.IsNullOrWhiteSpace(textBox3 .Text ) || (textBox3 .Text ).All(char.IsLetter))
            {
                result = "";
                showSnippedString(result);

            }
            else
            {
                cutOff = int.Parse(textBox3.Text);
                Manipulator m1 = new Manipulator();
                for (int i = 0; i < linesOfText.Count(); i++)
                {
                    result += m1.Snip(linesOfText[i], cutOff)+"..."+Environment.NewLine;
                }

            }
            showSnippedString(result);
            /* EndSection:-returing result if cutoff is some invalid value*/ 

           
            
                         
        }
        #endregion

        public  void showSnippedString(string result)
        {
         //   MessageBox.Show(result+"...");
            textBox2.Lines = result.Split(new string[]{"\n"},StringSplitOptions.None);
            //!!! important- textbox.lines
        }
    } // end Form1
    
        public class Manipulator
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
                        
                        if ((cutoffVal+1) <= input.Length)
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
        } // end class Manipulator

        
        
   
}

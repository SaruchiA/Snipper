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
        string str;
        //static string str = "India officially Iambigword the Republic of India is a country in South Asiau.";

        char[] s;
        char[] specialChar = "()-\"\\//.',;? ".ToCharArray();
        protected int cutOff=20;
        string result;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             this.ActiveControl = textBox3;
        }

        public void showSnippedString()
        {
            textBox2.Text =  result+"...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str = textBox1.Text;
            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || (textBox3 .Text).All(char.IsLetter ) )
            {
                result = " ";
                showSnippedString();

            }
            else if (!string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                {
                    cutOff = int.Parse(textBox3.Text);
                }
                if (cutOff > str.Length || cutOff == 0)
                {
                    if (cutOff > str.Length)
                    {
                        result = str;
                        showSnippedString();
                    }

                    else
                    {
                        result = "";
                        showSnippedString();
                    }
                }

                else if (cutOff == str.Length || cutOff < str.Length)
                {
                    if (cutOff == str.Length)
                    {
                        s = str.Substring(0, cutOff).ToCharArray();
                        result = new string(s);
                       // showSnippedString();
                        
                    }

                    else if (cutOff < str.Length)
                    {
                        s = str.Substring(0, cutOff + 1).ToCharArray();
                    
                    if (!isSpecial(s[cutOff - 1]))
                    {
                        if (isSpecial(s[cutOff]))
                        {
                            result = new string(s);
                        }
                        else
                        {
                            for (int i = (cutOff); i > 0; i--)
                            {
                                if (s[i] == ' ')
                                {
                                    int d = i;
                                    result = (new string(s)).Substring(0, d);
                                    break;
                                }
                                else
                                {
                                    result = (new string(s)).Substring (0,(s.Length -1));
                                    break;
                                }
                            }
                        }
                    }
                    else
                        result = new string(s);
                    }
                }

                else
                {
                    result = new string(s);
                }

                showSnippedString();



            }
        }

        private bool isSpecial(char c)
        {
            return specialChar.Contains(c);
        }

       

    }
}

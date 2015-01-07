using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringManipulator
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
                Snipper snipper = new Snipper();
                snipper.CutOff = cutOff;
                for (int i = 0; i < linesOfText.Count(); i++)
                {
                    result += snipper.Snip(linesOfText[i])+textBox4 .Text +Environment.NewLine;
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

        }
    } // end Form1
   
}

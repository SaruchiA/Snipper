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
        public bool snipDirection;
        String specialChar = "()-\"\\//.',;?";
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
            if (radioButton1.Checked)
                    snipDirection = true;
            else
                snipDirection = false;
            str = textBox1.Text;
            String result="";
            
            List<String> linesOfText = new List<string>();
            linesOfText.AddRange(str.Split(new string[] { "\n", "\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));
           
            /* BeginSection:-returing result if cutoff is some invalid value*/
            if (string.IsNullOrEmpty(textBox3 .Text ) || string.IsNullOrWhiteSpace(textBox3 .Text ) || (textBox3 .Text ).All(char.IsLetter))
            {
                result = textBox4 .Text ;
                showSnippedString(result );

            }
            else
            {
                if (!int.TryParse(textBox3.Text, out cutOff))
                    cutOff = 0;
                Snipper snipper = new Snipper();
                snipper.CutOff = cutOff;
                snipper.snip_dir = snipDirection;
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
             textBox2.Lines = result.Split(new string[] { "\n" }, StringSplitOptions.None);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
        }
    } // end Form1
   
}

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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }        
        char  ch=' ';
        char substitute;
        int subVal;
        String TEMP;
        int value = 0; 

        private void button1_Click(object sender, EventArgs e)
        {
            TEMP = "";
            char[] str = (textBox1.Text).ToCharArray ();            
            for (int d = 0; d < str.Length; d++)
            {
                int subValChar;
                subValChar= System .Convert .ToInt32 ( str[d]);
                substitute = char.Parse(textBox3.Text);
                if (subValChar >= 65 && subValChar <= 90)
                {
                    rotMeUpper(str[d]);
                }
                rotMeLower(str[d]);
            }
            
            //rotMeUpper(str);     
        }

        public void rotMeUpper(char str)
        {                       
            subVal = (System.Convert.ToInt32(substitute))-65;            
            //foreach (char c in str)
            //{
                  value=System.Convert.ToInt32(str );
                  value = value + subVal;
                  if (value > 90)
                      value = 65+(value -91);
                  ch = System .Convert.ToChar (value);
                  TEMP =TEMP +ch ;
            //}
            textBox2 .Text =""+ TEMP ;  
        }

        public void rotMeLower(char str)
        {            
            subVal = (System.Convert.ToInt32(substitute)) - 97;
            //foreach (char c in str)
            //{
            value = System.Convert.ToInt32(str);
            value = value + subVal;
            if (value > 122)
                value = 97 + (value - 123);
            ch = System.Convert.ToChar(value);
            TEMP = TEMP + ch;
            //}
            textBox2.Text = "" + TEMP;
        }

    }
}

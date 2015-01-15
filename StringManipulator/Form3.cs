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
        char substitute_char;
        int substitue_IntValue;
        String outputString="";
        int value = 0;
        int inputChar_intValue;

        private void button1_Click(object sender, EventArgs e)
        {
             outputString = "";  // mandatory! otherwise multiple Rot13 button clicks on single execution will not work
             substitute_char = char.Parse(textBox3.Text);
             substitue_IntValue = (System.Convert.ToInt32(substitute_char));
             substitue_IntValue = subIntValCalculator(substitue_IntValue);
             char[] str = (textBox1.Text).ToCharArray();
            for (int d = 0; d < str.Length; d++)
            {               
                inputChar_intValue= System .Convert .ToInt32 ( str[d]);               
                if (inputChar_intValue >= 65 && inputChar_intValue <= 90)
                {
                    rotMeUpper(str[d],inputChar_intValue );
                }
                else
                    rotMeLower(str[d], inputChar_intValue);
            }
            
        }
        public int subIntValCalculator(int substitue_IntValue)
        {
            if (substitue_IntValue >= 97 && substitue_IntValue <= 122)
            {
                substitue_IntValue = (System.Convert.ToInt32(substitute_char)) - 97;
            }
            else
                substitue_IntValue = (System.Convert.ToInt32(substitute_char)) - 65;
            return (substitue_IntValue);  
        }

        public void rotMeUpper(char str, int inputChar_intValue)
        {              
            //value=System.Convert.ToInt32(str);
            value = inputChar_intValue + substitue_IntValue;
            if (value > 90)
               value = 65+(value -91);
            ch = System .Convert.ToChar(value);
            outputString =outputString +ch ;
            textBox2 .Text =""+ outputString ;  
        }

        public void rotMeLower(char str, int inputChar_intValue)
        {
           // substitue_IntValue=subIntValCalculator(substitue_IntValue);
            value = inputChar_intValue + substitue_IntValue;
            if (value > 122)
                value = 97 + (value - 123);
            ch = System.Convert.ToChar(value);
            outputString = outputString + ch;
            textBox2.Text = "" + outputString;
        }

        private void Form3_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Activity._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str;
            int maxVal = 0;
            int maxIndex = 0;
            int vowCount = 0;
            int vowIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                str = System.IO.File.ReadAllText(openFileDialog1.FileName); // read text file from our string file s
                textBox1.Text = str.ToLower(); //  mkae it in lower
                string[] array = str.Split(' '); // split string with blank
                textBox2.Text = array[0]; // first word
                textBox3.Text = array[array.Length - 1]; // last word
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (maxVal < array[i].Length)
                    {
                        maxVal = array[i].Length;
                        maxIndex = i;
                    }
                    if (vowCount < VowelCount(array[i]))
                    {
                       vowCount = VowelCount(array[i]);
                       vowIndex = i;
                    }
                }

                textBox4.Text = array[maxIndex]; // output display
                textBox5.Text = array[vowIndex]; // output display
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\write.txt"); // Textfile write here
                sw.WriteLine("Converting in Lower :" + textBox1.Text); //Textfile write here
                sw.WriteLine("First Word ::" + textBox2.Text);//Textfile write here
                sw.WriteLine("Last Word ::" + textBox3.Text);//Textfile write here
                sw.WriteLine("Longest word ::" + textBox4.Text);//Textfile write here
                sw.WriteLine("Longest Vowel Word ::" + textBox5.Text);//Textfile write here
                sw.Close();
                MessageBox.Show("Text file is Created");//output display for message
            }

        }
        public int VowelCount(string sentence)//function for vowel count here
        {
            int vowels = 0;
            for (int i = 0; i < sentence.Length - 1; i++)
            {
                if ((sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] == 'i' || sentence[i] == 'o' || sentence[i] == 'u') || (sentence[i] == 'A' || sentence[i] == 'E' || sentence[i] ==
                'I' || sentence[i] == 'O' || sentence[i] == 'U'))
                {
                    vowels = vowels + 1;
                }

            }
            return vowels;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //                  !!!!!!!!!!!!!!

namespace Streams
{
    public partial class Streams : Form
    {
        public Streams()
        {
            InitializeComponent();
        }

        public void massive(int[,] mas)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    richTextBox1.Text += mas[i, j] + " ";
                }
                richTextBox1.Text += "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter("Files/file2.txt", true);
            string STR = textBox1.Text;
            SW.WriteLine(STR);
            SW.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            using (StreamReader SR = new StreamReader("Files/file2.txt"))
            {
                while(!SR.EndOfStream)
                {
                    richTextBox1.Text += SR.ReadLine() + "\n";
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int Row = 0;        
            int[,] mas = new int[5, 10];
            StreamReader SR = new StreamReader("files/matrica.txt");
            while (!SR.EndOfStream)
            {
                string[] NISTR =  SR.ReadLine().Split(' ');
                for (int i = 0; i < 10; i++)
                {
                    mas[Row, i] = Convert.ToInt32(NISTR[i]);
                }
                Row++;
            }
            massive(mas);
            SR.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace CodeEditor
{
    public partial class Form1 : Form
    {
        Dictionary<string, Color> words = new Dictionary<string, Color>();
        public Form1(Dictionary<string, Color> keys)
        {
            words= keys;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i=0;i<words.Count;i++)
            {
                CheckKeyword(words.Keys.ElementAt(i), words.Values.ElementAt(i),0);
            }
            //textBox1.Text = "";
            //for(int i=0;i<richTextBox1.Lines.Length;i++)
            //{
            //    textBox1.Text += i + 1 + "\n";
            //}
        }
        private void CheckKeyword(string Word,Color color,int StartIndex)
        {
            int Start = richTextBox1.SelectionStart;
            richTextBox1.Select(Start, 0);
            richTextBox1.SelectionColor = Color.Black;
            if (richTextBox1.Text.Contains(Word))
            {
                if(richTextBox1.Text.IndexOf(Word,0)!=-1)
                {
                    richTextBox1.Select(richTextBox1.Text.IndexOf(Word, 0),Word.Length);
                    richTextBox1.SelectionColor = color;
                }
                richTextBox1.Select(Start, 0);
                richTextBox1.SelectionColor = Color.Black;
            }
        }

        private void colorSettinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}

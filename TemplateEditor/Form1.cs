using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace TemplateEditor
{
    public partial class Form1 : Form
    {
        bool Saved = false;
        string filename="";
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string filename)
        {
            this.filename = filename;
            InitializeComponent();
        }
        private void Save(string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("root");
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    XmlElement node = doc.CreateElement("word");
                    XmlAttribute name = doc.CreateAttribute("name");
                    name.Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    XmlAttribute color = doc.CreateAttribute("color");
                    color.Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    node.Attributes.Append(name);
                    node.Attributes.Append(color);
                    root.AppendChild(node);
                }
            }
            doc.AppendChild(root);
            if (filename == "")
            {
                saveFileDialog1.ShowDialog();
                doc.Save(filename);
            }
        }
        private void Save()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("root");
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null && dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    XmlElement node = doc.CreateElement("word");
                    XmlAttribute name = doc.CreateAttribute("name");
                    name.Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    XmlAttribute color = doc.CreateAttribute("color");
                    color.Value = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    node.Attributes.Append(name);
                    node.Attributes.Append(color);
                    root.AppendChild(node);
                }
            }
            doc.AppendChild(root);
            if (filename == "")
            {
                saveFileDialog1.ShowDialog();
                doc.Save(saveFileDialog1.FileName);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(filename);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            XmlDocument doc = new XmlDocument();
            doc.Load(openFileDialog1.FileName);
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode node in root)
            {
                dataGridView1.Rows.Add();
                if (((dataGridView1.RowCount) >= 0))
                {
                    if (node.Attributes.GetNamedItem("name") != null && node.Attributes.GetNamedItem("color") != null)
                    {
                        dataGridView1.Rows.Add(new object[] { node.Attributes.GetNamedItem("name").Value, node.Attributes.GetNamedItem("color").Value });
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (filename != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                XmlNode root = doc.DocumentElement;
                foreach (XmlNode node in root)
                {
                    dataGridView1.Rows.Add();
                    if (((dataGridView1.RowCount) >= 0))
                    {
                        if (node.Attributes.GetNamedItem("name") != null && node.Attributes.GetNamedItem("color") != null)
                        {
                            dataGridView1.Rows.Add(new object[] { node.Attributes.GetNamedItem("name").Value, node.Attributes.GetNamedItem("color").Value });
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Saved==false)
            {
                DialogResult res = MessageBox.Show("Do you want to save?", "File isn't saved",MessageBoxButtons.YesNoCancel);
                if(res==DialogResult.Yes)
                {
                    if (filename != "") Save(filename);
                    else Save();
                }
                if(res==DialogResult.No)
                {

                }
                if(res==DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}

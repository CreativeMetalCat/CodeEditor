using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace CodeEditor
{

    static class Program
    {
        /// <summary>
        /// Loads Color Settings for Language
        /// </summary>
        /// <param name="Filename">Name of file</param>
        /// <returns>Dictionary with color for special words</returns>
        static Dictionary<string,Color> LoadColorTemplate(string Filename)
        {
            Dictionary<string, Color> res = new Dictionary<string, Color>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Filename);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode node in root)
            {
                if(node.Attributes.GetNamedItem("name") != null && node.Attributes.GetNamedItem("color").Value != null)
                {
                    res.Add(node.Attributes.GetNamedItem("name").Value, Color.FromName(node.Attributes.GetNamedItem("color").Value));
                }
            }
            return res;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(LoadColorTemplate("c_t_a.lct")));
        }
    }
}

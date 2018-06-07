using System;
using System.Windows.Forms;
using System.IO;

namespace TemplateEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
            {
                if (File.Exists(args[0]))
                {
                    Application.Run(new Form1(args[0]));
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}

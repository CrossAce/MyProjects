using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Custom_Editor
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

            if (args != null && args.Length > 0)
            {
                string fileName = args[0];
                if (File.Exists(fileName))
                {
                    FileInfo info = new FileInfo(fileName);
                    if(info.Extension == ".ctxt")
                    {
                        var form = new Form1();
                        form.OpenWith(fileName);
                        Application.Run(form);
                    }
                    else
                    {
                        MessageBox.Show("Invalid file!","Error",MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Application.Run(new Form1());
                    }
                  
                }
               
            }
            else
            {
                Application.Run(new Form1());
            }

        }

     
    }
}


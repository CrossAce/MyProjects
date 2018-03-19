using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Editor
{
    public delegate void ReplaceCompleted(string result);
    public partial class ReplaceForm : Form
    {
       
        public event ReplaceCompleted onReplaceCompleted;

        public ReplaceForm()
        {
            InitializeComponent();
        }


        protected virtual void _onReplaceCompleted(string result)
        {
            System.Diagnostics.Debug.WriteLine("2 -3");
            onReplaceCompleted.Invoke(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rF = replaceFromTB.Text;
            string rT = replaceToTB.Text;

            if (checkBox1.Checked)
            {
                rT = Environment.NewLine;
            }

            _onReplaceCompleted(rF + "@" + rT);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            replaceToTB.Enabled = !checkBox1.Checked;         
        }
    }
}

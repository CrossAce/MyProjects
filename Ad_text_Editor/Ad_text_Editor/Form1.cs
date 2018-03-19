using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_SAVER;

namespace Custom_Editor
{
    public partial class Form1 : Form
    {
        private bool IsSaved { get; set; } = true;
        private int TextLen { get; set; } = 0;
        private string FileName { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void OpenWith(string fileName)
        {
            OpenExtended(fileName);
        }

        private void textControl_TextChanged(object sender, EventArgs e)
        {
            if (TextLen != textControl.Text.Length)
            {
                IsSaved = false;
                TextLen = textControl.Text.Length;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textControl.CanUndo)
            {
                textControl.Undo();
            }
        }

        #region Context Menu

        private void buildForUnorderedListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textControl.Text = textControl.Text.Replace("", Environment.NewLine);
        }

        private void Form_onReplaceCompleted(string result)
        {
            if (result != "" && result != string.Empty)
            {
                var r = result.Split('@');
                textControl.Text = textControl.Text.Replace(r[0], r[1]);
            }
        }

        private void replaceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            ReplaceForm form = new ReplaceForm();
            form.onReplaceCompleted += Form_onReplaceCompleted;
            form.ShowDialog();

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var selection = textControl.SelectedText;
            textControl.Text = textControl.Text.Replace(selection, "");
        }

        private void numericToWordToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textControl.Text = CleanString(textControl.Text);
        }

        private void cleanSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int beginSelection, len;
            beginSelection = textControl.SelectionStart;
            len = textControl.SelectionLength;

            string cleanedString = CleanString(textControl.SelectedText);
            textControl.Text = textControl.Text.Remove(beginSelection, len);
            textControl.Text = textControl.Text.Insert(beginSelection, cleanedString);
        }

        private void trimSpacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegexOptions options = RegexOptions.CultureInvariant;
            Regex regex = new Regex(@"\s{2,}", options);
            textControl.Text = regex.Replace(textControl.Text, Environment.NewLine);
        }
        #endregion

        #region File

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All content will be lost.\nDo you wish to proceed?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {

                textControl.Text = "";
                IsSaved = false;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                var res = MessageBox.Show("Content is not saved.\nDo you want to save it?", "Not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (res == DialogResult.Yes)
                {
                    Save(false);
                }
            }
        }

        #endregion

        #region Helper Methods

        private string CleanString(string workingString)
        {

            workingString = workingString.Replace(Environment.NewLine, " ");
            workingString = workingString.Replace("\r", "");
            workingString = workingString.Replace("\t", " ");


            workingString = workingString.Replace("&quot;", "\"");

            if (workingString.Contains('#'))
            {
                if (MessageBox.Show("The text contains '#', do you wish to make it into a new line?", "Found '#'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    workingString = workingString.Replace("#", Environment.NewLine);
                }

            }
            return workingString;
        }

        private void Save(bool saveAs)
        {
            if (!saveAs)
            {
                if (FileName == null)
                {
                    saveFileDialog1.DefaultExt = "ctxt";
                    saveFileDialog1.AddExtension = true;
                    saveFileDialog1.CreatePrompt = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveExtended(saveFileDialog1.FileName);
                    }
                }
                else
                {
                    SaveExtended(FileName);
                }

            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveExtended(saveFileDialog1.FileName);
                }
            }

        }

        private void Open()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenExtended(openFileDialog1.FileName);
            }
        }

        private void SaveExtended(string Filename)
        {
            var token = new SaveToken();
            token.SetText(textControl.Text);
            StaticFunctions.WriteToXmlFile(Filename, token, false);
            IsSaved = true;
        }

        private void OpenExtended(string Filename)
        {
            FileName = Filename;
            var token = StaticFunctions.ReadFromXmlFile<SaveToken>(Filename);
            var ft = token.FormatText();
            TextLen = ft.Length;
            textControl.Text = ft;
        }

        #endregion

        #region Options
        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float fontsize = textControl.Font.Size;
            textControl.Font = new Font(textControl.Font.FontFamily, fontsize += 5);
        }

        private void fontSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            float fontsize = textControl.Font.Size;
            textControl.Font = new Font(textControl.Font.FontFamily, fontsize -= 5);
        }
        #endregion

    }

    public class SaveToken : IDisposable
    {

        public string Text { get; set; }

        public SaveToken()
        {

        }

        public void SetText(string Text)
        {
            this.Text = Text.Replace(Environment.NewLine, "^");
        }

        public string FormatText()
        {
            return Text.Replace("^", Environment.NewLine);
        }

        public void Dispose()
        {
            Text = null;
        }
    }
}

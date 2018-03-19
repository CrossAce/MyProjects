namespace Custom_Editor
{
    partial class ReplaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.replaceFromTB = new System.Windows.Forms.TextBox();
            this.replaceToTB = new System.Windows.Forms.TextBox();
            this.labelRwhat = new System.Windows.Forms.Label();
            this.labelRwith = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // replaceFromTB
            // 
            this.replaceFromTB.Location = new System.Drawing.Point(36, 36);
            this.replaceFromTB.Name = "replaceFromTB";
            this.replaceFromTB.Size = new System.Drawing.Size(183, 20);
            this.replaceFromTB.TabIndex = 3;
            // 
            // replaceToTB
            // 
            this.replaceToTB.Location = new System.Drawing.Point(36, 80);
            this.replaceToTB.Name = "replaceToTB";
            this.replaceToTB.Size = new System.Drawing.Size(183, 20);
            this.replaceToTB.TabIndex = 4;
            // 
            // labelRwhat
            // 
            this.labelRwhat.AutoSize = true;
            this.labelRwhat.Location = new System.Drawing.Point(33, 20);
            this.labelRwhat.Name = "labelRwhat";
            this.labelRwhat.Size = new System.Drawing.Size(76, 13);
            this.labelRwhat.TabIndex = 5;
            this.labelRwhat.Text = "Replace what:";
            // 
            // labelRwith
            // 
            this.labelRwith.AutoSize = true;
            this.labelRwith.Location = new System.Drawing.Point(33, 64);
            this.labelRwith.Name = "labelRwith";
            this.labelRwith.Size = new System.Drawing.Size(72, 13);
            this.labelRwith.TabIndex = 6;
            this.labelRwith.Text = "Replace with:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Replace";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(65, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Replace with new line";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 206);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRwith);
            this.Controls.Add(this.labelRwhat);
            this.Controls.Add(this.replaceToTB);
            this.Controls.Add(this.replaceFromTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox replaceFromTB;
        private System.Windows.Forms.TextBox replaceToTB;
        private System.Windows.Forms.Label labelRwhat;
        private System.Windows.Forms.Label labelRwith;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
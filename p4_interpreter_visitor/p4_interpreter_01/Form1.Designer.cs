namespace p4_interpreter_01
{
    partial class Form1
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
            this.richInputBox = new System.Windows.Forms.RichTextBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richInputBox
            // 
            this.richInputBox.Location = new System.Drawing.Point(12, 12);
            this.richInputBox.Name = "richInputBox";
            this.richInputBox.Size = new System.Drawing.Size(1158, 291);
            this.richInputBox.TabIndex = 0;
            this.richInputBox.Text = "";
            this.richInputBox.TextChanged += new System.EventHandler(this.richInputBox_TextChanged_1);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(12, 344);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1158, 132);
            this.lstLog.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.richInputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richInputBox;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button button1;
    }
}


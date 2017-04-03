namespace p4_interpreter_3
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
            this.btnParse = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // richInputBox
            // 
            this.richInputBox.Location = new System.Drawing.Point(0, 0);
            this.richInputBox.Name = "richInputBox";
            this.richInputBox.Size = new System.Drawing.Size(1372, 272);
            this.richInputBox.TabIndex = 0;
            this.richInputBox.Text = "";
            this.richInputBox.TextChanged += new System.EventHandler(this.richInputBox_TextChanged);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(519, 495);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(170, 73);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(780, 495);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(170, 74);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(0, 294);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1372, 180);
            this.lstLog.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 580);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.richInputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richInputBox;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ListBox lstLog;
    }
}


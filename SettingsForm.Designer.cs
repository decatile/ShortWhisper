namespace DesktopWhisper
{
    partial class SettingsForm
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
            this.serverPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modelPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.langTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.popupTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pasteTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // serverPathTextBox
            // 
            this.serverPathTextBox.Location = new System.Drawing.Point(12, 29);
            this.serverPathTextBox.Name = "serverPathTextBox";
            this.serverPathTextBox.Size = new System.Drawing.Size(402, 20);
            this.serverPathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server binary path (surround in quotes if path contains spaces)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model path (surround in quotes if path contains spaces)";
            // 
            // modelPathTextBox
            // 
            this.modelPathTextBox.Location = new System.Drawing.Point(12, 84);
            this.modelPathTextBox.Name = "modelPathTextBox";
            this.modelPathTextBox.Size = new System.Drawing.Size(402, 20);
            this.modelPathTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(12, 142);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(402, 20);
            this.portTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Language";
            // 
            // langTextBox
            // 
            this.langTextBox.Location = new System.Drawing.Point(12, 198);
            this.langTextBox.Name = "langTextBox";
            this.langTextBox.Size = new System.Drawing.Size(402, 20);
            this.langTextBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Show popup (near notification area)";
            // 
            // popupTextBox
            // 
            this.popupTextBox.Location = new System.Drawing.Point(12, 253);
            this.popupTextBox.Name = "popupTextBox";
            this.popupTextBox.Size = new System.Drawing.Size(402, 20);
            this.popupTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Paste immediately (send keys)";
            // 
            // pasteTextBox
            // 
            this.pasteTextBox.Location = new System.Drawing.Point(12, 305);
            this.pasteTextBox.Name = "pasteTextBox";
            this.pasteTextBox.Size = new System.Drawing.Size(402, 20);
            this.pasteTextBox.TabIndex = 11;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 396);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pasteTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.popupTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.langTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelPathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverPathTextBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modelPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox langTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox popupTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pasteTextBox;
    }
}
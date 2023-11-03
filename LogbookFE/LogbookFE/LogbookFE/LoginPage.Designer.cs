
namespace LogbookFE
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PastButton = new System.Windows.Forms.Button();
            this.CurrentRecords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PastButton
            // 
            this.PastButton.Location = new System.Drawing.Point(257, 409);
            this.PastButton.Name = "PastButton";
            this.PastButton.Size = new System.Drawing.Size(113, 29);
            this.PastButton.TabIndex = 0;
            this.PastButton.Text = "Past Records";
            this.PastButton.UseVisualStyleBackColor = true;
            this.PastButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CurrentRecords
            // 
            this.CurrentRecords.Location = new System.Drawing.Point(460, 409);
            this.CurrentRecords.Name = "CurrentRecords";
            this.CurrentRecords.Size = new System.Drawing.Size(110, 29);
            this.CurrentRecords.TabIndex = 1;
            this.CurrentRecords.Text = "In-Personnel ";
            this.CurrentRecords.UseVisualStyleBackColor = true;
            this.CurrentRecords.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentRecords);
            this.Controls.Add(this.PastButton);
            this.Name = "LoginPage";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PastButton;
        private System.Windows.Forms.Button CurrentRecords;
    }
}


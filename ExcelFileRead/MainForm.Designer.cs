namespace ExcelFileRead
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPing = new System.Windows.Forms.Button();
            this.btnComChange = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.TCPChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(12, 42);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(145, 21);
            this.btnPing.TabIndex = 0;
            this.btnPing.Text = "PingExcelTable";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnComChange
            // 
            this.btnComChange.Location = new System.Drawing.Point(12, 69);
            this.btnComChange.Name = "btnComChange";
            this.btnComChange.Size = new System.Drawing.Size(145, 21);
            this.btnComChange.TabIndex = 1;
            this.btnComChange.Text = "ChangeComSetting";
            this.btnComChange.UseVisualStyleBackColor = true;
            this.btnComChange.Click += new System.EventHandler(this.btnComChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(13, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TCPChat
            // 
            this.TCPChat.Location = new System.Drawing.Point(12, 96);
            this.TCPChat.Name = "TCPChat";
            this.TCPChat.Size = new System.Drawing.Size(145, 21);
            this.TCPChat.TabIndex = 3;
            this.TCPChat.Text = "Локальный чат";
            this.TCPChat.UseVisualStyleBackColor = true;
            this.TCPChat.Click += new System.EventHandler(this.TCPChat_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 346);
            this.Controls.Add(this.TCPChat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnComChange);
            this.Controls.Add(this.btnPing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RedMachine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button btnComChange;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button TCPChat;
    }
}
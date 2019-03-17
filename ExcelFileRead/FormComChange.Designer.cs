namespace ExcelFileRead
{
    partial class FormComChange
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
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.btnComSetting1 = new System.Windows.Forms.Button();
            this.btnComSetting2 = new System.Windows.Forms.Button();
            this.labelSetting1 = new System.Windows.Forms.Label();
            this.labelSetting2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(265, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(13, 13);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(133, 21);
            this.comboBoxPorts.TabIndex = 1;
            this.comboBoxPorts.Text = "Выберите Com Порт";
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            // 
            // btnComSetting1
            // 
            this.btnComSetting1.Location = new System.Drawing.Point(12, 40);
            this.btnComSetting1.Name = "btnComSetting1";
            this.btnComSetting1.Size = new System.Drawing.Size(75, 23);
            this.btnComSetting1.TabIndex = 2;
            this.btnComSetting1.Text = "Setting1";
            this.btnComSetting1.UseVisualStyleBackColor = true;
            this.btnComSetting1.Click += new System.EventHandler(this.btnComSetting1_Click);
            // 
            // btnComSetting2
            // 
            this.btnComSetting2.Location = new System.Drawing.Point(12, 69);
            this.btnComSetting2.Name = "btnComSetting2";
            this.btnComSetting2.Size = new System.Drawing.Size(75, 23);
            this.btnComSetting2.TabIndex = 3;
            this.btnComSetting2.Text = "Setting2";
            this.btnComSetting2.UseVisualStyleBackColor = true;
            this.btnComSetting2.Click += new System.EventHandler(this.btnComSetting2_Click);
            // 
            // labelSetting1
            // 
            this.labelSetting1.AutoSize = true;
            this.labelSetting1.Location = new System.Drawing.Point(93, 45);
            this.labelSetting1.Name = "labelSetting1";
            this.labelSetting1.Size = new System.Drawing.Size(0, 13);
            this.labelSetting1.TabIndex = 4;
            // 
            // labelSetting2
            // 
            this.labelSetting2.AutoSize = true;
            this.labelSetting2.Location = new System.Drawing.Point(93, 74);
            this.labelSetting2.Name = "labelSetting2";
            this.labelSetting2.Size = new System.Drawing.Size(0, 13);
            this.labelSetting2.TabIndex = 5;
            // 
            // FormComChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 198);
            this.Controls.Add(this.labelSetting2);
            this.Controls.Add(this.labelSetting1);
            this.Controls.Add(this.btnComSetting2);
            this.Controls.Add(this.btnComSetting1);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.btnClose);
            this.Name = "FormComChange";
            this.Text = "FormComChange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button btnComSetting1;
        private System.Windows.Forms.Button btnComSetting2;
        private System.Windows.Forms.Label labelSetting1;
        private System.Windows.Forms.Label labelSetting2;
    }
}
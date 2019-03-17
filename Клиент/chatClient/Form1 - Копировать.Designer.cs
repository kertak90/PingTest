﻿namespace chatClient
{
    partial class chatForm
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
            this.enterChat = new System.Windows.Forms.Button();
            this.gui_userName = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.chat_msg = new System.Windows.Forms.TextBox();
            this.chat_send = new System.Windows.Forms.Button();
            this.gui_chat = new System.Windows.Forms.Label();
            this.ServerHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enterChat
            // 
            this.enterChat.Location = new System.Drawing.Point(301, 5);
            this.enterChat.Margin = new System.Windows.Forms.Padding(4);
            this.enterChat.Name = "enterChat";
            this.enterChat.Size = new System.Drawing.Size(164, 28);
            this.enterChat.TabIndex = 0;
            this.enterChat.Text = "Войти в чат";
            this.enterChat.UseVisualStyleBackColor = true;
            this.enterChat.Click += new System.EventHandler(this.enterChat_Click);
            // 
            // gui_userName
            // 
            this.gui_userName.AutoSize = true;
            this.gui_userName.Location = new System.Drawing.Point(6, 11);
            this.gui_userName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gui_userName.Name = "gui_userName";
            this.gui_userName.Size = new System.Drawing.Size(138, 17);
            this.gui_userName.TabIndex = 1;
            this.gui_userName.Text = "Введите ваше имя: ";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(160, 6);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(132, 22);
            this.userName.TabIndex = 2;
            // 
            // chatBox
            // 
            this.chatBox.Enabled = false;
            this.chatBox.Location = new System.Drawing.Point(16, 177);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(697, 235);
            this.chatBox.TabIndex = 3;
            this.chatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatBox_KeyDown);
            // 
            // chat_msg
            // 
            this.chat_msg.Enabled = false;
            this.chat_msg.Location = new System.Drawing.Point(16, 423);
            this.chat_msg.Margin = new System.Windows.Forms.Padding(4);
            this.chat_msg.Name = "chat_msg";
            this.chat_msg.Size = new System.Drawing.Size(525, 22);
            this.chat_msg.TabIndex = 4;
            this.chat_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_msg_KeyDown);
            // 
            // chat_send
            // 
            this.chat_send.Enabled = false;
            this.chat_send.Location = new System.Drawing.Point(551, 421);
            this.chat_send.Margin = new System.Windows.Forms.Padding(4);
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(164, 28);
            this.chat_send.TabIndex = 5;
            this.chat_send.Text = "Отправить";
            this.chat_send.UseVisualStyleBackColor = true;
            this.chat_send.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // gui_chat
            // 
            this.gui_chat.AutoSize = true;
            this.gui_chat.Location = new System.Drawing.Point(16, 158);
            this.gui_chat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gui_chat.Name = "gui_chat";
            this.gui_chat.Size = new System.Drawing.Size(37, 17);
            this.gui_chat.TabIndex = 6;
            this.gui_chat.Text = "Чат:";
            // 
            // ServerHost
            // 
            this.ServerHost.Location = new System.Drawing.Point(160, 36);
            this.ServerHost.Margin = new System.Windows.Forms.Padding(4);
            this.ServerHost.Name = "ServerHost";
            this.ServerHost.Size = new System.Drawing.Size(132, 22);
            this.ServerHost.TabIndex = 7;
            this.ServerHost.TextChanged += new System.EventHandler(this.ServerHost_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите IP сервера: ";
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerHost);
            this.Controls.Add(this.gui_chat);
            this.Controls.Add(this.chat_send);
            this.Controls.Add(this.chat_msg);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.gui_userName);
            this.Controls.Add(this.enterChat);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "chatForm";
            this.Text = "OnlineChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterChat;
        private System.Windows.Forms.Label gui_userName;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox chat_msg;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.Label gui_chat;
        private System.Windows.Forms.TextBox ServerHost;
        private System.Windows.Forms.Label label1;
    }
}


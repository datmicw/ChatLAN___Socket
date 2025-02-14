namespace ChatLAN___Socket
{
    partial class Chat
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
            this.txt_enterMessage = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.ltb_showMessage = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txt_enterMessage
            // 
            this.txt_enterMessage.Location = new System.Drawing.Point(12, 222);
            this.txt_enterMessage.Name = "txt_enterMessage";
            this.txt_enterMessage.Size = new System.Drawing.Size(280, 20);
            this.txt_enterMessage.TabIndex = 0;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(299, 222);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 20);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // ltb_showMessage
            // 
            this.ltb_showMessage.FormattingEnabled = true;
            this.ltb_showMessage.Location = new System.Drawing.Point(12, 20);
            this.ltb_showMessage.Name = "ltb_showMessage";
            this.ltb_showMessage.Size = new System.Drawing.Size(360, 173);
            this.ltb_showMessage.TabIndex = 2;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.ltb_showMessage);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_enterMessage);
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_enterMessage;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.ListBox ltb_showMessage;
    }
}


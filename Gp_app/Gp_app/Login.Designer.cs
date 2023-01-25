
namespace Gp_app
{
    partial class Login
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
            this.LoginButtton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.EndButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButtton
            // 
            this.LoginButtton.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.LoginButtton.Location = new System.Drawing.Point(312, 123);
            this.LoginButtton.Name = "LoginButtton";
            this.LoginButtton.Size = new System.Drawing.Size(125, 38);
            this.LoginButtton.TabIndex = 0;
            this.LoginButtton.Text = "ログイン";
            this.LoginButtton.UseVisualStyleBackColor = true;
            this.LoginButtton.Click += new System.EventHandler(this.LoginButtton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(-1, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "パスワード";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(160, 70);
            this.PasswordBox.MaxLength = 4;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(185, 22);
            this.PasswordBox.TabIndex = 5;
            // 
            // EndButton
            // 
            this.EndButton.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EndButton.Location = new System.Drawing.Point(161, 123);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(125, 38);
            this.EndButton.TabIndex = 6;
            this.EndButton.Text = "戻る";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Font = new System.Drawing.Font("MS UI Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChangeButton.Location = new System.Drawing.Point(351, 62);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(85, 32);
            this.ChangeButton.TabIndex = 7;
            this.ChangeButton.Text = "表示切替";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(161, 23);
            this.UserNameBox.MaxLength = 20;
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(185, 22);
            this.UserNameBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(-1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "ユーザー名";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 173);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginButtton);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButtton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.Label label1;
    }
}

namespace Gp_app
{
    partial class MainMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Creation_account_button = new System.Windows.Forms.Button();
            this.Search_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Creation_account_button
            // 
            this.Creation_account_button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Creation_account_button.Location = new System.Drawing.Point(12, 12);
            this.Creation_account_button.Name = "Creation_account_button";
            this.Creation_account_button.Size = new System.Drawing.Size(167, 86);
            this.Creation_account_button.TabIndex = 0;
            this.Creation_account_button.Text = "登録";
            this.Creation_account_button.UseVisualStyleBackColor = true;
            this.Creation_account_button.Click += new System.EventHandler(this.CreationAccountButtonClick);
            // 
            // Search_button
            // 
            this.Search_button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Search_button.Location = new System.Drawing.Point(185, 12);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(167, 86);
            this.Search_button.TabIndex = 1;
            this.Search_button.Text = "検索";
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // Exit_button
            // 
            this.Exit_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit_button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Exit_button.Location = new System.Drawing.Point(94, 104);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(167, 66);
            this.Exit_button.TabIndex = 5;
            this.Exit_button.Text = "ログアウト";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit_button;
            this.ClientSize = new System.Drawing.Size(364, 182);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Search_button);
            this.Controls.Add(this.Creation_account_button);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メインメニュー";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Creation_account_button;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.Button Exit_button;
    }
}


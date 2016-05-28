namespace DBCourseWork.OperatorForms
{
    partial class SellerMenuForm
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
            this.sellLink = new System.Windows.Forms.LinkLabel();
            this.cardLink = new System.Windows.Forms.LinkLabel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sellLink
            // 
            this.sellLink.AutoSize = true;
            this.sellLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sellLink.Location = new System.Drawing.Point(12, 9);
            this.sellLink.Name = "sellLink";
            this.sellLink.Size = new System.Drawing.Size(187, 25);
            this.sellLink.TabIndex = 0;
            this.sellLink.TabStop = true;
            this.sellLink.Text = "1. Продати Товар";
            // 
            // cardLink
            // 
            this.cardLink.AutoSize = true;
            this.cardLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cardLink.Location = new System.Drawing.Point(12, 58);
            this.cardLink.Name = "cardLink";
            this.cardLink.Size = new System.Drawing.Size(261, 25);
            this.cardLink.TabIndex = 1;
            this.cardLink.TabStop = true;
            this.cardLink.Text = "2. Зареєструвати Картку";
            this.cardLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cardLink_LinkClicked);
            // 
            // exitBtn
            // 
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.Location = new System.Drawing.Point(17, 113);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(243, 23);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Вийти";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // SellerMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(272, 143);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.cardLink);
            this.Controls.Add(this.sellLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellerMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню Оператора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel sellLink;
        private System.Windows.Forms.LinkLabel cardLink;
        private System.Windows.Forms.Button exitBtn;
    }
}
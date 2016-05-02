namespace DBCourseWork
{
    partial class AdminMenuForm
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.contrLink = new System.Windows.Forms.LinkLabel();
            this.itemLink = new System.Windows.Forms.LinkLabel();
            this.deleteLink = new System.Windows.Forms.LinkLabel();
            this.goodsLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(13, 197);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(259, 23);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // contrLink
            // 
            this.contrLink.AutoSize = true;
            this.contrLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contrLink.Location = new System.Drawing.Point(13, 13);
            this.contrLink.Name = "contrLink";
            this.contrLink.Size = new System.Drawing.Size(263, 25);
            this.contrLink.TabIndex = 1;
            this.contrLink.TabStop = true;
            this.contrLink.Text = "1. Register new contractor";
            this.contrLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.contrLink_LinkClicked);
            // 
            // itemLink
            // 
            this.itemLink.AutoSize = true;
            this.itemLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemLink.Location = new System.Drawing.Point(13, 60);
            this.itemLink.Name = "itemLink";
            this.itemLink.Size = new System.Drawing.Size(207, 25);
            this.itemLink.TabIndex = 2;
            this.itemLink.TabStop = true;
            this.itemLink.Text = "2. Register new item";
            this.itemLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.itemLink_LinkClicked);
            // 
            // deleteLink
            // 
            this.deleteLink.AutoSize = true;
            this.deleteLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLink.Location = new System.Drawing.Point(13, 106);
            this.deleteLink.Name = "deleteLink";
            this.deleteLink.Size = new System.Drawing.Size(132, 25);
            this.deleteLink.TabIndex = 3;
            this.deleteLink.TabStop = true;
            this.deleteLink.Text = "3. Debit item";
            this.deleteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteLink_LinkClicked);
            // 
            // goodsLink
            // 
            this.goodsLink.AutoSize = true;
            this.goodsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goodsLink.Location = new System.Drawing.Point(13, 154);
            this.goodsLink.Name = "goodsLink";
            this.goodsLink.Size = new System.Drawing.Size(237, 25);
            this.goodsLink.TabIndex = 4;
            this.goodsLink.TabStop = true;
            this.goodsLink.Text = "4. Purchase new goods";
            this.goodsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.goodsLink_LinkClicked);
            // 
            // AdminMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.goodsLink);
            this.Controls.Add(this.deleteLink);
            this.Controls.Add(this.itemLink);
            this.Controls.Add(this.contrLink);
            this.Controls.Add(this.exitBtn);
            this.Name = "AdminMenuForm";
            this.Text = "AdminMenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.LinkLabel contrLink;
        private System.Windows.Forms.LinkLabel itemLink;
        private System.Windows.Forms.LinkLabel deleteLink;
        private System.Windows.Forms.LinkLabel goodsLink;
    }
}
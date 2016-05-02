namespace DBCourseWork
{
    partial class SellingPageForm
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
            this.itemstxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actiontxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPrice_lbl = new System.Windows.Forms.Label();
            this.sellBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemstxt
            // 
            this.itemstxt.Location = new System.Drawing.Point(114, 13);
            this.itemstxt.Name = "itemstxt";
            this.itemstxt.Size = new System.Drawing.Size(294, 20);
            this.itemstxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Items Codes:";
            // 
            // actiontxt
            // 
            this.actiontxt.Location = new System.Drawing.Point(114, 53);
            this.actiontxt.Name = "actiontxt";
            this.actiontxt.Size = new System.Drawing.Size(294, 20);
            this.actiontxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Action Code:";
            // 
            // totalPrice_lbl
            // 
            this.totalPrice_lbl.AutoSize = true;
            this.totalPrice_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPrice_lbl.Location = new System.Drawing.Point(80, 89);
            this.totalPrice_lbl.Name = "totalPrice_lbl";
            this.totalPrice_lbl.Size = new System.Drawing.Size(245, 36);
            this.totalPrice_lbl.TabIndex = 4;
            this.totalPrice_lbl.Text = "Total Price: * hrn.";
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(15, 139);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(167, 23);
            this.sellBtn.TabIndex = 5;
            this.sellBtn.Text = "Sell";
            this.sellBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(241, 139);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(167, 23);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Exit to Menu";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // SellingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.sellBtn);
            this.Controls.Add(this.totalPrice_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actiontxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemstxt);
            this.Name = "SellingPageForm";
            this.Text = "Sell Items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox itemstxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox actiontxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalPrice_lbl;
        private System.Windows.Forms.Button sellBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}
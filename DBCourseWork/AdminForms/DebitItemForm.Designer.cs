using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.AdminForms
{
    partial class DebitItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label2 = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.sellBtn = new System.Windows.Forms.Button();
            this.itemsCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contrCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Кількість товару:";
            // 
            // quantityTxt
            // 
            this.quantityTxt.Location = new System.Drawing.Point(128, 72);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(294, 20);
            this.quantityTxt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Назва товару:";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(255, 105);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(167, 23);
            this.exitBtn.TabIndex = 9;
            this.exitBtn.Text = "Вийти в Меню";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(15, 105);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(167, 23);
            this.sellBtn.TabIndex = 8;
            this.sellBtn.Text = "Списати";
            this.sellBtn.UseVisualStyleBackColor = true;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // itemsCombobox
            // 
            this.itemsCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.itemsCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.itemsCombobox.FormattingEnabled = true;
            this.itemsCombobox.Location = new System.Drawing.Point(128, 15);
            this.itemsCombobox.Name = "itemsCombobox";
            this.itemsCombobox.Size = new System.Drawing.Size(294, 21);
            this.itemsCombobox.TabIndex = 10;
            this.itemsCombobox.SelectedIndexChanged += new System.EventHandler(this.itemsCombobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Контрагент:";
            // 
            // contrCombobox
            // 
            this.contrCombobox.FormattingEnabled = true;
            this.contrCombobox.Location = new System.Drawing.Point(128, 42);
            this.contrCombobox.Name = "contrCombobox";
            this.contrCombobox.Size = new System.Drawing.Size(294, 21);
            this.contrCombobox.TabIndex = 12;
            // 
            // DebitItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 139);
            this.Controls.Add(this.contrCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemsCombobox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.sellBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantityTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebitItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Списати Товар";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private TextBox quantityTxt;
        private Label label1;
        private Button exitBtn;
        private Button sellBtn;
        private ComboBox itemsCombobox;
        private Label label3;
        private ComboBox contrCombobox;
    }
}
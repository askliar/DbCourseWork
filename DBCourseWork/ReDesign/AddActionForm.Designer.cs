using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.ReDesign
{
    partial class AddActionForm
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
            this.addActionBtn = new System.Windows.Forms.Button();
            this.discountTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addActionBtn
            // 
            this.addActionBtn.Location = new System.Drawing.Point(15, 99);
            this.addActionBtn.Name = "addActionBtn";
            this.addActionBtn.Size = new System.Drawing.Size(393, 23);
            this.addActionBtn.TabIndex = 33;
            this.addActionBtn.Text = "Додати Картку";
            this.addActionBtn.UseVisualStyleBackColor = true;
            this.addActionBtn.Click += new System.EventHandler(this.addActionBtn_Click);
            // 
            // discountTxt
            // 
            this.discountTxt.Location = new System.Drawing.Point(114, 73);
            this.discountTxt.Name = "discountTxt";
            this.discountTxt.Size = new System.Drawing.Size(294, 20);
            this.discountTxt.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Дата початку:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(114, 3);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(294, 20);
            this.startDatePicker.TabIndex = 30;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(114, 38);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(294, 20);
            this.endDatePicker.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Дата закінчення:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Знижка:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(393, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Вийти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 152);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.discountTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addActionBtn);
            this.Name = "AddActionForm";
            this.Text = "AddActionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button addActionBtn;
        private TextBox discountTxt;
        private Label label3;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Label label4;
        private Label label5;
        private Button button1;
    }
}
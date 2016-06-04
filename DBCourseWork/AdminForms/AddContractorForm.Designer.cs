using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.AdminForms
{
    partial class AddContractorForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.phoneTxt = new System.Windows.Forms.TextBox();
            this.individRadio = new System.Windows.Forms.RadioButton();
            this.entityRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.registrationNumTxt = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Номер телефона:";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(746, 262);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(167, 23);
            this.exitBtn.TabIndex = 21;
            this.exitBtn.Text = "Вийти в Меню";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(520, 263);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(167, 23);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Додати Контрагента";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Назва контрагента:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Адреса контрагента:";
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(628, 47);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(285, 20);
            this.addressTxt.TabIndex = 25;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(628, 6);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(285, 20);
            this.nameTxt.TabIndex = 24;
            // 
            // phoneTxt
            // 
            this.phoneTxt.Location = new System.Drawing.Point(628, 85);
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(285, 20);
            this.phoneTxt.TabIndex = 26;
            // 
            // individRadio
            // 
            this.individRadio.AutoSize = true;
            this.individRadio.Location = new System.Drawing.Point(6, 19);
            this.individRadio.Name = "individRadio";
            this.individRadio.Size = new System.Drawing.Size(100, 17);
            this.individRadio.TabIndex = 27;
            this.individRadio.TabStop = true;
            this.individRadio.Text = "Фізична особа";
            this.individRadio.UseVisualStyleBackColor = true;
            this.individRadio.CheckedChanged += new System.EventHandler(this.individRadio_CheckedChanged);
            // 
            // entityRadio
            // 
            this.entityRadio.AutoSize = true;
            this.entityRadio.Location = new System.Drawing.Point(6, 42);
            this.entityRadio.Name = "entityRadio";
            this.entityRadio.Size = new System.Drawing.Size(108, 17);
            this.entityRadio.TabIndex = 28;
            this.entityRadio.TabStop = true;
            this.entityRadio.Text = "Юридична особа";
            this.entityRadio.UseVisualStyleBackColor = true;
            this.entityRadio.CheckedChanged += new System.EventHandler(this.entityRadio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.individRadio);
            this.groupBox1.Controls.Add(this.entityRadio);
            this.groupBox1.Location = new System.Drawing.Point(664, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 70);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Оберіть тип контрагента:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Дата народження:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Реєстраційний номер:";
            // 
            // birthDatePicker
            // 
            this.birthDatePicker.Location = new System.Drawing.Point(664, 191);
            this.birthDatePicker.Name = "birthDatePicker";
            this.birthDatePicker.Size = new System.Drawing.Size(249, 20);
            this.birthDatePicker.TabIndex = 33;
            // 
            // registrationNumTxt
            // 
            this.registrationNumTxt.Location = new System.Drawing.Point(664, 222);
            this.registrationNumTxt.Name = "registrationNumTxt";
            this.registrationNumTxt.Size = new System.Drawing.Size(249, 20);
            this.registrationNumTxt.TabIndex = 34;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(499, 490);
            this.dataGridView1.TabIndex = 35;
            // 
            // AddContractorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 508);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.registrationNumTxt);
            this.Controls.Add(this.birthDatePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.phoneTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddContractorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Додати Контрагента";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label3;
        private Button exitBtn;
        private Button addBtn;
        private Label label2;
        private Label label1;
        private TextBox addressTxt;
        private TextBox nameTxt;
        private TextBox phoneTxt;
        private RadioButton individRadio;
        private RadioButton entityRadio;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker birthDatePicker;
        private TextBox registrationNumTxt;
        private DataGridView dataGridView1;
    }
}
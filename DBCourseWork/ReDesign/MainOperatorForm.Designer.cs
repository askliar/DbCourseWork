using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.ReDesign
{
    partial class MainOperatorForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.IdGood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.sellBtn = new System.Windows.Forms.Button();
            this.totalPrice_lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.actiontxt = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.individRadio = new System.Windows.Forms.RadioButton();
            this.entityRadio = new System.Windows.Forms.RadioButton();
            this.exitBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.quantityTxt);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.sellBtn);
            this.tabPage2.Controls.Add(this.totalPrice_lbl);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.actiontxt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1226, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Продаж товару";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(7, 7);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(642, 450);
            this.dataGridView3.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(672, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Кількість Товару:";
            // 
            // quantityTxt
            // 
            this.quantityTxt.Location = new System.Drawing.Point(783, 8);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(427, 20);
            this.quantityTxt.TabIndex = 20;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(675, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(535, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Додати Товар в Кошик";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGood,
            this.GoodPrice,
            this.GoodName,
            this.quantity,
            this.contractor});
            this.dataGridView2.Location = new System.Drawing.Point(675, 78);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(535, 270);
            this.dataGridView2.TabIndex = 18;
            // 
            // IdGood
            // 
            this.IdGood.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdGood.HeaderText = "Код Товару";
            this.IdGood.Name = "IdGood";
            this.IdGood.ReadOnly = true;
            // 
            // GoodPrice
            // 
            this.GoodPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GoodPrice.HeaderText = "Ціна Товару";
            this.GoodPrice.Name = "GoodPrice";
            this.GoodPrice.ReadOnly = true;
            // 
            // GoodName
            // 
            this.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GoodName.HeaderText = "Назва Товару";
            this.GoodName.Name = "GoodName";
            this.GoodName.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Кількість";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // contractor
            // 
            this.contractor.HeaderText = "Контрагент";
            this.contractor.Name = "contractor";
            this.contractor.ReadOnly = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(975, 429);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(235, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "Вийти";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(675, 429);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(226, 23);
            this.sellBtn.TabIndex = 16;
            this.sellBtn.Text = "Продати";
            this.sellBtn.UseVisualStyleBackColor = true;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // totalPrice_lbl
            // 
            this.totalPrice_lbl.AutoSize = true;
            this.totalPrice_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPrice_lbl.Location = new System.Drawing.Point(783, 381);
            this.totalPrice_lbl.Name = "totalPrice_lbl";
            this.totalPrice_lbl.Size = new System.Drawing.Size(324, 36);
            this.totalPrice_lbl.TabIndex = 15;
            this.totalPrice_lbl.Text = "Загальна Ціна: * грн.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(677, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Код картки:";
            // 
            // actiontxt
            // 
            this.actiontxt.Location = new System.Drawing.Point(783, 358);
            this.actiontxt.Name = "actiontxt";
            this.actiontxt.Size = new System.Drawing.Size(427, 20);
            this.actiontxt.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.exitBtn);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1226, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Робота з контрагентами і товаром";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(830, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(390, 23);
            this.button4.TabIndex = 71;
            this.button4.Text = "Приготувати звіт";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(830, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(390, 23);
            this.button3.TabIndex = 70;
            this.button3.Text = "Додати акцію для обраного контрагента";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(824, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Оберіть тип контрагента:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.individRadio);
            this.groupBox1.Controls.Add(this.entityRadio);
            this.groupBox1.Location = new System.Drawing.Point(971, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 70);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
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
            this.individRadio.CheckedChanged += new System.EventHandler(this.individRadio_CheckedChanged_1);
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
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(830, 139);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(390, 23);
            this.exitBtn.TabIndex = 57;
            this.exitBtn.Text = "Вийти";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(812, 453);
            this.dataGridView1.TabIndex = 53;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabPage1);
            this.tab1.Controls.Add(this.tabPage2);
            this.tab1.Location = new System.Drawing.Point(12, 2);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(1234, 489);
            this.tab1.TabIndex = 53;
            this.tab1.SelectedIndexChanged += new System.EventHandler(this.tab1_SelectedIndexChanged);
            // 
            // MainOperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 492);
            this.Controls.Add(this.tab1);
            this.Name = "MainOperatorForm";
            this.Text = "Форма роботи з контрагентами";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabPage2;
        private TabPage tabPage1;
        private Button button4;
        private Button button3;
        private Label label4;
        private GroupBox groupBox1;
        private RadioButton individRadio;
        private RadioButton entityRadio;
        private Button exitBtn;
        private DataGridView dataGridView1;
        private TabControl tab1;
        private Label label7;
        private TextBox quantityTxt;
        private Button button5;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn IdGood;
        private DataGridViewTextBoxColumn GoodPrice;
        private DataGridViewTextBoxColumn GoodName;
        private DataGridViewTextBoxColumn quantity;
        private Button button6;
        private Button sellBtn;
        private Label totalPrice_lbl;
        private Label label8;
        private TextBox actiontxt;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn contractor;
    }
}
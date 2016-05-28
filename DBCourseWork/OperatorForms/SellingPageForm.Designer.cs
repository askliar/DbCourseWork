using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.OperatorForms
{
    partial class SellingPageForm
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
            this.itemstxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actiontxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPrice_lbl = new System.Windows.Forms.Label();
            this.sellBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdGood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemstxt
            // 
            this.itemstxt.Location = new System.Drawing.Point(114, 13);
            this.itemstxt.Name = "itemstxt";
            this.itemstxt.Size = new System.Drawing.Size(483, 20);
            this.itemstxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код Товару:";
            // 
            // actiontxt
            // 
            this.actiontxt.Location = new System.Drawing.Point(114, 339);
            this.actiontxt.Name = "actiontxt";
            this.actiontxt.Size = new System.Drawing.Size(483, 20);
            this.actiontxt.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Код картки:";
            // 
            // totalPrice_lbl
            // 
            this.totalPrice_lbl.AutoSize = true;
            this.totalPrice_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPrice_lbl.Location = new System.Drawing.Point(170, 362);
            this.totalPrice_lbl.Name = "totalPrice_lbl";
            this.totalPrice_lbl.Size = new System.Drawing.Size(324, 36);
            this.totalPrice_lbl.TabIndex = 4;
            this.totalPrice_lbl.Text = "Загальна Ціна: * грн.";
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(6, 410);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(282, 23);
            this.sellBtn.TabIndex = 5;
            this.sellBtn.Text = "Продати";
            this.sellBtn.UseVisualStyleBackColor = true;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(306, 410);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(291, 23);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Вийти в Меню";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGood,
            this.GoodPrice,
            this.GoodName,
            this.quantity});
            this.dataGridView1.Location = new System.Drawing.Point(6, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(591, 223);
            this.dataGridView1.TabIndex = 7;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(591, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Додати Товар в Кошик";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quantityTxt
            // 
            this.quantityTxt.Location = new System.Drawing.Point(114, 41);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(483, 20);
            this.quantityTxt.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Кількість Товару:";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Кількість";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // SellingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 445);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quantityTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.sellBtn);
            this.Controls.Add(this.totalPrice_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actiontxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemstxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellingPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sell Items";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox itemstxt;
        private Label label1;
        private TextBox actiontxt;
        private Label label2;
        private Label totalPrice_lbl;
        private Button sellBtn;
        private Button exitBtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdGood;
        private DataGridViewTextBoxColumn GoodPrice;
        private DataGridViewTextBoxColumn GoodName;
        private Button button1;
        private TextBox quantityTxt;
        private Label label3;
        private DataGridViewTextBoxColumn quantity;
    }
}
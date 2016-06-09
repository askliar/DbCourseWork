using System.ComponentModel;
using System.Windows.Forms;

namespace DBCourseWork.ReDesign
{
    partial class BuyItemForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sellBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bookRadio = new System.Windows.Forms.RadioButton();
            this.otherRadio = new System.Windows.Forms.RadioButton();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 9);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(668, 267);
            this.dataGridView1.TabIndex = 22;
            // 
            // sellBtn
            // 
            this.sellBtn.Location = new System.Drawing.Point(689, 152);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(387, 21);
            this.sellBtn.TabIndex = 17;
            this.sellBtn.Text = "Закупити товар";
            this.sellBtn.UseVisualStyleBackColor = true;
            this.sellBtn.Click += new System.EventHandler(this.sellBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Кількість товару:";
            // 
            // quantityTxt
            // 
            this.quantityTxt.Location = new System.Drawing.Point(785, 97);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(291, 20);
            this.quantityTxt.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(387, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Вийти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Оберіть тип товару:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bookRadio);
            this.groupBox1.Controls.Add(this.otherRadio);
            this.groupBox1.Location = new System.Drawing.Point(827, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 70);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-138, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Quantity:";
            // 
            // bookRadio
            // 
            this.bookRadio.AutoSize = true;
            this.bookRadio.Location = new System.Drawing.Point(6, 19);
            this.bookRadio.Name = "bookRadio";
            this.bookRadio.Size = new System.Drawing.Size(55, 17);
            this.bookRadio.TabIndex = 27;
            this.bookRadio.TabStop = true;
            this.bookRadio.Text = "Книга";
            this.bookRadio.UseVisualStyleBackColor = true;
            this.bookRadio.CheckedChanged += new System.EventHandler(this.bookRadio_CheckedChanged_1);
            // 
            // otherRadio
            // 
            this.otherRadio.AutoSize = true;
            this.otherRadio.Location = new System.Drawing.Point(6, 42);
            this.otherRadio.Name = "otherRadio";
            this.otherRadio.Size = new System.Drawing.Size(88, 17);
            this.otherRadio.TabIndex = 28;
            this.otherRadio.TabStop = true;
            this.otherRadio.Text = "Інший Товар";
            this.otherRadio.UseVisualStyleBackColor = true;
            this.otherRadio.CheckedChanged += new System.EventHandler(this.otherRadio_CheckedChanged_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(689, 179);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(387, 23);
            this.button7.TabIndex = 73;
            this.button7.Text = "Зареєструвати товар";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.goodTerm,
            this.authorName,
            this.bookName,
            this.price,
            this.quantity});
            this.dataGridView2.Location = new System.Drawing.Point(12, 298);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(666, 181);
            this.dataGridView2.TabIndex = 74;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Назва Товару";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            // 
            // goodTerm
            // 
            this.goodTerm.HeaderText = "Строк Реалізації";
            this.goodTerm.Name = "goodTerm";
            this.goodTerm.ReadOnly = true;
            // 
            // authorName
            // 
            this.authorName.HeaderText = "Ім\'я Автора";
            this.authorName.Name = "authorName";
            this.authorName.ReadOnly = true;
            // 
            // bookName
            // 
            this.bookName.HeaderText = "Назва Книги";
            this.bookName.Name = "bookName";
            this.bookName.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Ціна Товару";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Кількість Товару";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(689, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(387, 23);
            this.button2.TabIndex = 75;
            this.button2.Text = "Додати товар в кошик";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BuyItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 491);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sellBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quantityTxt);
            this.Name = "BuyItemForm";
            this.Text = "DebitItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button sellBtn;
        private Label label2;
        private TextBox quantityTxt;
        private Button button1;
        private Label label4;
        private GroupBox groupBox1;
        private Label label7;
        private RadioButton bookRadio;
        private RadioButton otherRadio;
        private Button button7;
        private DataGridView dataGridView2;
        private Button button2;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn goodTerm;
        private DataGridViewTextBoxColumn authorName;
        private DataGridViewTextBoxColumn bookName;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn quantity;
    }
}
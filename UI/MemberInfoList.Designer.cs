namespace UI
{
    partial class MemberInfoList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textXms = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSjs = new System.Windows.Forms.TextBox();
            this.buttonxianshi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonleixing = new System.Windows.Forms.Button();
            this.textXmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textSjt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textMoney = new System.Windows.Forms.TextBox();
            this.buttonquxiao = new System.Windows.Forms.Button();
            this.buttonshanchu = new System.Windows.Forms.Button();
            this.buttontianjia = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MtypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mmoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 491);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mid,
            this.Mname,
            this.MtypeId,
            this.Mphone,
            this.Mmoney});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(737, 467);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonxianshi);
            this.groupBox2.Controls.Add(this.textSjs);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textXms);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(761, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 137);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓  名:";
            // 
            // textXms
            // 
            this.textXms.Location = new System.Drawing.Point(73, 22);
            this.textXms.Name = "textXms";
            this.textXms.Size = new System.Drawing.Size(158, 25);
            this.textXms.TabIndex = 0;
            this.textXms.Leave += new System.EventHandler(this.textXms_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "手机号:";
            // 
            // textSjs
            // 
            this.textSjs.Location = new System.Drawing.Point(73, 53);
            this.textSjs.Name = "textSjs";
            this.textSjs.Size = new System.Drawing.Size(158, 25);
            this.textSjs.TabIndex = 1;
            this.textSjs.Leave += new System.EventHandler(this.textSjs_Leave);
            // 
            // buttonxianshi
            // 
            this.buttonxianshi.Location = new System.Drawing.Point(39, 87);
            this.buttonxianshi.Name = "buttonxianshi";
            this.buttonxianshi.Size = new System.Drawing.Size(163, 36);
            this.buttonxianshi.TabIndex = 2;
            this.buttonxianshi.Text = "显示全部";
            this.buttonxianshi.UseVisualStyleBackColor = true;
            this.buttonxianshi.Click += new System.EventHandler(this.buttonxianshi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonquxiao);
            this.groupBox3.Controls.Add(this.buttonshanchu);
            this.groupBox3.Controls.Add(this.buttontianjia);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.textSjt);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textMoney);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.buttonleixing);
            this.groupBox3.Controls.Add(this.textXmt);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBh);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(761, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 348);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "添加\\修改";
            // 
            // buttonleixing
            // 
            this.buttonleixing.Location = new System.Drawing.Point(116, 114);
            this.buttonleixing.Name = "buttonleixing";
            this.buttonleixing.Size = new System.Drawing.Size(121, 36);
            this.buttonleixing.TabIndex = 2;
            this.buttonleixing.Text = "类型管理";
            this.buttonleixing.UseVisualStyleBackColor = true;
            this.buttonleixing.Click += new System.EventHandler(this.buttonleixing_Click);
            // 
            // textXmt
            // 
            this.textXmt.Location = new System.Drawing.Point(73, 53);
            this.textXmt.Name = "textXmt";
            this.textXmt.Size = new System.Drawing.Size(158, 25);
            this.textXmt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "姓  名:";
            // 
            // textBh
            // 
            this.textBh.Location = new System.Drawing.Point(73, 22);
            this.textBh.Name = "textBh";
            this.textBh.ReadOnly = true;
            this.textBh.Size = new System.Drawing.Size(158, 25);
            this.textBh.TabIndex = 1;
            this.textBh.Text = "添加时无编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "编  号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "类  型:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(74, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "手机号:";
            // 
            // textSjt
            // 
            this.textSjt.Location = new System.Drawing.Point(79, 156);
            this.textSjt.Name = "textSjt";
            this.textSjt.Size = new System.Drawing.Size(158, 25);
            this.textSjt.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "余  额:";
            // 
            // textMoney
            // 
            this.textMoney.Location = new System.Drawing.Point(79, 187);
            this.textMoney.Name = "textMoney";
            this.textMoney.Size = new System.Drawing.Size(158, 25);
            this.textMoney.TabIndex = 1;
            // 
            // buttonquxiao
            // 
            this.buttonquxiao.Location = new System.Drawing.Point(156, 218);
            this.buttonquxiao.Name = "buttonquxiao";
            this.buttonquxiao.Size = new System.Drawing.Size(75, 37);
            this.buttonquxiao.TabIndex = 6;
            this.buttonquxiao.Text = "取消";
            this.buttonquxiao.UseVisualStyleBackColor = true;
            this.buttonquxiao.Click += new System.EventHandler(this.buttonquxiao_Click);
            // 
            // buttonshanchu
            // 
            this.buttonshanchu.Location = new System.Drawing.Point(25, 296);
            this.buttonshanchu.Name = "buttonshanchu";
            this.buttonshanchu.Size = new System.Drawing.Size(206, 37);
            this.buttonshanchu.TabIndex = 7;
            this.buttonshanchu.Text = "删除选中的行数据";
            this.buttonshanchu.UseVisualStyleBackColor = true;
            this.buttonshanchu.Click += new System.EventHandler(this.buttonshanchu_Click);
            // 
            // buttontianjia
            // 
            this.buttontianjia.Location = new System.Drawing.Point(53, 218);
            this.buttontianjia.Name = "buttontianjia";
            this.buttontianjia.Size = new System.Drawing.Size(75, 37);
            this.buttontianjia.TabIndex = 8;
            this.buttontianjia.Text = "添加";
            this.buttontianjia.UseVisualStyleBackColor = true;
            this.buttontianjia.Click += new System.EventHandler(this.buttontianjia_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(7, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "提示：双击表格项进行修改";
            // 
            // Mid
            // 
            this.Mid.DataPropertyName = "MId";
            this.Mid.HeaderText = "编号";
            this.Mid.Name = "Mid";
            this.Mid.ReadOnly = true;
            // 
            // Mname
            // 
            this.Mname.DataPropertyName = "MName";
            this.Mname.HeaderText = "姓名";
            this.Mname.Name = "Mname";
            this.Mname.ReadOnly = true;
            // 
            // MtypeId
            // 
            this.MtypeId.DataPropertyName = "TypeTitle";
            this.MtypeId.HeaderText = "类型";
            this.MtypeId.Name = "MtypeId";
            this.MtypeId.ReadOnly = true;
            // 
            // Mphone
            // 
            this.Mphone.DataPropertyName = "MPhone";
            this.Mphone.HeaderText = "手机号";
            this.Mphone.Name = "Mphone";
            this.Mphone.ReadOnly = true;
            // 
            // Mmoney
            // 
            this.Mmoney.DataPropertyName = "MMoney";
            this.Mmoney.HeaderText = "账户余额";
            this.Mmoney.Name = "Mmoney";
            this.Mmoney.ReadOnly = true;
            // 
            // MemberInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 527);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberInfoList";
            this.Text = "会员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberInfoList_FormClosing);
            this.Load += new System.EventHandler(this.MemberInfoList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonxianshi;
        private System.Windows.Forms.TextBox textSjs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textXms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textSjt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonleixing;
        private System.Windows.Forms.TextBox textXmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonquxiao;
        private System.Windows.Forms.Button buttonshanchu;
        private System.Windows.Forms.Button buttontianjia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MtypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mmoney;
    }
}
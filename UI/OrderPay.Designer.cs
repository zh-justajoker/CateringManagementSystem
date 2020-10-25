namespace UI
{
    partial class OrderPay
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbyue = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbdengji = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbzhekou = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbxfjine = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbysjine = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "是会员";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbzhekou);
            this.groupBox1.Controls.Add(this.lbyue);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lbdengji);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 183);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员编号:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "手 机 号:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "账户余额:";
            // 
            // lbyue
            // 
            this.lbyue.AutoSize = true;
            this.lbyue.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbyue.ForeColor = System.Drawing.Color.Red;
            this.lbyue.Location = new System.Drawing.Point(86, 107);
            this.lbyue.Name = "lbyue";
            this.lbyue.Size = new System.Drawing.Size(19, 19);
            this.lbyue.TabIndex = 3;
            this.lbyue.Text = "0";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(207, 108);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 19);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "使用余额";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "会员等级:";
            // 
            // lbdengji
            // 
            this.lbdengji.AutoSize = true;
            this.lbdengji.Location = new System.Drawing.Point(85, 150);
            this.lbdengji.Name = "lbdengji";
            this.lbdengji.Size = new System.Drawing.Size(67, 15);
            this.lbdengji.TabIndex = 0;
            this.lbdengji.Text = "普通会员";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "折  扣:";
            // 
            // lbzhekou
            // 
            this.lbzhekou.AutoSize = true;
            this.lbzhekou.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbzhekou.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbzhekou.Location = new System.Drawing.Point(270, 147);
            this.lbzhekou.Name = "lbzhekou";
            this.lbzhekou.Size = new System.Drawing.Size(19, 19);
            this.lbzhekou.TabIndex = 3;
            this.lbzhekou.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "消费金额:";
            // 
            // lbxfjine
            // 
            this.lbxfjine.AutoSize = true;
            this.lbxfjine.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxfjine.ForeColor = System.Drawing.Color.Red;
            this.lbxfjine.Location = new System.Drawing.Point(85, 234);
            this.lbxfjine.Name = "lbxfjine";
            this.lbxfjine.Size = new System.Drawing.Size(19, 19);
            this.lbxfjine.TabIndex = 3;
            this.lbxfjine.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "应收金额:";
            // 
            // lbysjine
            // 
            this.lbysjine.AutoSize = true;
            this.lbysjine.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbysjine.ForeColor = System.Drawing.Color.Red;
            this.lbysjine.Location = new System.Drawing.Point(267, 234);
            this.lbysjine.Name = "lbysjine";
            this.lbysjine.Size = new System.Drawing.Size(19, 19);
            this.lbysjine.TabIndex = 3;
            this.lbysjine.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "确认结账";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "暂不结账";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OrderPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 342);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbysjine);
            this.Controls.Add(this.lbxfjine);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "OrderPay";
            this.Text = "结账付款";
            this.Load += new System.EventHandler(this.OrderPay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbyue;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbdengji;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbzhekou;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbxfjine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbysjine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
namespace UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManager,
            this.menuMember,
            this.menuDish,
            this.menuTable,
            this.menuOrder,
            this.menuQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManager
            // 
            this.menuManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManager.Image = global::UI.Properties.Resources.manager;
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(76, 68);
            this.menuManager.Text = "manager";
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // menuMember
            // 
            this.menuMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMember.Image = global::UI.Properties.Resources.member;
            this.menuMember.Name = "menuMember";
            this.menuMember.Size = new System.Drawing.Size(76, 68);
            this.menuMember.Text = "member";
            this.menuMember.Click += new System.EventHandler(this.menuMember_Click);
            // 
            // menuDish
            // 
            this.menuDish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDish.Image = global::UI.Properties.Resources.menu;
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(76, 68);
            this.menuDish.Text = "dish";
            this.menuDish.Click += new System.EventHandler(this.menuDish_Click);
            // 
            // menuTable
            // 
            this.menuTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuTable.Image = global::UI.Properties.Resources.table;
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(76, 68);
            this.menuTable.Text = "table";
            this.menuTable.Click += new System.EventHandler(this.menuTable_Click);
            // 
            // menuOrder
            // 
            this.menuOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOrder.Image = global::UI.Properties.Resources.order;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(76, 68);
            this.menuOrder.Text = "order";
            this.menuOrder.Click += new System.EventHandler(this.menuOrder_Click);
            // 
            // menuQuit
            // 
            this.menuQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuQuit.Image = global::UI.Properties.Resources.quick;
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(76, 68);
            this.menuQuit.Text = "quit";
            this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 337);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "kongxian.png");
            this.imageList1.Images.SetKeyName(1, "fkongxian.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 409);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "餐饮管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.ToolStripMenuItem menuMember;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
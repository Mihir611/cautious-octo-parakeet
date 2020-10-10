namespace S.S.B_E_Mailing_System
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySuppliersInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyItemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.sendEMailToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(910, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSuppliersToolStripMenuItem,
            this.addItemsToolStripMenuItem});
            this.insertToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // addSuppliersToolStripMenuItem
            // 
            this.addSuppliersToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSuppliersToolStripMenuItem.Name = "addSuppliersToolStripMenuItem";
            this.addSuppliersToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.addSuppliersToolStripMenuItem.Text = "Add Suppliers Info";
            this.addSuppliersToolStripMenuItem.Click += new System.EventHandler(this.addSuppliersToolStripMenuItem_Click);
            // 
            // addItemsToolStripMenuItem
            // 
            this.addItemsToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemsToolStripMenuItem.Name = "addItemsToolStripMenuItem";
            this.addItemsToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.addItemsToolStripMenuItem.Text = "Add Items Items";
            this.addItemsToolStripMenuItem.Click += new System.EventHandler(this.addItemsToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifySuppliersInfoToolStripMenuItem,
            this.modifyItemInfoToolStripMenuItem});
            this.modifyToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.modifyToolStripMenuItem.Text = "Modify";
            // 
            // modifySuppliersInfoToolStripMenuItem
            // 
            this.modifySuppliersInfoToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifySuppliersInfoToolStripMenuItem.Name = "modifySuppliersInfoToolStripMenuItem";
            this.modifySuppliersInfoToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.modifySuppliersInfoToolStripMenuItem.Text = "Modify Suppliers Info";
            this.modifySuppliersInfoToolStripMenuItem.Click += new System.EventHandler(this.modifySuppliersInfoToolStripMenuItem_Click);
            // 
            // modifyItemInfoToolStripMenuItem
            // 
            this.modifyItemInfoToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyItemInfoToolStripMenuItem.Name = "modifyItemInfoToolStripMenuItem";
            this.modifyItemInfoToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.modifyItemInfoToolStripMenuItem.Text = "Modify Item Info";
            this.modifyItemInfoToolStripMenuItem.Click += new System.EventHandler(this.modifyItemInfoToolStripMenuItem_Click);
            // 
            // sendEMailToolStripMenuItem
            // 
            this.sendEMailToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendEMailToolStripMenuItem.Name = "sendEMailToolStripMenuItem";
            this.sendEMailToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
            this.sendEMailToolStripMenuItem.Text = "Send E-Mail";
            this.sendEMailToolStripMenuItem.Click += new System.EventHandler(this.sendEMailToolStripMenuItem_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailSentToolStripMenuItem});
            this.displayToolStripMenuItem.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // emailSentToolStripMenuItem
            // 
            this.emailSentToolStripMenuItem.Name = "emailSentToolStripMenuItem";
            this.emailSentToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.emailSentToolStripMenuItem.Text = "Email Sent";
            this.emailSentToolStripMenuItem.Click += new System.EventHandler(this.emailSentToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 526);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "home";
            this.ShowInTaskbar = false;
            this.Text = "home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySuppliersInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyItemInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSentToolStripMenuItem;
    }
}
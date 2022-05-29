namespace jpddoocp
{
    partial class MDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logInAccountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutAccountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.signUpAccountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.setupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSetupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountMenu,
            this.setupMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountMenu
            // 
            this.accountMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInAccountMenu,
            this.logOutAccountMenu,
            this.signUpAccountMenu});
            this.accountMenu.Name = "accountMenu";
            this.accountMenu.Size = new System.Drawing.Size(93, 29);
            this.accountMenu.Text = "Account";
            // 
            // logInAccountMenu
            // 
            this.logInAccountMenu.Name = "logInAccountMenu";
            this.logInAccountMenu.Size = new System.Drawing.Size(270, 34);
            this.logInAccountMenu.Text = "Log In";
            this.logInAccountMenu.Click += new System.EventHandler(this.logInAccountMenu_Click);
            // 
            // logOutAccountMenu
            // 
            this.logOutAccountMenu.Name = "logOutAccountMenu";
            this.logOutAccountMenu.Size = new System.Drawing.Size(270, 34);
            this.logOutAccountMenu.Text = "Log Out";
            this.logOutAccountMenu.Visible = false;
            this.logOutAccountMenu.Click += new System.EventHandler(this.logOutAccountMenu_Click);
            // 
            // signUpAccountMenu
            // 
            this.signUpAccountMenu.Name = "signUpAccountMenu";
            this.signUpAccountMenu.Size = new System.Drawing.Size(270, 34);
            this.signUpAccountMenu.Text = "Sign Up";
            this.signUpAccountMenu.Click += new System.EventHandler(this.signUpAccountMenu_Click);
            // 
            // setupMenu
            // 
            this.setupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseSetupMenu});
            this.setupMenu.Name = "setupMenu";
            this.setupMenu.Size = new System.Drawing.Size(74, 29);
            this.setupMenu.Text = "Setup";
            // 
            // databaseSetupMenu
            // 
            this.databaseSetupMenu.Name = "databaseSetupMenu";
            this.databaseSetupMenu.Size = new System.Drawing.Size(188, 34);
            this.databaseSetupMenu.Text = "Database";
            this.databaseSetupMenu.Click += new System.EventHandler(this.databaseSetupMenu_Click);
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(1325, 967);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountMenu;
        private System.Windows.Forms.ToolStripMenuItem logInAccountMenu;
        private System.Windows.Forms.ToolStripMenuItem logOutAccountMenu;
        private System.Windows.Forms.ToolStripMenuItem signUpAccountMenu;
        private System.Windows.Forms.ToolStripMenuItem setupMenu;
        private System.Windows.Forms.ToolStripMenuItem databaseSetupMenu;
    }
}
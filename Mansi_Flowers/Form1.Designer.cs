namespace Mansi_Flowers
{
    partial class Form1
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
            this.liliEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUpdateLilisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.liliOwnersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOwnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteOwnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liliRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betweenDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liliEntryToolStripMenuItem,
            this.liliOwnersToolStripMenuItem,
            this.liliRatesToolStripMenuItem,
            this.billPrintToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // liliEntryToolStripMenuItem
            // 
            this.liliEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUpdateLilisToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.liliEntryToolStripMenuItem.Name = "liliEntryToolStripMenuItem";
            this.liliEntryToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.liliEntryToolStripMenuItem.Text = "Lili &Entry";
            this.liliEntryToolStripMenuItem.Click += new System.EventHandler(this.liliEntryToolStripMenuItem_Click);
            // 
            // addUpdateLilisToolStripMenuItem
            // 
            this.addUpdateLilisToolStripMenuItem.Name = "addUpdateLilisToolStripMenuItem";
            this.addUpdateLilisToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addUpdateLilisToolStripMenuItem.Text = "&Add/Update Lilis";
            this.addUpdateLilisToolStripMenuItem.Click += new System.EventHandler(this.addUpdateLilisToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem1.Text = "E&xit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // liliOwnersToolStripMenuItem
            // 
            this.liliOwnersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOwnerToolStripMenuItem,
            this.deleteOwnerToolStripMenuItem});
            this.liliOwnersToolStripMenuItem.Name = "liliOwnersToolStripMenuItem";
            this.liliOwnersToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.liliOwnersToolStripMenuItem.Text = "Lili &owners";
            // 
            // addOwnerToolStripMenuItem
            // 
            this.addOwnerToolStripMenuItem.Name = "addOwnerToolStripMenuItem";
            this.addOwnerToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addOwnerToolStripMenuItem.Text = "Add &Owner";
            this.addOwnerToolStripMenuItem.Click += new System.EventHandler(this.addOwnerToolStripMenuItem_Click);
            // 
            // deleteOwnerToolStripMenuItem
            // 
            this.deleteOwnerToolStripMenuItem.Name = "deleteOwnerToolStripMenuItem";
            this.deleteOwnerToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteOwnerToolStripMenuItem.Text = "&Delete / Update Owner";
            this.deleteOwnerToolStripMenuItem.Click += new System.EventHandler(this.deleteOwnerToolStripMenuItem_Click);
            // 
            // liliRatesToolStripMenuItem
            // 
            this.liliRatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEditRateToolStripMenuItem});
            this.liliRatesToolStripMenuItem.Name = "liliRatesToolStripMenuItem";
            this.liliRatesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.liliRatesToolStripMenuItem.Text = "Lili &Rates";
            // 
            // addEditRateToolStripMenuItem
            // 
            this.addEditRateToolStripMenuItem.Name = "addEditRateToolStripMenuItem";
            this.addEditRateToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addEditRateToolStripMenuItem.Text = "Add/&Edit rate";
            this.addEditRateToolStripMenuItem.Click += new System.EventHandler(this.addEditRateToolStripMenuItem_Click);
            // 
            // billPrintToolStripMenuItem
            // 
            this.billPrintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthkyToolStripMenuItem,
            this.betweenDateToolStripMenuItem});
            this.billPrintToolStripMenuItem.Name = "billPrintToolStripMenuItem";
            this.billPrintToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.billPrintToolStripMenuItem.Text = "&Bill Print";
            // 
            // monthkyToolStripMenuItem
            // 
            this.monthkyToolStripMenuItem.Name = "monthkyToolStripMenuItem";
            this.monthkyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.monthkyToolStripMenuItem.Text = "Monthly";
            this.monthkyToolStripMenuItem.Click += new System.EventHandler(this.monthkyToolStripMenuItem_Click);
            // 
            // betweenDateToolStripMenuItem
            // 
            this.betweenDateToolStripMenuItem.Name = "betweenDateToolStripMenuItem";
            this.betweenDateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.betweenDateToolStripMenuItem.Text = "Between Dates";
            this.betweenDateToolStripMenuItem.Click += new System.EventHandler(this.betweenDateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = global::Mansi_Flowers.Properties.Resources._22262_white_lily_1920x1080_flower_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(676, 262);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mansi Flowers Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem liliOwnersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOwnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteOwnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liliRatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem betweenDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liliEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUpdateLilisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}


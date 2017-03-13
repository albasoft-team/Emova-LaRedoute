namespace safeprojectname
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.tabInterface = new System.Windows.Forms.TabControl();
            this.tabProduits = new System.Windows.Forms.TabPage();
            this.richConsoleProducts = new System.Windows.Forms.RichTextBox();
            this.tabOffres = new System.Windows.Forms.TabPage();
            this.richConsoleOffers = new System.Windows.Forms.RichTextBox();
            this.tabCommandes = new System.Windows.Forms.TabPage();
            this.richConsoleCommands = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStartProducts = new System.Windows.Forms.ToolStripButton();
            this.toolStopProducts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStartOffers = new System.Windows.Forms.ToolStripButton();
            this.toolStopOffers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStartCommands = new System.Windows.Forms.ToolStripButton();
            this.toolStopCommands = new System.Windows.Forms.ToolStripButton();
            this.tabInterface.SuspendLayout();
            this.tabProduits.SuspendLayout();
            this.tabOffres.SuspendLayout();
            this.tabCommandes.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.tabProduits);
            this.tabInterface.Controls.Add(this.tabOffres);
            this.tabInterface.Controls.Add(this.tabCommandes);
            this.tabInterface.Location = new System.Drawing.Point(-7, 32);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.SelectedIndex = 0;
            this.tabInterface.Size = new System.Drawing.Size(1091, 386);
            this.tabInterface.TabIndex = 0;
            // 
            // tabProduits
            // 
            this.tabProduits.Controls.Add(this.richConsoleProducts);
            this.tabProduits.Location = new System.Drawing.Point(4, 22);
            this.tabProduits.Name = "tabProduits";
            this.tabProduits.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduits.Size = new System.Drawing.Size(1083, 360);
            this.tabProduits.TabIndex = 0;
            this.tabProduits.Text = "Produits";
            this.tabProduits.UseVisualStyleBackColor = true;
            // 
            // richConsoleProducts
            // 
            this.richConsoleProducts.BackColor = System.Drawing.SystemColors.InfoText;
            this.richConsoleProducts.ForeColor = System.Drawing.SystemColors.Window;
            this.richConsoleProducts.Location = new System.Drawing.Point(3, 0);
            this.richConsoleProducts.Name = "richConsoleProducts";
            this.richConsoleProducts.ReadOnly = true;
            this.richConsoleProducts.Size = new System.Drawing.Size(908, 290);
            this.richConsoleProducts.TabIndex = 0;
            this.richConsoleProducts.Text = "";
            // 
            // tabOffres
            // 
            this.tabOffres.Controls.Add(this.richConsoleOffers);
            this.tabOffres.Location = new System.Drawing.Point(4, 22);
            this.tabOffres.Name = "tabOffres";
            this.tabOffres.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffres.Size = new System.Drawing.Size(1083, 360);
            this.tabOffres.TabIndex = 1;
            this.tabOffres.Text = "Offres";
            this.tabOffres.UseVisualStyleBackColor = true;
            // 
            // richConsoleOffers
            // 
            this.richConsoleOffers.BackColor = System.Drawing.SystemColors.InfoText;
            this.richConsoleOffers.ForeColor = System.Drawing.SystemColors.Window;
            this.richConsoleOffers.Location = new System.Drawing.Point(6, 3);
            this.richConsoleOffers.Name = "richConsoleOffers";
            this.richConsoleOffers.ReadOnly = true;
            this.richConsoleOffers.Size = new System.Drawing.Size(908, 290);
            this.richConsoleOffers.TabIndex = 1;
            this.richConsoleOffers.Text = "";
            // 
            // tabCommandes
            // 
            this.tabCommandes.Controls.Add(this.richConsoleCommands);
            this.tabCommandes.Location = new System.Drawing.Point(4, 22);
            this.tabCommandes.Name = "tabCommandes";
            this.tabCommandes.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommandes.Size = new System.Drawing.Size(1083, 360);
            this.tabCommandes.TabIndex = 2;
            this.tabCommandes.Text = "Commandes";
            this.tabCommandes.UseVisualStyleBackColor = true;
            // 
            // richConsoleCommands
            // 
            this.richConsoleCommands.BackColor = System.Drawing.SystemColors.InfoText;
            this.richConsoleCommands.ForeColor = System.Drawing.SystemColors.Window;
            this.richConsoleCommands.Location = new System.Drawing.Point(3, 0);
            this.richConsoleCommands.Name = "richConsoleCommands";
            this.richConsoleCommands.ReadOnly = true;
            this.richConsoleCommands.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richConsoleCommands.Size = new System.Drawing.Size(908, 290);
            this.richConsoleCommands.TabIndex = 1;
            this.richConsoleCommands.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStartProducts,
            this.toolStopProducts,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStartOffers,
            this.toolStopOffers,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStartCommands,
            this.toolStopCommands});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(908, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel1.Text = "Web service produits";
            // 
            // toolStartProducts
            // 
            this.toolStartProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStartProducts.Image = ((System.Drawing.Image)(resources.GetObject("toolStartProducts.Image")));
            this.toolStartProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStartProducts.Name = "toolStartProducts";
            this.toolStartProducts.Size = new System.Drawing.Size(23, 22);
            this.toolStartProducts.Text = "toolStripButton1";
            this.toolStartProducts.ToolTipText = "Démarrez le web service d\'envoi du catalogue";
            this.toolStartProducts.Click += new System.EventHandler(this.toolStartProducts_Click);
            // 
            // toolStopProducts
            // 
            this.toolStopProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStopProducts.Enabled = false;
            this.toolStopProducts.Image = ((System.Drawing.Image)(resources.GetObject("toolStopProducts.Image")));
            this.toolStopProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStopProducts.Name = "toolStopProducts";
            this.toolStopProducts.Size = new System.Drawing.Size(23, 22);
            this.toolStopProducts.Text = "Arrêtez l\'envoi du catalogue";
            this.toolStopProducts.ToolTipText = "Arrêtez de l\'envoi du catalogue";
            this.toolStopProducts.Click += new System.EventHandler(this.toolStopProducts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(103, 22);
            this.toolStripLabel2.Text = "Web service offres";
            // 
            // toolStartOffers
            // 
            this.toolStartOffers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStartOffers.Image = ((System.Drawing.Image)(resources.GetObject("toolStartOffers.Image")));
            this.toolStartOffers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStartOffers.Name = "toolStartOffers";
            this.toolStartOffers.Size = new System.Drawing.Size(23, 22);
            this.toolStartOffers.Text = "Démarrez de l\'envoi des offres";
            this.toolStartOffers.Click += new System.EventHandler(this.toolStartOffers_Click);
            // 
            // toolStopOffers
            // 
            this.toolStopOffers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStopOffers.Enabled = false;
            this.toolStopOffers.Image = ((System.Drawing.Image)(resources.GetObject("toolStopOffers.Image")));
            this.toolStopOffers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStopOffers.Name = "toolStopOffers";
            this.toolStopOffers.Size = new System.Drawing.Size(23, 22);
            this.toolStopOffers.Text = "Arrêtez l\'envoi des offres";
            this.toolStopOffers.Click += new System.EventHandler(this.toolStopOffers_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel3.Text = "Web service commandes";
            // 
            // toolStartCommands
            // 
            this.toolStartCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStartCommands.Image = ((System.Drawing.Image)(resources.GetObject("toolStartCommands.Image")));
            this.toolStartCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStartCommands.Name = "toolStartCommands";
            this.toolStartCommands.Size = new System.Drawing.Size(23, 22);
            this.toolStartCommands.Text = "Démarrez la réception des commandes";
            this.toolStartCommands.Click += new System.EventHandler(this.toolStartCommands_Click);
            // 
            // toolStopCommands
            // 
            this.toolStopCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStopCommands.Enabled = false;
            this.toolStopCommands.Image = ((System.Drawing.Image)(resources.GetObject("toolStopCommands.Image")));
            this.toolStopCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStopCommands.Name = "toolStopCommands";
            this.toolStopCommands.Size = new System.Drawing.Size(23, 22);
            this.toolStopCommands.Text = "Arrêtez la réception des commandes";
            this.toolStopCommands.Click += new System.EventHandler(this.toolStopCommandes_Click);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 344);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabInterface);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainInterface";
            this.Text = "Interface Emova La Redoute";
            this.tabInterface.ResumeLayout(false);
            this.tabProduits.ResumeLayout(false);
            this.tabOffres.ResumeLayout(false);
            this.tabCommandes.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabInterface;
        private System.Windows.Forms.TabPage tabProduits;
        private System.Windows.Forms.TabPage tabOffres;
        private System.Windows.Forms.TabPage tabCommandes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStartProducts;
        private System.Windows.Forms.ToolStripButton toolStopProducts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStartOffers;
        private System.Windows.Forms.ToolStripButton toolStopOffers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStartCommands;
        private System.Windows.Forms.ToolStripButton toolStopCommands;
        private System.Windows.Forms.RichTextBox richConsoleProducts;
        private System.Windows.Forms.RichTextBox richConsoleOffers;
        private System.Windows.Forms.RichTextBox richConsoleCommands;
    }
}


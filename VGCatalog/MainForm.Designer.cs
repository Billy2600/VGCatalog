namespace VGCatalog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveGame = new System.Windows.Forms.Button();
            this.btnAddConsole = new System.Windows.Forms.Button();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.btnRmoveConsole = new System.Windows.Forms.Button();
            this.gridMain = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBoxed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.addConsoleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Image = global::VGCatalog.Properties.Resources.book__plus;
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addGameToolStripMenuItem.Text = "Add Game";
            // 
            // addConsoleToolStripMenuItem
            // 
            this.addConsoleToolStripMenuItem.Name = "addConsoleToolStripMenuItem";
            this.addConsoleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addConsoleToolStripMenuItem.Text = "Add Console";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnRemoveGame
            // 
            this.btnRemoveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveGame.Image = global::VGCatalog.Properties.Resources.book__minus;
            this.btnRemoveGame.Location = new System.Drawing.Point(86, 27);
            this.btnRemoveGame.Name = "btnRemoveGame";
            this.btnRemoveGame.Size = new System.Drawing.Size(32, 23);
            this.btnRemoveGame.TabIndex = 4;
            this.btnRemoveGame.UseVisualStyleBackColor = true;
            this.btnRemoveGame.Click += new System.EventHandler(this.btnRemoveGame_Click);
            // 
            // btnAddConsole
            // 
            this.btnAddConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddConsole.Image = global::VGCatalog.Properties.Resources.book__plus;
            this.btnAddConsole.Location = new System.Drawing.Point(48, 27);
            this.btnAddConsole.Name = "btnAddConsole";
            this.btnAddConsole.Size = new System.Drawing.Size(32, 23);
            this.btnAddConsole.TabIndex = 3;
            this.btnAddConsole.UseVisualStyleBackColor = true;
            // 
            // btnAddGame
            // 
            this.btnAddGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGame.Image = global::VGCatalog.Properties.Resources.book__plus;
            this.btnAddGame.Location = new System.Drawing.Point(12, 27);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(30, 23);
            this.btnAddGame.TabIndex = 2;
            this.btnAddGame.UseVisualStyleBackColor = true;
            // 
            // btnRmoveConsole
            // 
            this.btnRmoveConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRmoveConsole.Image = global::VGCatalog.Properties.Resources.book__minus;
            this.btnRmoveConsole.Location = new System.Drawing.Point(124, 27);
            this.btnRmoveConsole.Name = "btnRmoveConsole";
            this.btnRmoveConsole.Size = new System.Drawing.Size(32, 23);
            this.btnRmoveConsole.TabIndex = 5;
            this.btnRmoveConsole.UseVisualStyleBackColor = true;
            // 
            // gridMain
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPublisher,
            this.colGenre,
            this.colConsole,
            this.colBoxed,
            this.colContainer});
            this.gridMain.Location = new System.Drawing.Point(12, 56);
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(760, 493);
            this.gridMain.TabIndex = 6;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 150;
            // 
            // colPublisher
            // 
            this.colPublisher.HeaderText = "Publisher";
            this.colPublisher.Name = "colPublisher";
            this.colPublisher.Width = 150;
            // 
            // colGenre
            // 
            this.colGenre.HeaderText = "Genre";
            this.colGenre.Name = "colGenre";
            this.colGenre.Width = 150;
            // 
            // colConsole
            // 
            this.colConsole.HeaderText = "Console";
            this.colConsole.Name = "colConsole";
            this.colConsole.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colConsole.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colConsole.Width = 130;
            // 
            // colBoxed
            // 
            this.colBoxed.HeaderText = "In Box";
            this.colBoxed.Name = "colBoxed";
            this.colBoxed.Width = 45;
            // 
            // colContainer
            // 
            this.colContainer.HeaderText = "Container #";
            this.colContainer.Name = "colContainer";
            this.colContainer.Width = 80;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gridMain);
            this.Controls.Add(this.btnRmoveConsole);
            this.Controls.Add(this.btnRemoveGame);
            this.Controls.Add(this.btnAddConsole);
            this.Controls.Add(this.btnAddGame);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "VGCatalog";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addConsoleToolStripMenuItem;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.Button btnAddConsole;
        private System.Windows.Forms.Button btnRemoveGame;
        private System.Windows.Forms.Button btnRmoveConsole;
        private System.Windows.Forms.DataGridView gridMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConsole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBoxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContainer;
    }
}


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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMain = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBoxed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpGames = new System.Windows.Forms.TabPage();
            this.tpConsoles = new System.Windows.Forms.TabPage();
            this.gridConsoles = new System.Windows.Forms.DataGridView();
            this.colConsoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsoleContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSwitchbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSwitchboxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpContainers = new System.Windows.Forms.TabPage();
            this.tpSwitchboxes = new System.Windows.Forms.TabPage();
            this.ttipMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gridContainers = new System.Windows.Forms.DataGridView();
            this.colContainerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSwitchboxes = new System.Windows.Forms.DataGridView();
            this.colSwitchboxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumSwitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpGames.SuspendLayout();
            this.tpConsoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsoles)).BeginInit();
            this.tpContainers.SuspendLayout();
            this.tpSwitchboxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSwitchboxes)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(795, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Image = global::VGCatalog.Properties.Resources.disk;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(138, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::VGCatalog.Properties.Resources.arrow_circle_double_135;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.exportCurrentToolStripMenuItem});
            this.excelToolStripMenuItem.Image = global::VGCatalog.Properties.Resources.document_excel;
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            // 
            // exportCurrentToolStripMenuItem
            // 
            this.exportCurrentToolStripMenuItem.Name = "exportCurrentToolStripMenuItem";
            this.exportCurrentToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportCurrentToolStripMenuItem.Text = "Export Current";
            this.exportCurrentToolStripMenuItem.Click += new System.EventHandler(this.exportCurrentToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // gridMain
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPublisher,
            this.colGenre,
            this.colConsole,
            this.colBoxed,
            this.colContainer,
            this.colGID});
            this.gridMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridMain.Location = new System.Drawing.Point(6, 6);
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(778, 444);
            this.gridMain.TabIndex = 6;
            this.gridMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellValueChanged);
            this.gridMain.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridMain_UserDeletingRow);
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
            // colGID
            // 
            this.colGID.HeaderText = "GID";
            this.colGID.Name = "colGID";
            this.colGID.Visible = false;
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tpGames);
            this.tabMain.Controls.Add(this.tpConsoles);
            this.tabMain.Controls.Add(this.tpContainers);
            this.tabMain.Controls.Add(this.tpSwitchboxes);
            this.tabMain.Location = new System.Drawing.Point(0, 56);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(795, 613);
            this.tabMain.TabIndex = 7;
            // 
            // tpGames
            // 
            this.tpGames.Controls.Add(this.gridMain);
            this.tpGames.Location = new System.Drawing.Point(4, 22);
            this.tpGames.Name = "tpGames";
            this.tpGames.Padding = new System.Windows.Forms.Padding(3);
            this.tpGames.Size = new System.Drawing.Size(787, 587);
            this.tpGames.TabIndex = 0;
            this.tpGames.Text = "Games";
            this.tpGames.UseVisualStyleBackColor = true;
            // 
            // tpConsoles
            // 
            this.tpConsoles.Controls.Add(this.gridConsoles);
            this.tpConsoles.Location = new System.Drawing.Point(4, 22);
            this.tpConsoles.Name = "tpConsoles";
            this.tpConsoles.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsoles.Size = new System.Drawing.Size(787, 587);
            this.tpConsoles.TabIndex = 1;
            this.tpConsoles.Text = "Consoles";
            this.tpConsoles.UseVisualStyleBackColor = true;
            // 
            // gridConsoles
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridConsoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridConsoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridConsoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConsoleName,
            this.colManufacturer,
            this.colConsoleContainer,
            this.colSwitchbox,
            this.colSwitchboxNo,
            this.colCID});
            this.gridConsoles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridConsoles.Location = new System.Drawing.Point(6, 6);
            this.gridConsoles.Name = "gridConsoles";
            this.gridConsoles.Size = new System.Drawing.Size(778, 444);
            this.gridConsoles.TabIndex = 7;
            this.gridConsoles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConsoles_CellValueChanged);
            this.gridConsoles.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridConsoles_UserDeletingRow);
            // 
            // colConsoleName
            // 
            this.colConsoleName.HeaderText = "Name";
            this.colConsoleName.Name = "colConsoleName";
            this.colConsoleName.Width = 150;
            // 
            // colManufacturer
            // 
            this.colManufacturer.HeaderText = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.Width = 150;
            // 
            // colConsoleContainer
            // 
            this.colConsoleContainer.HeaderText = "Container #";
            this.colConsoleContainer.Name = "colConsoleContainer";
            this.colConsoleContainer.Width = 80;
            // 
            // colSwitchbox
            // 
            this.colSwitchbox.HeaderText = "Switchbox";
            this.colSwitchbox.Name = "colSwitchbox";
            // 
            // colSwitchboxNo
            // 
            this.colSwitchboxNo.HeaderText = "# On Switchbox";
            this.colSwitchboxNo.Name = "colSwitchboxNo";
            // 
            // colCID
            // 
            this.colCID.HeaderText = "CID";
            this.colCID.Name = "colCID";
            this.colCID.Visible = false;
            // 
            // tpContainers
            // 
            this.tpContainers.Controls.Add(this.gridContainers);
            this.tpContainers.Location = new System.Drawing.Point(4, 22);
            this.tpContainers.Name = "tpContainers";
            this.tpContainers.Size = new System.Drawing.Size(787, 587);
            this.tpContainers.TabIndex = 2;
            this.tpContainers.Text = "Containers";
            this.tpContainers.UseVisualStyleBackColor = true;
            // 
            // tpSwitchboxes
            // 
            this.tpSwitchboxes.Controls.Add(this.gridSwitchboxes);
            this.tpSwitchboxes.Location = new System.Drawing.Point(4, 22);
            this.tpSwitchboxes.Name = "tpSwitchboxes";
            this.tpSwitchboxes.Size = new System.Drawing.Size(787, 587);
            this.tpSwitchboxes.TabIndex = 3;
            this.tpSwitchboxes.Text = "Switchboxes";
            this.tpSwitchboxes.UseVisualStyleBackColor = true;
            // 
            // btnDelRow
            // 
            this.btnDelRow.Image = global::VGCatalog.Properties.Resources.cross;
            this.btnDelRow.Location = new System.Drawing.Point(78, 27);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(32, 23);
            this.btnDelRow.TabIndex = 4;
            this.ttipMain.SetToolTip(this.btnDelRow, "Delete");
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnRemoveGame_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::VGCatalog.Properties.Resources.arrow_circle_double_135;
            this.btnRefresh.Location = new System.Drawing.Point(40, 27);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 23);
            this.btnRefresh.TabIndex = 3;
            this.ttipMain.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::VGCatalog.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(4, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 23);
            this.btnSave.TabIndex = 2;
            this.ttipMain.SetToolTip(this.btnSave, "Save");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridContainers
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridContainers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContainerName,
            this.colConID});
            this.gridContainers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridContainers.Location = new System.Drawing.Point(6, 6);
            this.gridContainers.Name = "gridContainers";
            this.gridContainers.Size = new System.Drawing.Size(778, 444);
            this.gridContainers.TabIndex = 8;
            // 
            // colContainerName
            // 
            this.colContainerName.HeaderText = "Name";
            this.colContainerName.Name = "colContainerName";
            this.colContainerName.Width = 150;
            // 
            // colConID
            // 
            this.colConID.HeaderText = "con_id";
            this.colConID.Name = "colConID";
            this.colConID.Visible = false;
            // 
            // gridSwitchboxes
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gridSwitchboxes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridSwitchboxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSwitchboxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSwitchboxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSwitchboxName,
            this.colNumSwitches,
            this.colSID});
            this.gridSwitchboxes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridSwitchboxes.Location = new System.Drawing.Point(6, 6);
            this.gridSwitchboxes.Name = "gridSwitchboxes";
            this.gridSwitchboxes.Size = new System.Drawing.Size(778, 444);
            this.gridSwitchboxes.TabIndex = 9;
            // 
            // colSwitchboxName
            // 
            this.colSwitchboxName.HeaderText = "Name";
            this.colSwitchboxName.Name = "colSwitchboxName";
            this.colSwitchboxName.Width = 150;
            // 
            // colNumSwitches
            // 
            this.colNumSwitches.HeaderText = "# of Switches";
            this.colNumSwitches.Name = "colNumSwitches";
            // 
            // colSID
            // 
            this.colSID.HeaderText = "sid";
            this.colSID.Name = "colSID";
            this.colSID.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 557);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnDelRow);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "VGCatalog";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpGames.ResumeLayout(false);
            this.tpConsoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConsoles)).EndInit();
            this.tpContainers.ResumeLayout(false);
            this.tpSwitchboxes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSwitchboxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.DataGridView gridMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConsole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBoxed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGID;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpGames;
        private System.Windows.Forms.TabPage tpConsoles;
        private System.Windows.Forms.DataGridView gridConsoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsoleContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSwitchbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSwitchboxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCID;
        private System.Windows.Forms.ToolTip ttipMain;
        private System.Windows.Forms.TabPage tpContainers;
        private System.Windows.Forms.TabPage tpSwitchboxes;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.DataGridView gridContainers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContainerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConID;
        private System.Windows.Forms.DataGridView gridSwitchboxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSwitchboxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumSwitches;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSID;
    }
}


/* 
    VGCatalog by William McPherson
    This program is licensed under the GPLv2, please see the included LICENSE textfile
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VGCatalog
{
    public partial class MainForm : Form
    {
        // Database handler object
        private DBHandler db = new DBHandler();
        // Form title
        // So we can add an asterisk when unsaved
        const string formTitle = "VGCatalog";

        // Keep track of indexes of rows that have been changed
        // Hash set used to avoid duplicates
        private HashSet<int> mainChangedRows = new HashSet<int>();
        private HashSet<int> consolesChangedRows = new HashSet<int>();
        // Flag to ignore changes to datagridviews
        // so we can add data programatically without storing changed rows
        bool ignoreChange = false;

        public MainForm()
        {
            InitializeComponent();
        }

        // Show about screen
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string help =
                "VGCatalog by William McPherson 2015\n" +
                "This program is licensed under the GNU General Public License v2, please read the included LICENSE text file\n" +
                "Fugue Icons (C) 2013 Yusuke Kamiyamane. All rights reserved.";
            MessageBox.Show(this,help,"About",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }
        // Show Help
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fuck you!");
        }

        // On form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
        }

        // Build game list for main data grid
        private void BuildGameList(List<DBHandler.GameInfo> gameList)
        {
            // Put console names into datagridview combobox
            (this.gridMain.Columns[3] as DataGridViewComboBoxColumn).DataSource = db.GetConsoleNames();

            // Populate DataGridView
            // This is not the standard way to do it, but I'm rolling my own for future possibility of non MSSQL DBs
            foreach (var g in gameList)
            {
                // Turn boxed into string
                this.gridMain.Rows.Add(g.name, g.publisher, g.genre, g.consoleName, g.boxed, g.containerId,g.gid);
            }
            //this.gridMain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Build console list
        private void BuildConsoleList(List<DBHandler.ConsoleInfo> consoleList)
        {
            foreach(var c in consoleList)
            {
                this.gridConsoles.Rows.Add(c.name, c.manufacturer, c.containerId, c.switchBoxId, c.switchBoxNo, c.cid);
            }
        }

        // Refresh lists
        private void RefreshLists()
        {
            ignoreChange = true;
            // Games
            gridMain.Rows.Clear();
            gridMain.Refresh();
            BuildGameList(db.GetAllGames());
            // Consoles
            gridConsoles.Rows.Clear();
            gridConsoles.Refresh();
            BuildConsoleList(db.GetAllConsoles());

            ignoreChange = false;
        }

        // Delete selected game(s)
        private void btnRemoveGame_Click(object sender, EventArgs e)
        {
            // Games tab is selected
            if(tabMain.SelectedTab.Name == "tpGames")
            {
                // Get confirmation from user
                DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected game(s)?", "Are you sure?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete out of database if applicable
                    foreach (DataGridViewRow row in gridMain.SelectedRows)
                    {
                        if (row.Cells["colGID"].Value != null)
                        {
                            db.DeleteGame(Convert.ToInt32(row.Cells["colGID"].Value));
                        }
                    }
                    RefreshLists();
                }
            }

            // Consoles tab is selected
            else if(tabMain.SelectedTab.Name == "tpConsoles")
            {
                // Get confirmation from user
                DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected consoles(s)?", "Are you sure?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete out of database if applicable
                    foreach (DataGridViewRow row in gridConsoles.SelectedRows)
                    {
                        if (row.Cells["colGID"].Value != null)
                        {
                            db.DeleteConsole(Convert.ToInt32(row.Cells["colCID"].Value));
                        }
                    }
                    RefreshLists();
                }
            }
            
        }

        // Check for empty row
        private bool CheckEmptyRow(DataGridViewRow row)
        {
            bool rowIsEmpty = true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null)
                {
                    rowIsEmpty = false;
                    break;
                }
            }
            return rowIsEmpty;
        }

        // Save changes in grid view back to database
        private void btnSave_Click(object sender, EventArgs e)
        {
            int test; // Used to test for numerical values

            // Games tab is selected
            if (tabMain.SelectedTab.Name == "tpGames")
            {
                foreach (DataGridViewRow row in gridMain.Rows)
                {
                    // Skip this row if it's entirely empty
                    if (CheckEmptyRow(row)) continue;

                    // Insert row into database if new row
                    // GID will not be set if row was added by user
                    if (row.Cells["colGID"].Value == null || mainChangedRows.Contains(row.Cells["colGID"].RowIndex))
                    {
                        // Get data from cells, while checking for valid input
                        DBHandler.GameInfo newGame = new DBHandler.GameInfo();
                        if (row.Cells["colConsole"].Value != null)
                            newGame.name = row.Cells["colName"].Value.ToString();
                        else
                            newGame.name = "[UNTITLED]";

                        if (row.Cells["colPublisher"].Value != null)
                            newGame.publisher = row.Cells["colPublisher"].Value.ToString();
                        else
                            newGame.publisher = "";

                        if (row.Cells["colGenre"].Value != null)
                            newGame.genre = row.Cells["colGenre"].Value.ToString();
                        else
                            newGame.genre = "";

                        if (row.Cells["colConsole"].Value != null)
                            newGame.consoleId = db.GetConsoleID(row.Cells["colConsole"].Value.ToString());
                        else
                            newGame.consoleId = 1;

                        if (row.Cells["colBoxed"].Value != null)
                            newGame.boxed = Convert.ToBoolean(row.Cells["colBoxed"].Value);
                        else
                            newGame.boxed = false;

                        if (row.Cells["colContainer"].Value != null)
                            newGame.containerId = Convert.ToInt32(row.Cells["colContainer"].Value);
                        else
                            newGame.containerId = 0;

                        // Insert it
                        if (row.Cells["colGID"].Value == null)
                            db.InsertGame(newGame);
                        // Update it
                        else
                        {
                            // Make sure GID is valid
                            if (row.Cells["colGID"].Value != null && Int32.TryParse(row.Cells["colGID"].Value.ToString(), out test))
                            {
                                newGame.gid = Convert.ToInt32(row.Cells["colGID"].Value);
                                db.UpdateGame(newGame);
                            }
                        }
                    }
                }
            }

            // Consoles tab is selected
            // Performs similarly to the above, so comments are lax
            else if (tabMain.SelectedTab.Name == "tpConsoles")
            {
                foreach (DataGridViewRow row in gridConsoles.Rows)
                {
                    if (CheckEmptyRow(row)) continue;

                    if (row.Cells["colCID"].Value == null || consolesChangedRows.Contains(row.Cells["colGID"].RowIndex))
                    {
                        DBHandler.ConsoleInfo newConsole = new DBHandler.ConsoleInfo();
                        if (row.Cells["colConsoleName"].Value != null)
                            newConsole.name = row.Cells["colConsoleName"].Value.ToString();
                        else
                            newConsole.name = "[UNTITLED]";
                        if (row.Cells["colManufacturer"].Value != null)
                            newConsole.manufacturer = row.Cells["colManufacturer"].Value.ToString();
                        else
                            newConsole.manufacturer = "";
                        if (row.Cells["colConsoleContainer"].Value != null && Int32.TryParse(row.Cells["colConsoleContainer"].Value.ToString(), out test))
                            newConsole.containerId = Convert.ToInt32(row.Cells["colConsoleContainer"].Value);
                        else
                            newConsole.containerId = 0;
                        if (row.Cells["colSwitchbox"].Value != null && Int32.TryParse(row.Cells["colConsoleContainer"].Value.ToString(), out test))
                            newConsole.switchBoxId = Convert.ToInt32(row.Cells["colSwitchbox"].Value);
                        else
                            newConsole.switchBoxId = 0;
                        if (row.Cells["colSwitchboxNo"].Value != null && Int32.TryParse(row.Cells["colConsoleContainer"].Value.ToString(), out test))
                            newConsole.switchBoxNo = Convert.ToInt32(row.Cells["colSwitchboxNo"].Value);
                        else
                            newConsole.switchBoxNo = 0;
                        if (row.Cells["colCID"].Value == null)
                            db.InsertConsole(newConsole);
                        else
                        {
                            if (row.Cells["colCID"].Value != null && Int32.TryParse(row.Cells["colCID"].Value.ToString(), out test))
                            {
                                newConsole.cid = Convert.ToInt32(row.Cells["colCID"].Value);
                                db.UpdateConsole(newConsole);
                            } 
                        }
                            
                    }
                }
            }

            RefreshLists();
        }

        // Refresh game list
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        // Delete row
        private void gridMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Prompt user
            string name = "[UNTITLED]";
            if (e.Row.Cells["colName"].Value != null) name = e.Row.Cells["colName"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete "+ name +"?", "Are you sure?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // Delete out of database if applicable
                if(e.Row.Cells["colGID"].Value != null)
                {
                    db.DeleteGame(Convert.ToInt32(e.Row.Cells["colGID"].Value));
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        // File menu save
        private void tsmSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        // File menu refresh
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void gridConsoles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Prompt user
            string name = "[UNTITLED]";
            if (e.Row.Cells["colConsoleName"].Value != null) name = e.Row.Cells["colConsoleName"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete " + name + "?", "Are you sure?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (e.Row.Cells["colCID"].Value != null)
                {
                    db.DeleteConsole(Convert.ToInt32(e.Row.Cells["colCID"].Value));
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        // Add row that has had cell changed
        private void gridMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(!ignoreChange && e.RowIndex != -1)
                mainChangedRows.Add(e.RowIndex);
        }

        private void gridConsoles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!ignoreChange && e.RowIndex != -1)
                consolesChangedRows.Add(e.RowIndex);
        }
    }
}

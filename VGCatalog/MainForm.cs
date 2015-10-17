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
using System.IO;

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
        private HashSet<int> containersChangedRows = new HashSet<int>();
        private HashSet<int> switchboxesChangedRows = new HashSet<int>();
        // Flag to ignore changes to datagridviews
        // so we can add data programatically without storing changed rows
        bool ignoreChange = false;

        private Random rnd = new Random();

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
            (this.gridMain.Columns["colConsole"] as DataGridViewComboBoxColumn).DataSource = db.GetConsoleNames();
            // Do the same for container names
            (this.gridMain.Columns["colContainer"] as DataGridViewComboBoxColumn).DataSource = db.GetContainerNames();

            // Populate DataGridView
            // This is not the standard way to do it, but I'm rolling my own for future possibility of non MSSQL DBs
            foreach (var g in gameList)
            {
                // Turn boxed into string
                this.gridMain.Rows.Add(g.name, g.publisher, g.genre, g.consoleName, g.boxed, g.containerName,g.gid);
            }
            //this.gridMain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Build console list
        private void BuildConsoleList(List<DBHandler.ConsoleInfo> consoleList)
        {
            (this.gridConsoles.Columns["colSwitchbox"] as DataGridViewComboBoxColumn).DataSource = db.GetSwitchboxNames();

            for (int i = 0; i < consoleList.Count; i++)
            {
                DBHandler.ConsoleInfo c = consoleList[i];
                this.gridConsoles.Rows.Add(c.name, c.manufacturer, c.containerId, c.switchBoxName, c.switchBoxNo.ToString(), c.cid);
            }
        }

        // Build container list
        private void BuildContainerList(List<DBHandler.ContainerInfo> containerList)
        {
            foreach(var c in containerList)
            {
                this.gridContainers.Rows.Add(c.name, c.con_id);
            }
        }

        // Build switchbox list
        private void BuildSwitchboxList(List<DBHandler.SwitchboxInfo> switchboxList)
        {
            foreach (var s in switchboxList)
            {
                this.gridSwitchboxes.Rows.Add(s.name, s.numSwitches.ToString(), s.sid);
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
            // Containers
            gridContainers.Rows.Clear();
            gridContainers.Refresh();
            BuildContainerList(db.GetAllContainers());
            // Switchboxes
            gridSwitchboxes.Rows.Clear();
            gridSwitchboxes.Refresh();
            BuildSwitchboxList(db.GetAllSwitchboxes());

            ignoreChange = false;
        }

        // Delete selected game(s)
        private void btnRemoveGame_Click(object sender, EventArgs e)
        {
            // Games tab is selected
            if(tabMain.SelectedTab.Name == "tpGames")
            {
                // Make sure we have rows selected
                if (gridMain.SelectedRows.Count < 1)
                {
                    MessageBox.Show("No rows selected", "Error");
                    return;
                }
                    
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
                // Make sure we have rows selected
                if (gridConsoles.SelectedRows.Count < 1)
                {
                    MessageBox.Show("No rows selected", "Error");
                    return;
                }

                // Get confirmation from user
                DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected console(s)?", "Are you sure?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete out of database if applicable
                    foreach (DataGridViewRow row in gridConsoles.SelectedRows)
                    {
                        if (row.Cells["colCID"].Value != null)
                        {
                            db.DeleteConsole(Convert.ToInt32(row.Cells["colCID"].Value));
                        }
                    }
                    RefreshLists();
                }
            }

            // Containers tab is selected
            else if (tabMain.SelectedTab.Name == "tpContainers")
            {
                // Make sure we have rows selected
                if (gridContainers.SelectedRows.Count < 1)
                {
                    MessageBox.Show("No rows selected", "Error");
                    return;
                }

                // Get confirmation from user
                DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected container(s)?", "Are you sure?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete out of database if applicable
                    foreach (DataGridViewRow row in gridContainers.SelectedRows)
                    {
                        if (row.Cells["colConID"].Value != null)
                        {
                            db.DeleteContainer(Convert.ToInt32(row.Cells["colConID"].Value));
                        }
                    }
                    RefreshLists();
                }
            }

            // Switchbox tab is selected
            else if (tabMain.SelectedTab.Name == "tpSwitchboxes")
            {
                // Make sure we have rows selected
                if (gridSwitchboxes.SelectedRows.Count < 1)
                {
                    MessageBox.Show("No rows selected", "Error");
                    return;
                }

                // Get confirmation from user
                DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected switchbox(es)?", "Are you sure?", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    // Delete out of database if applicable
                    foreach (DataGridViewRow row in gridSwitchboxes.SelectedRows)
                    {
                        if (row.Cells["colSID"].Value != null)
                        {
                            db.DeleteSwitchbox(Convert.ToInt32(row.Cells["colSID"].Value));
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
                            newGame.containerId = db.GetContainerID(row.Cells["colContainer"].Value.ToString());
                        else
                            newGame.containerId = 1;

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

                    if (row.Cells["colCID"].Value == null || consolesChangedRows.Contains(row.Cells["colCID"].RowIndex))
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
                        if (row.Cells["colSwitchbox"].Value != null)
                            newConsole.switchBoxId = db.GetSwitchboxID(row.Cells["colSwitchbox"].Value.ToString());
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

            // Containers tab is selected
            else if (tabMain.SelectedTab.Name == "tpContainers")
            {
                foreach (DataGridViewRow row in gridContainers.Rows)
                {
                    if (CheckEmptyRow(row)) continue;

                    if (row.Cells["colConID"].Value == null || containersChangedRows.Contains(row.Cells["colConID"].RowIndex))
                    {
                        DBHandler.ContainerInfo newContainer = new DBHandler.ContainerInfo();
                        if (row.Cells["colContainerName"].Value != null)
                            newContainer.name = row.Cells["colContainerName"].Value.ToString();
                        else
                            newContainer.name = "[UNTITLED]";

                        if (row.Cells["colConID"].Value == null)
                            db.InsertContainer(newContainer);
                        else
                        {
                            if (row.Cells["colConID"].Value != null && Int32.TryParse(row.Cells["colConID"].Value.ToString(), out test))
                            {
                                newContainer.con_id = Convert.ToInt32(row.Cells["colConID"].Value);
                                db.UpdateContainer(newContainer);
                            }
                        }

                    }
                }
            }

            // Switchbox tab is selected
            else if (tabMain.SelectedTab.Name == "tpSwitchboxes")
            {
                foreach (DataGridViewRow row in gridSwitchboxes.Rows)
                {
                    if (CheckEmptyRow(row)) continue;

                    if (row.Cells["colSID"].Value == null || switchboxesChangedRows.Contains(row.Cells["colSID"].RowIndex))
                    {
                        DBHandler.SwitchboxInfo newSwitchbox = new DBHandler.SwitchboxInfo();
                        if (row.Cells["colSwitchboxName"].Value != null)
                            newSwitchbox.name = row.Cells["colSwitchboxName"].Value.ToString();
                        else
                            newSwitchbox.name = "[UNTITLED]";
                        if (row.Cells["colNumSwitches"].Value != null && Int32.TryParse(row.Cells["colConsoleContainer"].Value.ToString(), out test))
                            newSwitchbox.numSwitches = Convert.ToInt32(row.Cells["colNumSwitches"].Value);
                        else
                            newSwitchbox.name = "[UNTITLED]";

                        if (row.Cells["colSID"].Value == null)
                            db.InsertSwitchbox(newSwitchbox);
                        else
                        {
                            if (row.Cells["colSID"].Value != null && Int32.TryParse(row.Cells["colSID"].Value.ToString(), out test))
                            {
                                newSwitchbox.sid = Convert.ToInt32(row.Cells["colSID"].Value);
                                db.UpdateSwitchbox(newSwitchbox);
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

        // Usere deletes rows manually (delete key)
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
        private void gridContainers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string name = "[UNTITLED]";
            if (e.Row.Cells["colContainerName"].Value != null) name = e.Row.Cells["colContainerName"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete " + name + "?", "Are you sure?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (e.Row.Cells["colConID"].Value != null)
                {
                    db.DeleteContainer(Convert.ToInt32(e.Row.Cells["colConID"].Value));
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gridSwitchboxes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string name = "[UNTITLED]";
            if (e.Row.Cells["colSwitchboxName"].Value != null) name = e.Row.Cells["colSwitchboxName"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete " + name + "?", "Are you sure?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (e.Row.Cells["colSID"].Value != null)
                {
                    db.DeleteSwitchbox(Convert.ToInt32(e.Row.Cells["colSID"].Value));
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
        private void gridContainers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!ignoreChange && e.RowIndex != -1)
                containersChangedRows.Add(e.RowIndex);
        }
        private void gridSwitchboxes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!ignoreChange && e.RowIndex != -1)
                switchboxesChangedRows.Add(e.RowIndex);
        }

        // Export current grid view
        private void exportCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt for file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                // Choose current grid view
                DataGridView current;
                if (tabMain.SelectedTab.Name == "Consoles")
                    current = gridConsoles;
                else
                    current = gridMain;

                string output = "";
                string headers = ""; // Export headers
                for (int i = 0; i < current.Columns.Count; i++)
                    headers = headers.ToString() + Convert.ToString(current.Columns[i].HeaderText) + "\t";
                output += headers + "\r\n";

                // Export data
                for(int i = 0; i < current.RowCount; i++)
                {
                    string line = "";
                    for(int j = 0; j < current.Rows[i].Cells.Count; j++)
                    {
                        line = line.ToString() + Convert.ToString(current.Rows[i].Cells[j].Value) + "\t";
                    }
                    output += line + "\r\n";
                }

                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] bOutput = utf16.GetBytes(output);
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bOutput, 0, bOutput.Length);
                bw.Flush();
                bw.Close();
                fs.Close();
                MessageBox.Show("File " + sfd.FileName + " created", "Success");
            }
        }

        // Data error
        private void gridConsoles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void gridSwitchboxes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridContainers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}

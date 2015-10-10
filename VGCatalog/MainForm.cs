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

        public MainForm()
        {
            InitializeComponent();
        }

        // Show help screen
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string help =
                "VGCatalog by William McPherson 2015\n" +
                "This program is licensed under the GNU General Public License v2, please read the included LICENSE text file\n" +
                "Fugue Icons (C) 2013 Yusuke Kamiyamane. All rights reserved.";
            MessageBox.Show(this,help,"About",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        // On form load
        private void MainForm_Load(object sender, EventArgs e)
        {
            BuildGameList(db.GetAllGames());
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

        // Delete selected game(s)
        private void btnRemoveGame_Click(object sender, EventArgs e)
        {
            // Get confirmation from user
            DialogResult confirm = MessageBox.Show("Are you sure you wish to permanently delete the selected game(s)?", "Are you sure?", MessageBoxButtons.YesNo);
            if(confirm == DialogResult.Yes)
            {
                
            }
        }

        // Save changes in grid view back to database
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in gridMain.Rows)
            {
                // Skip this row if it's entirely empty
                bool rowIsEmpty = true;
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if(cell.Value != null)
                    {
                        rowIsEmpty = false;
                        break;
                    }
                }
                if (rowIsEmpty) continue;

                // Insert row into database if new row
                // GID will not be set if row was added by user
                if(row.Cells["colGID"].Value == null)
                {
                    // Get data from cells, while checking for valid input
                    DBHandler.GameInfo newGame = new DBHandler.GameInfo();
                    if (row.Cells["colConsole"].Value != null)
                        newGame.name = row.Cells["colName"].Value.ToString();
                    else
                        newGame.name = "[UNTITLED]";

                    if(row.Cells["colPublisher"].Value != null)
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

                    if (row.Cells["colContainer"].Value != null)
                        newGame.boxed = row.Cells["colBoxed"].Value.ToString() == "1";
                    else
                        newGame.boxed = false;

                    if (row.Cells["colContainer"].Value != null)
                        newGame.containerId = Convert.ToInt32(row.Cells["colContainer"].Value);
                    else
                        newGame.containerId = 0;

                    // Insert it
                    db.InsertGame(newGame);
                    //MessageBox.Show(newGame.name + newGame.publisher + newGame.genre + newGame.consoleId + newGame.boxed + newGame.containerId);
                }
            }

            // Reload game list
            gridMain.Rows.Clear();
            gridMain.Refresh();
            BuildGameList(db.GetAllGames());
        }

        // Refresh game list
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gridMain.Rows.Clear();
            gridMain.Refresh();
            BuildGameList(db.GetAllGames());
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

    }
}

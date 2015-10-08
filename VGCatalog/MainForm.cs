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
                "This program is licensed under the GNU General Public Liscense, please read the included LICENSE text file";
            MessageBox.Show(this,help,"About");
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
                this.gridMain.Rows.Add(g.name, g.publisher, g.genre, g.consoleName, g.boxed, g.containerId);
            }
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
    }
}

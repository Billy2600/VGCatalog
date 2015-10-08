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
            int i = 0;

            foreach (var g in gameList)
            {
                // Create labels for this game
                //for(int j = 1; j < 7; j++) // Skip gid
                //{
                //    System.Windows.Forms.Label newLabel = new System.Windows.Forms.Label();
                //    newLabel.AutoSize = false;
                //    newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //    newLabel.Name = "lblName" + i + "," + j;
                //    newLabel.Size = new System.Drawing.Size(150, 13);
                //    newLabel.TabIndex = 0;
                //    // Choose name and location based on which field this is
                //    // The x location can vary wildly since columns aren't all the same size
                //    int xLoc = 0;
                //    switch (j)
                //    {
                //        case 1:
                //            newLabel.Text = g.name;
                //            xLoc = 20;
                //            break;
                //        case 2:
                //            newLabel.Text = g.publisher;
                //            xLoc = 176;
                //            break;
                //        default:
                //            newLabel.Text = "ERROR";
                //            xLoc = j * 150;
                //            break;
                //    }
                //    newLabel.Location = new System.Drawing.Point(xLoc, 28 + (18 * i));
                //    newLabel.AutoEllipsis = true;
                //    this.pnlGameList.Controls.Add(newLabel);
                //}
                
                //// Create checkbox
                //System.Windows.Forms.CheckBox newCBox = new System.Windows.Forms.CheckBox();
                //newCBox.AutoSize = true;
                //newCBox.Location = new System.Drawing.Point(3, 28 + (18 * i));
                //newCBox.Name = "chkGame" + i;
                //newCBox.Size = new System.Drawing.Size(15, 14);
                //newCBox.TabIndex = 3;
                //newCBox.UseVisualStyleBackColor = true;
                //this.pnlGameList.Controls.Add(newCBox);
                //i++;
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

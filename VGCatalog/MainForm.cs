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
            List<DBHandler.GameInfo> gameList = db.GetAllGames();

            int i = 2;
            foreach(var g in gameList)
            {
                System.Windows.Forms.Label newLabel;
                newLabel = new System.Windows.Forms.Label();
                newLabel.AutoSize = false;
                newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(12, 20 * i);
                newLabel.Name = "test";
                newLabel.Size = new System.Drawing.Size(150, 13);
                newLabel.TabIndex = 0;
                newLabel.Text = g.name;
                newLabel.AutoEllipsis = true;
                this.pnlGameList.Controls.Add(newLabel);
                i++;
            }
        }
    }
}

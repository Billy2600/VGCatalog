/* 
    VGCatalog by William McPherson
    This program is licensed under the GPLv2, please see the included LICENSE textfile
    DBHandler - A class to handle and abstract database operations
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Data.SqlClient;

namespace VGCatalog
{
    class DBHandler
    {
        // Structs
        // Should closely match layout in the database

        // Game info struct
        public struct GameInfo
        {
            public int gid;
            public string name;
            public string publisher;
            public string genre;
            public int consoleId;
            public string consoleName;
            public bool boxed;
            public int containerId;
        }

        // Console info struct
        public struct ConsoleInfo
        {
            public int cid;
            public string name;
            public string manufacturer;
            public int containerId;
            public int switchBoxId;
            public int switchBoxNo;
        }

        // Container info struct
        public struct ContainerInfo
        {
            public int con_id;
            public string name;
        }

        // Switchbox info struct
        public struct SwitchboxInfo
        {
            public int sid;
            public string name;
            public int numSwitches;
        }

        // Enum for specifying mode
        public enum Modes { Games, Console, Container, Switchbox };

        // Connection string
        private const string connectString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VGCatalog;Integrated Security=SSPI";

        // Logged in flag
        private bool loggedIn = false;
        public bool LoggedIn { get { return loggedIn; } } // Accessible but not modifiable

        public DBHandler()
        {

        }

        /* ==========================
         * GAMES
         * ==========================*/

        // Get the data for all games
        public List<GameInfo> GetAllGames()
        {
            // Initialize list
            List<GameInfo> gameList = new List<GameInfo>();

            // Get all game info and store into list
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT Games.gid, Games.name, publisher, genre, console_id, boxed, Games.container_id, Consoles.name as CName FROM Games, Consoles WHERE Consoles.cid = Games.console_id ORDER BY Games.name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GameInfo g = new GameInfo();
                            g.gid = reader.GetInt32(reader.GetOrdinal("gid"));

                            g.name = reader.GetString(reader.GetOrdinal("name"));

                            // Make sure to check for nulls
                            int publisherIndex = reader.GetOrdinal("publisher");
                            if (!reader.IsDBNull(publisherIndex)) g.publisher = reader.GetString(publisherIndex);

                            int genreIndex = reader.GetOrdinal("genre");
                            if (!reader.IsDBNull(genreIndex)) g.genre = reader.GetString(genreIndex);

                            g.consoleId = reader.GetInt32(reader.GetOrdinal("console_id"));

                            // Must get console name to match the combo box
                            g.consoleName = reader.GetString(reader.GetOrdinal("CName"));

                            g.boxed = reader.GetBoolean(reader.GetOrdinal("boxed"));

                            int containerIndex = reader.GetOrdinal("container_id");
                            if (!reader.IsDBNull(containerIndex)) g.containerId = reader.GetInt32(containerIndex);
                            gameList.Add(g);
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }

            // Return list
            return gameList;
        }

        // Insert new game into database
        public void InsertGame(GameInfo newGame)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Games (name,publisher,genre,console_id,boxed,container_id) VALUES(@Name,@Publisher,@Genre,@ConsoleId,@Boxed,@ContainerId)", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Name", newGame.name);
                cmd.Parameters.AddWithValue("@Publisher", newGame.publisher);
                cmd.Parameters.AddWithValue("@Genre", newGame.genre);
                cmd.Parameters.AddWithValue("@ConsoleId", newGame.consoleId);
                cmd.Parameters.AddWithValue("@Boxed", newGame.boxed);
                cmd.Parameters.AddWithValue("@ContainerId", newGame.containerId);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        // Update game in database
        // GameInfo.gid must match the one you wish to update
        public void UpdateGame(GameInfo updateGame)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Games SET name = @Name,publisher = @Publisher,genre = @Genre,console_id = @ConsoleId,boxed = @boxed,container_id = @ContainerId WHERE gid = @Gid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Gid", updateGame.gid);
                cmd.Parameters.AddWithValue("@Name", updateGame.name);
                cmd.Parameters.AddWithValue("@Publisher", updateGame.publisher);
                cmd.Parameters.AddWithValue("@Genre", updateGame.genre);
                cmd.Parameters.AddWithValue("@ConsoleId", updateGame.consoleId);
                cmd.Parameters.AddWithValue("@Boxed", updateGame.boxed);
                cmd.Parameters.AddWithValue("@ContainerId", updateGame.containerId);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        // Delete game from database
        // User should have already been prompted
        public void DeleteGame(int gid)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Games WHERE gid = @Gid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Gid", gid);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        /* ==========================
         * CONSOLES
         * ==========================*/

        // Get the data for all consoles
        public List<ConsoleInfo> GetAllConsoles()
        {
            // Initialize list
            List<ConsoleInfo> consoleList = new List<ConsoleInfo>();

            // Get all game info and store into list
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT cid, name, manufacturer, container_id, switchbox_id, switchbox_no FROM Consoles ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ConsoleInfo c = new ConsoleInfo();
                            c.cid = reader.GetInt32(reader.GetOrdinal("cid"));

                            c.name = reader.GetString(reader.GetOrdinal("name"));

                            // Make sure to check for nulls
                            int manIndex = reader.GetOrdinal("manufacturer");
                            if (!reader.IsDBNull(manIndex)) c.manufacturer = reader.GetString(manIndex);

                            int containerIndex = reader.GetOrdinal("container_id");
                            if (!reader.IsDBNull(containerIndex)) c.containerId = reader.GetInt32(containerIndex);

                            // Switchbox stuff
                            int sbIDindex = reader.GetOrdinal("switchbox_id");
                            if (!reader.IsDBNull(sbIDindex)) c.switchBoxId = reader.GetInt32(sbIDindex);

                            int sbNoIndex = reader.GetOrdinal("switchbox_no");
                            if (!reader.IsDBNull(sbNoIndex)) c.switchBoxNo = reader.GetInt32(sbNoIndex);

                            consoleList.Add(c);
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }

            // Return list
            return consoleList;
        }

        // Get console names
        // Useful for populating combo box
        public List<string> GetConsoleNames()
        {
            List<string> consoleNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM Consoles ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            consoleNames.Add(reader.GetString(reader.GetOrdinal("name")));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return consoleNames;
        }

        // Get Console ID from name
        public int GetConsoleID(string name)
        {
            int consoleID = 0;

            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT cid FROM Consoles WHERE name = @Name", connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            consoleID = reader.GetInt32(reader.GetOrdinal("cid"));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return consoleID;
        }

        // Insert new console into database
        public void InsertConsole(ConsoleInfo newConsole)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Consoles (name,manufacturer,container_id,switchbox_id,switchbox_no) VALUES(@Name,@Manufacturer,@ContainerId,@SwitchboxId,@SwitchboxNo)", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Name", newConsole.name);
                cmd.Parameters.AddWithValue("@Manufacturer", newConsole.manufacturer);
                cmd.Parameters.AddWithValue("@ContainerId", newConsole.containerId);
                cmd.Parameters.AddWithValue("@SwitchboxId", newConsole.switchBoxId);
                cmd.Parameters.AddWithValue("@SwitchboxNo", newConsole.switchBoxNo);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        // Delete console from database
        public void DeleteConsole(int cid)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Consoles WHERE cid = @Cid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Cid", cid);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        // Update console in database
        public void UpdateConsole(ConsoleInfo updateConsole)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Consoles SET name = @Name,manufacturer = @Manufacturer,container_id = @ContainerId,switchbox_id = @SwitchboxId,switchbox_no = @SwitchboxNo WHERE cid = @Cid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Cid", updateConsole.cid);
                cmd.Parameters.AddWithValue("@Name", updateConsole.name);
                cmd.Parameters.AddWithValue("@Manufacturer", updateConsole.manufacturer);
                cmd.Parameters.AddWithValue("@ContainerId", updateConsole.containerId);
                cmd.Parameters.AddWithValue("@SwitchboxId", updateConsole.switchBoxId);
                cmd.Parameters.AddWithValue("@SwitchboxNo", updateConsole.switchBoxNo);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        /* ==========================
         * CONTAINERS
         * ==========================*/

        // Get call containers
        public List<ContainerInfo> GetAllContainers()
        {
            // Init list
            List<ContainerInfo> containerList = new List<ContainerInfo>();
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT con_id, name FROM Containers ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ContainerInfo c = new ContainerInfo();
                            c.con_id = reader.GetInt32(reader.GetOrdinal("con_id"));
                            c.name = reader.GetString(reader.GetOrdinal("name"));
                            containerList.Add(c);
                        }
                    }
                }
                connection.Close();
            }

            // return lsit
            return containerList;
        }

        /* ==========================
         * SWITCHBOXES
         * ==========================*/
        public List<SwitchboxInfo> GetAllSwitchboxes()
        {
            // Init list
            List<SwitchboxInfo> switchboxList = new List<SwitchboxInfo>();
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT sid, name, num_switches FROM Switchboxes ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SwitchboxInfo s = new SwitchboxInfo();
                            s.sid = reader.GetInt32(reader.GetOrdinal("sid"));
                            s.name = reader.GetString(reader.GetOrdinal("name"));
                            s.numSwitches = reader.GetInt32(reader.GetOrdinal("num_switches"));
                            switchboxList.Add(s);
                        }
                    }
                }
                connection.Close();
            }

            // return lsit
            return switchboxList;
        }
    }
}

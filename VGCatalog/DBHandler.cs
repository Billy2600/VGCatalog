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
            public string containerName;
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
            // Used for ComboBox cell
            public string switchBoxName;
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
        public List<GameInfo> GetAllGames(string searchQuery = "")
        {
            // Initialize list
            List<GameInfo> gameList = new List<GameInfo>();

            // sql query
            string query = "SELECT gid, Games.name, publisher, genre, console_id, boxed, Games.container_id, Consoles.name as CName, Containers.name as ConName FROM Games LEFT JOIN Consoles ON Games.console_id = Consoles.cid LEFT JOIN Containers on Games.container_id = Containers.con_id ";
            // Add onto it if search was entered
            if (searchQuery != "")
                query += "WHERE Games.name LIKE @Search OR publisher LIKE @Search OR genre LIKE @Search ";
            query += "ORDER BY Games.name asc";

            // Get all game info and store into list
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Search", "%" + searchQuery + "%");
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

                            // Must get console name to match the combo box
                            int cnameIndex = reader.GetOrdinal("CName");
                            if (!reader.IsDBNull(cnameIndex)) g.consoleName = reader.GetString(cnameIndex);

                            g.boxed = reader.GetBoolean(reader.GetOrdinal("boxed"));

                            // Must get container name much like console
                            int containerIndex = reader.GetOrdinal("ConName");
                            if (!reader.IsDBNull(containerIndex)) g.containerName = reader.GetString(containerIndex);

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
            using (SqlCommand cmd = new SqlCommand("SELECT cid, Consoles.name, manufacturer, container_id, switchbox_id, switchbox_no, Switchboxes.name as SName FROM Consoles LEFT JOIN Switchboxes ON Consoles.switchbox_id = Switchboxes.sid ORDER BY Consoles.name asc", connection))
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

                            int sbNameIndex = reader.GetOrdinal("SName");
                            if (!reader.IsDBNull(sbNameIndex)) c.switchBoxName = reader.GetString(sbNameIndex);

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

        // Get Container names
        public List<string> GetContainerNames()
        {
            List<string> containerNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM Containers ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            containerNames.Add(reader.GetString(reader.GetOrdinal("name")));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return containerNames;
        }

        // Get container ID from name
        public int GetContainerID(string name)
        {
            int containerID = 0;

            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT con_id FROM Containers WHERE name = @Name", connection))
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
                            containerID = reader.GetInt32(reader.GetOrdinal("con_id"));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return containerID;
        }

        public void DeleteContainer(int conID)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Containers WHERE con_id = @ConId", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@ConId", conID);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        public void InsertContainer(ContainerInfo newContainer)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Containers(name) VALUES(@Name)", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Name", newContainer.name);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        public void UpdateContainer(ContainerInfo updateContainer)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Containers SET name = @Name WHERE con_id = @ConID", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@ConID", updateContainer.con_id);
                cmd.Parameters.AddWithValue("@Name", updateContainer.name);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
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

        public List<string> GetSwitchboxNames()
        {
            List<string> switchboxNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM Switchboxes ORDER BY name asc", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if the reader has any rows at all before starting to read
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            switchboxNames.Add(reader.GetString(reader.GetOrdinal("name")));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return switchboxNames;
        }

        public int GetSwitchboxID(string name)
        {
            int switchboxID = 0;

            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("SELECT sid FROM Switchboxes WHERE name = @Name", connection))
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
                            switchboxID = reader.GetInt32(reader.GetOrdinal("sid"));
                        }
                    }
                }
                // Disconnect
                connection.Close();
            }
            return switchboxID;
        }

        public void DeleteSwitchbox(int sid)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Switchboxes WHERE sid = @Sid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Sid", sid);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        public void InsertSwitchbox(SwitchboxInfo newSwitchbox)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Switchboxes (name,num_switches) VALUES(@Name, @NumSwitches)", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Name", newSwitchbox.name);
                cmd.Parameters.AddWithValue("@NumSwitches", newSwitchbox.numSwitches);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }

        public void UpdateSwitchbox(SwitchboxInfo updateSwitchbox)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Switchboxes SET name = @Name, num_switches = @NumSwitches WHERE sid = @Sid", connection))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@Sid", updateSwitchbox.sid);
                cmd.Parameters.AddWithValue("@Name", updateSwitchbox.name);
                cmd.Parameters.AddWithValue("@NumSwitches", updateSwitchbox.numSwitches);
                // Open connection and insert
                connection.Open();
                cmd.ExecuteNonQuery();

                // Disconnect
                connection.Close();
            }
        }
    }
}

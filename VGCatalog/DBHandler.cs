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
using System.Windows.Forms;
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

        // Connection string
        private const string connectString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VGCatalog;Integrated Security=SSPI";

        // Logged in flag
        private bool loggedIn = false;
        public bool LoggedIn { get { return loggedIn; } } // Accessible but not modifiable

        public DBHandler()
        {

        }

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
    }
}

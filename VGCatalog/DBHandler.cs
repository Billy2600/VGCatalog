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
            public bool boxed;
            public int containerId;
        }

        // TEMPORARY
        private const string connectString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VGCatalog;Integrated Security=SSPI";

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
            using (SqlCommand cmd = new SqlCommand("SELECT gid, name, publisher, genre, console_id, boxed, container_id FROM dbo.Games ORDER BY name asc", connection))
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
    }
}

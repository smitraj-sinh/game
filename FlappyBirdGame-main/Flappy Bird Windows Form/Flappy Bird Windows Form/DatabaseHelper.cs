using System;
using System.Data.SqlClient;

namespace Flappy_Bird_Windows_Form
{
    internal class DatabaseHelper
    {
        private static string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlappyDB;Integrated Security=True";

        public static bool RegisterUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Players (Username, Password) VALUES (@u, @p)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                try { cmd.ExecuteNonQuery(); return true; }
                catch { return false; }
            }
        }

        public static bool LoginUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Players WHERE Username=@u AND Password=@p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static void SaveHighScore(string username, int score)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Players SET HighScore=@s WHERE Username=@u AND HighScore < @s";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s", score);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.ExecuteNonQuery();
            }
        }

        public static int GetHighScore(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HighScore FROM Players WHERE Username=@u";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}

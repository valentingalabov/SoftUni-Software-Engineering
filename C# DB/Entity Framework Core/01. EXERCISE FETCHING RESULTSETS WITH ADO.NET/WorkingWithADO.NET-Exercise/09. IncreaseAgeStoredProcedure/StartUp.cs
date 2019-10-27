using System;
using System.Data.SqlClient;

namespace _09._IncreaseAgeStoredProcedure
{
    class StartUp
    {

        private static string connectionString =
     "Server = VALIO\\SQLEXPRESS;" +
     "Database = MinionsDB;" +
     "Integrated Security = true";

        private static SqlConnection connection = new SqlConnection(connectionString);
        static void Main(string[] args)
        {

            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                var command = new SqlCommand("EXEC usp_GetOlder @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT * FROM Minions WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    reader.Read();

                    Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["Age"]} years old");
                }


            }



        }
    }
}

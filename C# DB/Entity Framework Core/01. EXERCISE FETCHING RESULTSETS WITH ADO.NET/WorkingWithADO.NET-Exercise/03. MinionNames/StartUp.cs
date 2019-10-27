using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _03._MinionNames
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
                connection.Open();

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    string villanName = (string)command.ExecuteScalar();

                    if (villanName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villanName}");

                }

                string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";


                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNumber = (long)reader[0];

                            string name = (string)reader[1];

                            int age = (int)reader[2];

                            Console.WriteLine($"{rowNumber}. {name} {age}");

                        }


                        if (!reader.HasRows)
                        {
                            Console.WriteLine($"(no minions)");
                        }
                    }
                }
            }


        }
    }
}

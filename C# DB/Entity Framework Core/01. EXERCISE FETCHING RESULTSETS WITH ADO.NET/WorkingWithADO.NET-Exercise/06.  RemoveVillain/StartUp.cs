﻿using System;
using System.Data.SqlClient;

namespace _06.__RemoveVillain
{
    class StartUp
    {
        private static string connectionString =
         "Server = VALIO\\SQLEXPRESS;" +
         "Database = MinionsDB;" +
         "Integrated Security = true";

        private static SqlConnection connection = new SqlConnection(connectionString);

        private static SqlTransaction transaction;
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                try
                {
                    transaction = connection.BeginTransaction();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = "SELECT Name FROM Villains WHERE Id = @villainId";
                    command.Parameters.AddWithValue("@villainId", id);

                    object value = command.ExecuteScalar();

                    if (value == null)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }

                    string villianName = (string)value;

                    command.CommandText = @"DELETE FROM MinionsVillains 
                                            WHERE VillainId = @villainId";

                    int minionsDeleted = command.ExecuteNonQuery();

                    command.CommandText = @"DELETE FROM Villains
                                           WHERE Id = @villainId";

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine($"{villianName} was deleted.");
                    Console.WriteLine($"{minionsDeleted} minions were released.");


                }
                catch (ArgumentException ae)
                {

                    try
                    {
                        Console.WriteLine(ae.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
            }


        }
    }
}

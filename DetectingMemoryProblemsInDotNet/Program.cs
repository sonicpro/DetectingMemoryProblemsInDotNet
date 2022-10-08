using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DetectingMemoryProblemsInDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var sql = new SqlCommand("select * from PointsOfInterest;");
            Console.WriteLine("Press any key to know the first point of interest name. Enter \"x\" to exit.");
            while (true)
            {            
                ConsoleKeyInfo choice = Console.ReadKey(true);
                if (choice.KeyChar == 'x')
                {
                    break;
                }

                System.Console.WriteLine(GetNameOfPointOfInterest(sql));
            }
        }

        private static string GetNameOfPointOfInterest(SqlCommand sql)
        {
            // Connection pooling is switched off in the connection string. So we are likely to get out of memory rather than timeout.
            var connection = new SqlConnection(ConfigurationManager.AppSettings["connectionStrings:cityInfoDBConnectionString"]);
            sql.Connection = connection;
            connection.Open();
            var reader = sql.ExecuteReader();
            reader.Read();
            return reader.GetString(1);
        }
    }
}

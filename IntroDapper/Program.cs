using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using IntroDapper.DatabaseModel;

namespace IntroDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var newGuid = Guid.NewGuid();
            Console.WriteLine(newGuid);
            return;


            /*
             * CRUD-operasjonene
             *
             * Create - INSERT INTO
             * Read   - SELECT
             * Update - UPDATE
             * Delete - DELETE
             *
             * Autoincrement
             * Guid
             *
             */
            var person = new Person {Id=20, Name = "Knut", PlaceId = 2};
            InsertIntoDemo(person);

            SelectDemo();

            person.Name = "Ole";
            person.PlaceId = 1;
            UpdateDemo(person);

            SelectDemo();

            DeleteDemo(person);

            SelectDemo();
        }

        static void DeleteDemo(Person person) // int id
        {
            var sql = "DELETE FROM People WHERE Id = @Id";
            var conn = CreateConnection();

            var rowsAffected = conn.Execute(sql, person);
            Console.WriteLine($"slettet {rowsAffected} rader");
        }

        static void UpdateDemo(Person person)
        {
            var sql = "UPDATE People SET Name = @Name, PlaceId = @PlaceId WHERE Id = @Id";
            var conn = CreateConnection();

            var rowsAffected = conn.Execute(sql, person);
            Console.WriteLine($"endret {rowsAffected} rader");
        }

        static void InsertIntoDemo(Person person)
        {
            var sql = "INSERT INTO People VALUES (@Id, @Name, @PlaceId)";
            var conn = CreateConnection();

            var rowsAffected = conn.Execute(sql, person);
            Console.WriteLine($"la til {rowsAffected} rader");
        }

        static void SelectDemo()
        {
            var sql = "SELECT Id, Name, PlaceId FROM People";
            var conn = CreateConnection();

            var people = conn.Query<Person>(sql).ToList();
            Console.WriteLine("\n *** ");
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static SqlConnection CreateConnection()
        {
            var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Terje;Integrated Security=True";
            var conn = new SqlConnection(connStr);
            return conn;
        }


    }
}

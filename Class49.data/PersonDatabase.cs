using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Class49.data
{
    public class PersonDatabase
    {
        private string _connectionString;

        public PersonDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PeopleTable";
            connection.Open();
            using var reader = command.ExecuteReader();
            List<Person> allPeople = new ();
            while (reader.Read())
            {
                allPeople.Add(GetPersonFromReader(reader));
            }
            return allPeople;
        }

        public void InsertPerson(SqlConnection connection, Person person)
        {
            if (person.FirstName != null && person.LastName != null)
            {
                using var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO PeopleTable VALUES (@first, @last, @age)";
                command.Parameters.AddWithValue("@first", person.FirstName);
                command.Parameters.AddWithValue("@last", person.LastName);
                command.Parameters.AddWithValue("@age", person.Age);
                command.ExecuteNonQuery();

            }
        }
        public void AddPeople(List<Person> people) 
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            foreach (var p in people)
            {
                InsertPerson(connection, p);
            }

        }
        public Person GetPersonFromReader(SqlDataReader reader)
        {
            var p = new Person();
            p.Id = (int)reader["Id"];
            p.FirstName = (string)reader["FirstName"];
            p.LastName = (string)reader["LastName"];
            p.Age = (int)reader["Age"];
            return p;
        }
    }
}

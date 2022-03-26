using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperApp.Library1.Models;

namespace DapperApp.Library1.Queries
{
    public class PersonQueries : ConnectionFactory
    {
        public List<Person> GetPersons()
        {
            List<Person> persons = null;

            RunCommand((connection) =>
            {
                persons = connection.Query<Person>("select * from Persons").ToList();
            });

            return persons;
        }

        public void CreatePerson(Person person)
        {
            RunCommand((connection) =>
            {
                var insertedId = connection.ExecuteScalar<int>(@"insert into Persons values (@name,@surname) select SCOPE_IDENTITY()",
                    new
                    {
                        name = person.Name,
                        surname = person.Surname
                    });

                person.Id = insertedId;
            });
        }
        public void UpdatePerson(int Id, string name, string surname)
        {
            RunCommand((connection) =>
            {
                connection.Query<Person>($"Update Persons Set Name = '{name}', Surname='{surname}' where Id = {Id}");

            });
        }

        public void DeletePerson(int Id)
        {

            RunCommand((connection) =>
            {
                connection.Query<Person>($"Delete From Persons where Id = {Id}");

            });
        }
        public List<Person> FilterPersons(string find)
        {
            List<Person> persons = null;
            RunCommand((connetion) =>
            {
                persons = connetion.Query<Person>($"Select * From Persons Where Name like '{find}%'").ToList();
            });
            return persons;
        }

    }
}



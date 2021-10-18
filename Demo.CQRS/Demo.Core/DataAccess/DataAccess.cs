using Demo.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Core.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<PersonModel> people = new();
        public DataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Nguyen", LastName = "Chung" });
            people.Add(new PersonModel { Id = 2, FirstName = "Le", LastName = "Duy" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new PersonModel() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(p => p.Id) + 1;
            people.Add(p);
            return p;
        }

        public PersonModel UpdatePerson(int id, string firstName, string lastName)
        {
            PersonModel p = GetPersonById(id);
            p.FirstName = firstName;
            p.LastName = lastName;
            return p;
        }

        public bool DeletePerson(int id)
        {
            PersonModel p = GetPersonById(id);
            people.Remove(p);
            return true;
        }

        public PersonModel GetPersonById(int id)
        {
            return people.FirstOrDefault(m => m.Id == id);
        }
    }
}

using Demo.Core.Models;
using System.Collections.Generic;

namespace Demo.Core.DataAccess
{
    public interface IDataAccess
    {
        List<PersonModel> GetPeople();
        PersonModel InsertPerson(string firstName, string lastName);
        PersonModel GetPersonById(int id);
        PersonModel UpdatePerson(int id, string firstName, string lastName);
        bool DeletePerson(int id); 
    }
}

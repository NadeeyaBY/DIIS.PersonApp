using DIIS.PersonApp.Entities;
using DIIS.PersonApp.IServices;



namespace DIIS.PersonApp.Services
{
    public class PersonServiceInMemory : IPersonService
    {
        public List<Person> People = new List<Person>()
        {
            new Person{
                PersonId = "001254",
                FirstName = "Nadeeya",
                LastName = "Jiwanit",
                BirthDate = new DateTime(1993, 6, 16)
            },
            new Person{
                PersonId = "001255",
                FirstName = "Somchai",
                LastName = "Sriaaa",
                BirthDate = new DateTime(1972, 5, 1)
            },
            new Person{
                PersonId = "001255",
                FirstName = "Lionel",
                LastName = "Messi",
                BirthDate = new DateTime(1992, 2, 15)
            },
        };



        public async Task DeletePerson(string personId)
        {
            await Task.CompletedTask;
        }



        public List<Person> GetPeople()
        {
            return People;
        }



        public Person GetPersonById(string personId)
        {
            return People.FirstOrDefault(x => x.PersonId == personId);
        }



        public async Task InsertPerson(Person person)
        {
            await Task.CompletedTask;
        }



        public async Task UpdatePerson(Person person)
        {
            await Task.CompletedTask;
        }
    }
}
using DIIS.PersonApp.Entities;



namespace DIIS.PersonApp.IServices
{
    public interface IPersonService
    {
        List<Person> GetPeople();
        Person GetPersonById(string personId);
        Task InsertPerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(string personId);
    }
}
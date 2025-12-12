using RestWithASPNET10.Model;

namespace RestWithASPNET10.Service.Impl
{
    public class PersonServicesImpl : IPerasonService
    {
        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000); //Simulate ID assignment
            return person;

        }
        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //Simulate delete operation
        }
        public Person FindById(long id)
        {
            var person = mockPerson();
            return person;
        }


        public List<Person> FindAll()
        {

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                var person = mockPerson();
                persons.Add(person);
            }
            return persons;

        }
        private Person mockPerson()
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "John",
                LastName = "Doe",
                Address = "123 rua",
                gender = "male"

            };
            return person;
        }
    }
}

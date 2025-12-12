using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using System;

namespace RestWithASPNET10.Service.Impl
{
    public class PersonServicesImpl : IPerasonService
    {
        private MSSQLContext _context;
        public PersonServicesImpl(MSSQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;

        }
        public Person Update(Person person)
        {
            var exist = _context.Persons.Find(FindById(person.Id)); 
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            else
            {
                return null;
            }

        }

        public void Delete(long id)
        {
            var exist = _context.Persons.Find(FindById(id));
            if (exist != null)
            {
                _context.Remove(exist);
                _context.SaveChanges();
            }
        }
        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }


        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
    }
}

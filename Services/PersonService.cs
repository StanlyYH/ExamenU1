using ExamenU1.Entities;

namespace ExamenU1.Services
{
    public class PersonService
    {
        private readonly List<PersonEntity> _persons = new()
        {
            new PersonEntity
            {
                DNI = "1411200100485",
                FirstName = "Derick",
                LastName = "Garcia",
                Gender = "Masculino",
                Birthdate = DateTime.Parse("2001-04-02")
            }
        };

        public List<PersonEntity> GetAll() => _persons;

        public PersonEntity? GetOne(string dni)
            => _persons.FirstOrDefault(p => p.DNI == dni);

        public bool Create(PersonEntity person)
        {
            if (_persons.Any(p => p.DNI == person.DNI)) return false;
            _persons.Add(person);
            return true;
        }

        public bool Update(string dni, PersonEntity updated)
        {
            var existing = GetOne(dni);
            if (existing == null) return false;

            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            existing.Gender = updated.Gender;
            existing.Birthdate = updated.Birthdate;

            return true;
        }

        public bool Delete(string dni)
        {
            var existing = GetOne(dni);
            if (existing == null) return false;

            _persons.Remove(existing);
            return true;
        }
    }
}
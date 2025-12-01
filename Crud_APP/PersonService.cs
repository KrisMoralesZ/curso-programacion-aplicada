using System.Collections.Generic;
using System.Linq;
using Crud_APP;

public class PersonService
{
  public void Create(Person p)
  {
    using var db = new AppDbContext();
    db.People.Add(p);
    db.SaveChanges();
  }

  public List<Person> GetAll()
  {
    using var db = new AppDbContext();
    return db.People.ToList();
  }

  public void Update(Person p)
  {
    using var db = new AppDbContext();
    db.People.Update(p);
    db.SaveChanges();
  }

  public void Delete(int id)
  {
    using var db = new AppDbContext();
    var person = db.People.FirstOrDefault(x => x.Id == id);
    if (person != null)
    {
      db.People.Remove(person);
      db.SaveChanges();
    }
  }
}
using Avalonia.Controls;

namespace Crud_APP;

public partial class MainWindow : Window
{
  private readonly PersonService _service = new();
  public MainWindow()
  {
    InitializeComponent();

    LoadPeople();

    addButton.Click += (s, e) => AddPerson();
    updateButton.Click += (s, e) => UpdatePerson();
    deleteButton.Click += (s, e) => DeletePerson();
  }

  private void LoadPeople()
  {
    peopleList.ItemsSource = _service.GetAll();
  }

  private void AddPerson()
  {
    var person = new Person
    {
      Name = nameInput.Text,
      Age = int.Parse(ageInput.Text)
    };

    _service.Create(person);
    LoadPeople();
  }

  private void UpdatePerson()
  {
    if (peopleList.SelectedItem is Person selected)
    {
      selected.Name = nameInput.Text;
      selected.Age = int.Parse(ageInput.Text);

      _service.Update(selected);
      LoadPeople();
    }
  }

  private void DeletePerson()
  {
    if (peopleList.SelectedItem is Person selected)
    {
      _service.Delete(selected.Id);
      LoadPeople();
    }
  }
}
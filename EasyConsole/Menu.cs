namespace EasyConsole;

public class Menu
{

  readonly List<Option> _options = [];

  public void Display()
  {
    for (int i = 0; i < _options.Count; i++)
    {
      Console.WriteLine("{0}. {1}", i + 1, _options[i].Name);
    }
    int choice = Input.ReadInt("Choose an option:", min: 1, max: _options.Count);

    _options[choice - 1].Callback();
  }

  public Menu Add(string option, Action callback)
  {
    return Add(new Option(option, callback));
  }

  public Menu Add(Option option)
  {
    _options.Add(option);
    return this;
  }

  public bool Contains(string option)
  {
    return _options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
  }
}

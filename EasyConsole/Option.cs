namespace EasyConsole;

public class Option
{
  public string Name { get; }
  public Action Callback { get; }

  public Option(string name, Action callback)
  {
    if (string.IsNullOrEmpty(name))
    {
      throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
    }
    Name = name;
    Callback = callback ?? throw new ArgumentNullException(nameof(callback));
  }

  public override string ToString() => Name;

}

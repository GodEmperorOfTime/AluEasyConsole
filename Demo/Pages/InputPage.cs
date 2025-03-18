using EasyConsole;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Pages;

class InputPage : Page
{
  public InputPage(EasyConsole.Program program)
      : base("Input", program)
  { }

  public override async Task DisplayAsync(CancellationToken cancellationToken)
  {
    await base.DisplayAsync(cancellationToken);
    Fruit input = await Input.ReadEnumAsync<Fruit>("Select a fruit");
    Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);
    Input.ReadString("Press [Enter] to navigate home");
    await Program.NavigateHomeAsync(cancellationToken);
  }
}

enum Fruit
{
  Apple,
  Banana,
  Coconut
}

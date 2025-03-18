using EasyConsole;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Pages;

class Page1B : Page
{
  public Page1B(EasyConsole.Program program)
      : base("Page 1B", program)
  { }

  public override async Task DisplayAsync(CancellationToken cancellationToken)
  {
    await base.DisplayAsync(cancellationToken);
    Output.WriteLine("Hello from Page 1B");
    Input.ReadString("Press [Enter] to navigate home");
    await Program.NavigateHomeAsync(cancellationToken);
  }
}

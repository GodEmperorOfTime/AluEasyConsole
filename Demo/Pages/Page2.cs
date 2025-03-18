using EasyConsole;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Pages;

class Page2 : Page
{
  public Page2(EasyConsole.Program program)
      : base("Page 2", program)
  { }

  public override async Task DisplayAsync(CancellationToken cancellationToken)
  {
    await base.DisplayAsync(cancellationToken);
    Output.WriteLine("Hello from Page 2");
    Input.ReadString("Press [Enter] to navigate home");
    await Program.NavigateHomeAsync(cancellationToken);
  }
}

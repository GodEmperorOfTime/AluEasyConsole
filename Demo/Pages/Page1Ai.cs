using EasyConsole;

namespace Demo.Pages;

class Page1Ai : Page
{
  public Page1Ai(EasyConsole.Program program)
      : base("Page 1Ai", program)
  { }

  public override async Task DisplayAsync(CancellationToken cancellationToken)
  {
    await base.DisplayAsync(cancellationToken);
    Output.WriteLine("Hello from Page 1Ai");
    Input.ReadString("Press [Enter] to navigate home");
    await Program.NavigateHomeAsync(cancellationToken);
  }
}

using EasyConsole;

namespace Demo.Pages;

class MainPage : MenuPage
{
  public MainPage(EasyConsole.Program program) : base(
    title: "Main Page", 
    program: program,
    // options:
      new Option("Page 1", program.NavigateToAsync<Page1>),
      new Option("Page 2", program.NavigateToAsync<Page2>),
      new Option("Input", program.NavigateToAsync<InputPage>))
  { }
}

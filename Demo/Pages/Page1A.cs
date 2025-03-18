using EasyConsole;

namespace Demo.Pages;

class Page1A : MenuPage
{
  public Page1A(EasyConsole.Program program) : base(
    title: "Page 1A", 
    program: program,
    options: new Option("Page 1Ai", program.NavigateToAsync<Page1Ai>))
  { }
}

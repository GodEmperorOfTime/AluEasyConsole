using EasyConsole;

namespace Demo.Pages;

class Page1 : MenuPage
{
    public Page1(EasyConsole.Program program) : base(
      title: "Page 1", 
      program: program,      
      // options:
        new Option("Page 1A", program.NavigateToAsync<Page1A>),
        new Option("Page 1B", program.NavigateToAsync<Page1B>)
      )
    {  }
}

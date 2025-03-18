using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyConsole;

public abstract class Program
{
  protected string Title { get; set; }

  public bool BreadcrumbHeader { get; private set; }

  protected Page? CurrentPage => History.TryPeek(out var r) ? r : null;

  readonly Dictionary<Type, Page> _pages = new();

  public Stack<Page> History { get; } = new();

  public bool NavigationEnabled { get { return History.Count > 1; } }

  protected Program(string title, bool breadcrumbHeader)
  {
    Title = title;
    BreadcrumbHeader = breadcrumbHeader;
  }

  public virtual void Run()
  {
    try
    {
      Console.Title = Title;

      CurrentPage?.Display();
    }
    catch (Exception e)
    {
      Output.WriteLine(ConsoleColor.Red, e.ToString());
    }
    finally
    {
      if (Debugger.IsAttached)
      {
        Input.ReadString("Press [Enter] to exit");
      }
    }
  }

  public void AddPage(Page page)
  {
    Type pageType = page.GetType();

    if (_pages.ContainsKey(pageType))
      _pages[pageType] = page;
    else
      _pages.Add(pageType, page);
  }

  public void NavigateHome()
  {
    while (History.Count > 1)
      History.Pop();

    Console.Clear();
    CurrentPage?.Display();
  }

  public T? SetPage<T>() where T : Page
  {
    Type pageType = typeof(T);

    if (CurrentPage is T tPage)
      return tPage;

    // leave the current page

    // select the new page
    if (!_pages.TryGetValue(pageType, out var nextPage))
      throw new KeyNotFoundException("The given page \"{0}\" was not present in the program".Format(pageType));

    // enter the new page
    History.Push(nextPage);

    return CurrentPage as T;
  }

  public T? NavigateTo<T>() where T : Page
  {
    SetPage<T>();

    Console.Clear();
    CurrentPage?.Display();
    return CurrentPage as T;
  }

  public Page? NavigateBack()
  {
    History.Pop();

    Console.Clear();
    CurrentPage?.Display();
    return CurrentPage;
  }
}

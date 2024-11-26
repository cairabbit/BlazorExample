namespace BlazorApp.Components;


public class Icons(string prefix = "fa")
{
  public static Icons Regular()
  {
    return new Icons("fa");
  }

  public static Icons Solid()
  {
    return new Icons("fa fa-solid");
  }

  public Icons Size(int size = 1)
  {
    _size = size;
    return this;
  }
  public Icons Outline()
  {
    _outline = true;
    return this;
  }
  protected int _size = 1;
  protected bool _outline = false;
  protected string _prefix = prefix;
  public string Icon(string icon)
  {
    return $"{_prefix} fa-{icon}{(_outline ? "-o" : "")}{(_size > 1 ? $" fa-{_size}x" : "")}".ToLower();
  }
  public string Filter => Icon(nameof(Filter));
  public string Plus => Icon(nameof(Plus));
  public string Times => Icon(nameof(Times));
  public string Xmark => Icon(nameof(Xmark));
  public string User => Icon(nameof(User));
  public string Search => Icon("magnifying-glass");
  public string Envelope => Icon(nameof(Envelope));
  public string Clock => Icon(nameof(Clock));
  public string Gears => Icon(nameof(Gears));
  public string Gear => Icon(nameof(Gear));
  public string Ellipsis => Icon(nameof(Ellipsis));
  public string Wrench => Icon(nameof(Wrench));
  public string Lock => Icon(nameof(Lock));
  public string HashTag => Icon(nameof(HashTag));

}


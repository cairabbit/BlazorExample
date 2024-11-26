using BootstrapBlazor.Components;

namespace BlazorApp.Components;

public class UIComponentBase : IdComponentBase
{
  protected virtual string? ClassString => CssBuilder.Default(string.Join(" ", _classes)).AddClassFromAttributes(AdditionalAttributes).Build();

  protected List<string> _classes = [];
  protected Dictionary<string, string> _styles = [];
  protected void AppendAttribute(string key, object value, Func<bool>? when = null)
  {
    if (when != null && !when.Invoke())
      return;
    AdditionalAttributes ??= new Dictionary<string, object>();
    if (value != null)
    {
      if (!AdditionalAttributes.TryAdd(key, value))
      {
        AdditionalAttributes[key] = value;
      }
    }
  }

  protected void AppendStyle(string key, string value, Func<bool>? when = null)
  {
    if (when != null && !when.Invoke())
      return;
    if (!_styles.TryAdd(key, value))
    {
      _styles[key] = value;
    }
    if (_styles.Count > 0)
    {
      AppendAttribute("style", _styles.ToFormatString(";", ":"));
    }
  }

  protected void AppendClass(string cls, Func<bool>? when = null)
  {
    if (when != null && !when.Invoke())
      return;
    if (!_classes.Contains(cls))
      _classes.Add(cls);
  }

  protected void RemoveClass(string cls, Func<bool>? when = null)
  {
    if (when != null && !when.Invoke())
      return;
    _classes.Remove(cls);
  }
}


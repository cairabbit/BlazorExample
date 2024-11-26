using System.Text;

namespace BlazorApp.Components;

public static class Extensions
{
  public static string ToFormatString<T, V>(this IDictionary<T, V> dic, string comma = "&", string equal = "=", string valueWrapperLeft = "", string valueWrapperRight = "", Func<T, string>? keyToString = null, Func<V, string?>? valToString = null)
      where T : notnull
  {
    if (dic == null || dic.Count <= 0)
      return string.Empty;
    keyToString ??= o => o.ToString() ?? o.GetType().ToString();
    valToString ??= o => o?.ToString();
    StringBuilder sb = new();
    int idx = 0;
    foreach (T key in dic.Keys)
    {
      sb.AppendFormat("{0}{1}{2}{3}{4}", keyToString(key), equal, valueWrapperLeft, valToString(dic[key]), valueWrapperRight);
      if (idx < dic.Count - 1)
        sb.Append(comma);
      idx++;
    }
    return sb.ToString();
  }
}

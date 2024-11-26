using BootstrapBlazor.Components;

namespace BlazorApp.Models;

public class ClientFilter : ITableSearchModel
{
  public string? Name { get; set; }

  public IEnumerable<IFilterAction> GetSearches()
  {
    var filters = new List<IFilterAction>();

    if (!string.IsNullOrEmpty(Name))
      filters.Add(new SearchFilterAction(nameof(Name), Name, FilterAction.Contains));

    return filters;
  }

  public void Reset()
  {
    Name = null;
  }
}

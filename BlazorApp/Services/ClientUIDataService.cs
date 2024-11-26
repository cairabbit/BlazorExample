using BootstrapBlazor.Components;
using Common;

namespace BlazorApp.Services;

public class ClientUIDataService : IDataService<Client>
{
  private List<Client> clients = [];

  public ClientUIDataService()
  {
    clients.Add(new Client { ClientId = 1, Name = "Client 1" });
    clients.Add(new Client { ClientId = 2, Name = "Client 2" });
    clients.Add(new Client { ClientId = 3, Name = "Client 3" });
    clients.Add(new Client { ClientId = 4, Name = "Client 4" });
    clients.Add(new Client { ClientId = 5, Name = "Client 5" });
    clients.Add(new Client { ClientId = 6, Name = "Client 6" });
    clients.Add(new Client { ClientId = 7, Name = "Client 7" });
    clients.Add(new Client { ClientId = 8, Name = "Client 8" });
    clients.Add(new Client { ClientId = 9, Name = "Client 9" });
    clients.Add(new Client { ClientId = 10, Name = "Client 10" });
  }
  public Task<bool> AddAsync(Client model)
  {
    clients.Add(model);
    return Task.FromResult(true);
  }

  public Task<bool> DeleteAsync(IEnumerable<Client> models)
  {
    clients.RemoveAll(c => models.Any(m => m.ClientId == c.ClientId));
    return Task.FromResult(true);
  }

  public Task<QueryData<Client>> QueryAsync(QueryPageOptions option)
  {
    var items = clients;
    if (!string.IsNullOrEmpty(option.SearchText))
    {
      items = items.Where(c => c.Name?.Contains(option.SearchText, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
    }
    var total = items.Count;
    if (option.AdvancedSortList != null)
    {
      items = items.Sort(option.AdvancedSortList).ToList();
    }
    if (option.PageIndex > 0 && option.PageItems > 0)
    {
      items = items.Skip((option.PageIndex - 1) * option.PageItems).Take(option.PageItems).ToList();
    }
    return Task.FromResult(new QueryData<Client>
    {
      Items = items,
      TotalCount = total
    });
  }

  public Task<bool> SaveAsync(Client model, ItemChangedType changedType)
  {
    if (changedType == ItemChangedType.Add)
    {
      clients.Add(model);
    }
    else if (changedType == ItemChangedType.Update)
    {
      var item = clients.FirstOrDefault(c => c.ClientId == model.ClientId);
      if (item != null)
      {
        item.Name = model.Name;
      }
    }
    return Task.FromResult(true);
  }
}

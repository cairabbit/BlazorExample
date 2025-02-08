namespace Common;

public class Client
{
  public required int ClientId { get; set; }
  public required string Name { get; set; }
  public required ClientType Type { get; set; }
  public string? Details { get; set; }
}

[Flags]
public enum ClientType
{
  Data = 1,
  WebApi = 2,
  Grpc = 4,
  Wcf = 8,
  Web = 16
}
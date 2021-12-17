namespace Blazor.Weather.Shared
{
  public class InfoMessage
  {
    public InfoMessage(string message)
    {
      Message = message;
    }

    public string Message { get; }
  }
}

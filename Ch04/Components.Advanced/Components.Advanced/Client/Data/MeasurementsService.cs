namespace Components.Advanced.Client.Data
{
  public class MeasurementsService
  {
    public ValueTask<List<Measurement>> GetMeasurements()
    {
      const int nrOfRows = 5000;
      var result = new List<Measurement>();
      var rnd = new Random();
      for (int i = 0; i < nrOfRows; i += 1)
      {
        result.Add(new Measurement()
        {
          Guid = Guid.NewGuid(),
          Min = rnd.Next(0, 100),
          Avg = rnd.Next(100, 300),
          Max = rnd.Next(300, 400),
        });
      }
      // Newer and nicer way with .NET 6
      return ValueTask.FromResult(result);
      // return new ValueTask<List<Measurement>>(result);
    }

    public async ValueTask<(List<Measurement>, int)> GetMeasurementsPage(int from, int count, CancellationToken cancellationToken)
    {
      const int maxMeasurements = 5000;
      // Start Add delay
      const int delay = 50;
      await Task.Delay(delay, cancellationToken);
      // End Add delay
      var result = new List<Measurement>();
      var rnd = new Random();
      count = Math.Max(0, Math.Min(count, maxMeasurements - from));
      for (int i = 0; i < count; i += 1)
      {
        result.Add(new Measurement()
        {
          Guid = Guid.NewGuid(),
          Min = rnd.Next(0, 100),
          Avg = rnd.Next(100, 300),
          Max = rnd.Next(300, 400),
        });
      }
      return (result, maxMeasurements);
    }
  }
}

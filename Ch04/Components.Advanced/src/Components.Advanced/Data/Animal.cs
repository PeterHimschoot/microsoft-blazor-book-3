namespace Components.Advanced.Data
{
  public class Animal
  {
    public string Name { get; set; } = string.Empty;
  }

  public class Dog : Animal
  {
    public bool IsAGoodDog { get; set; }
  }

  public class Cat : Animal
  {
    public bool Scratches { get; set; }
  }
}

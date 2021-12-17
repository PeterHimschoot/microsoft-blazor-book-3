using System;
using System.IO;

namespace BlazorWithgRPC.Server.Services
{
  public class ImageService
  {
    private static readonly byte[] Cloudy;
    private static readonly byte[] Rain;
    private static readonly byte[] Sunny;
    private static readonly byte[] Thunder;
    private static readonly Random rnd = new Random();

    static ImageService()
    {
      Cloudy = LoadImage("Cloudy.png");
      Rain = LoadImage("Rain.png");
      Sunny = LoadImage("Sunny.png");
      Thunder = LoadImage("Thunder.png");
    }

    private static byte[] LoadImage(string name)
    {
      string imagePath = Path.Combine(Environment.CurrentDirectory, "Images", name);
      using Stream imageFile =
        File.Open(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
      byte[] imageBytes = new byte[imageFile.Length];
      imageFile.Read(imageBytes, 0, imageBytes.Length);
      return imageBytes;
    }

    public byte[] RandomImage()
    {
      switch (rnd.Next(0, 4))
      {
        case 0: return Cloudy;
        case 1: return Rain;
        case 2: return Sunny;
        default: return Thunder;
      }
    }
  }
}

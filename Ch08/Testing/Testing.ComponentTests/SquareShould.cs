using System;
using Testing.Shared;
using Xunit;

namespace Testing.ComponentTests
{
  public class SquareShould
  {
    [Fact]
    public void Return9For3()
    {
      // Arrange
      var sut = new Utils();
      // Act
      int actual = sut.Square(3);
      // Assert
      Assert.Equal(expected: 9, actual: actual);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 4)]
    [InlineData(-1, 1)]
    public void ReturnSquareOfNumber(int number, int square)
    {
      // Arrange
      var sut = new Utils();
      // Act
      int actual = sut.Square(number);
      // Assert
      Assert.Equal(expected: square, actual: actual);
    }

    [Fact]
    public void ThrowOverflowForBigNumbers()
    {
      // Arrange
      var sut = new Utils();
      // Act & Assert
      Assert.Throws<OverflowException>(() =>
      {
        int result = sut.Square(int.MaxValue);
      });
    }
  }
}
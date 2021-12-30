using Bunit;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class CardShould : TestContext
  {
    [Fact]
    public void RenderCorrectlyWithProperId()
    {
      var cut = RenderComponent<Card>();
      cut.MarkupMatches(@"<h3 diff:ignorecase diff:regex id:regex=""card-\d{1,4}"">card \d{1,4}</h3>");
    }
  }
}

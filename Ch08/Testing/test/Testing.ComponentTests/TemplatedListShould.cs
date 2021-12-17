using Bunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class TemplatedListShould : TestContext
  {
    [Fact]
    public void RenderLoadingTemplateWhenItemsIsNull()
    {
      const string loading = "<div class=\"loader\">Loading...</div>";
      Func<ValueTask<IEnumerable<string>?>> loader =
        () => new ValueTask<IEnumerable<string>?>(result:null);

      var cut = RenderComponent<TemplatedList<string>>(parameters =>
                  parameters.Add(tl => tl.Loader, loader)
                            .Add(tl => tl.LoadingContent, loading)
      );
      cut.Find("div.loader")
         .MarkupMatches(loading);
    }

    [Fact]
    public void RenderItemsCorrectly()
    {
      const int count = 5;
      Func<ValueTask<IEnumerable<string>>> loader =
        () => new ValueTask<IEnumerable<string>>(Enumerable.Repeat("A", count));
      var cut = RenderComponent<TemplatedList<string>>(parameters =>
                  parameters.Add(tl => tl.Loader, loader)
                            .Add(tl => tl.ItemContent, (context) => $"<p>{context}</p>"));
      var ps = cut.FindAll("p");
      ps.Should().NotBeEmpty();
      foreach (var p in ps)
      {
        p.MarkupMatches("<p>A</p>");
      }
    }

    [Fact]
    public void RenderItemsWithListItemCorrectly()
    {
      const int count = 5;
      Func<ValueTask<IEnumerable<string>?>> loader =
        () => new ValueTask<IEnumerable<string>?>(Enumerable.Repeat("A", count));
      var cut = RenderComponent<TemplatedList<string>>(parameters =>
                  parameters.Add(tl => tl.Loader, loader)
                            /*component*//*TItem*/
                            .Add<ListItem, string>(tl => tl.ItemContent,
                              context => itemParams
                                      => itemParams.Add(p => p.Item, context)
                            ));
      var ps = cut.FindAll("p");
      ps.Should().NotBeEmpty();
      foreach (var p in ps)
      {
        p.MarkupMatches("<p>A</p>");
      }
    }
  }
}

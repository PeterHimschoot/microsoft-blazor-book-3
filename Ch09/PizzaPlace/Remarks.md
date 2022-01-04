# Remarks about Chapter 9

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Finished version

When you run the finished solution and every time you return to the Index component the list of pizzas grows you should add a check to see if we already loaded the pizzas.

For example:

``` C#
protected override async Task OnInitializedAsync()
{
  if (!State.Menu.Pizzas.Any()) // Uses Linq, so add a using on top
  {
    Menu menu = await MenuService.GetMenu();
    foreach (Pizza pizza in menu.Pizzas)
    {
      State.Menu.Add(pizza);
    }
  }
}
```



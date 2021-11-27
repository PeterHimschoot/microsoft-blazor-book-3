# Remarks about Chapter 2

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## C# Features

The template now automatically enables [nullable reference types](https://blogs.u2u.be/peter/post/c-nullable-reference-types)
and also [implicit usings](https://blogs.u2u.be/peter/post/c-10-implicit-using-and-file-scoped-namespaces)

```
<PropertyGroup>
  <TargetFramework>net6.0</TargetFramework>
  <Nullable>enable</Nullable>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

The PizzaPlace.Shared project now also uses file-scoped namespaces.

## Images

Images folder can be found in microsoft-blazor-book-3\Ch02\PizzaPlace\PizzaPlace\Client\wwwroot

## Bootstrap

Blazor now uses Bootstrap 5, meaning that some of the screenshots from the book can differ.

I have also styled the inputs with [floating labels](https://getbootstrap.com/docs/5.0/forms/floating-labels/)

```
<div class="mb-2 form-group form-floating">
  <InputText class="form-control" id="name" placeholder="name" @bind-Value="@State.Basket.Customer.Name" />
  <label for="name">Name:</label>
  <ValidationMessage For="@(() => State.Basket.Customer.Name)" />
</div>
```






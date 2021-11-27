# Remarks about Chapter 2

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Hot Reload

Run the application without the debugger and make the changes.
Most of the time you don't even need to restart the application,
changes will be applied to your running application!

## Using C# Lambda Functions

There is no longer the need to wrap lambda functions in braces:

``` razor
<button class="btn btn-primary"
        disabled="@(currentCount > 10)"
        @onclick="() => currentCount++">Click me</button>
```

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





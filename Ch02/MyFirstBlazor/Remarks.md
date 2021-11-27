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





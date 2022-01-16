# Remarks about Chapter 10

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Calling .NET Methods from JavaScript on page 397

We create a subscription to the browser's `storage` event, and we only need to
do this once, so change listing 10-10 to

``` C#
protected override async Task OnAfterRenderAsync(bool firstRender)
{
  if (inputElement is not null)
  {
    await js.InvokeVoidAsync("blazorFocus.set", inputElement);
  }
  if( firstRender)
  {
    // We only need to create the subscription once
    var objRef = DotNetObjectReference.Create(this);
    await js.InvokeVoidAsync("blazorLocalStorage.watch", objRef);
  }
}
```

## Loading the Module into a Blazor Service

On page 406 we implement the `LocalStorageWithModule` class, and you should not
forget to change dependency injection to use this class:

``` C#
//builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
builder.Services.AddSingleton<ILocalStorage, LocalStorageWithModule>();
```






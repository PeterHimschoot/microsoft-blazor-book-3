# Remarks about Chapter 16

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Launching the Blazor.Server.OpenIdConnect project

Visual Studio now randomizes the port when creating a new project.
This chapter assumes that the IdentityProvider project runs on port 5011,
and the Blazor.Server.OpenIdConnect project project on port 5001.

Update launchSettings.json to reflect this

``` json
"applicationUrl": "https://localhost:5001;http://localhost:5000",
```

## Running with the debugger

When running the project with the debugger you might encounter a `NavigationException`.
This is quite normal and you can simply press `F5` to continue, or you can tell
the debugger not to stop on this exception using the Debug->Windows->Exception Settings dialog.

## Creating the API project

When creating the API project check the `Use Controllers` checkbox.

## Save your access tokens

Don't forget to add this to the client inside the `AddOpenIdConnect` call

> Looks like I forgot to put this in the book!

``` C#
// Save the tokens we receive from the IDP
options.SaveTokens = true;
```









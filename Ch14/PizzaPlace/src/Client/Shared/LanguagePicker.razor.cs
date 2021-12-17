using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Globalization;

namespace PizzaPlace.Client.Shared
{
  public partial class LanguagePicker
  {
    [Inject]
    public NavigationManager NavManager { get; set; } = default!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Inject]
    public IConfiguration Configuration { get; set; } = default!;

    private Dictionary<string, string>? cultures;

    protected override void OnInitialized()
      => this.cultures = Configuration.GetCulturesSection();

    private string Culture
    {
      get => CultureInfo.CurrentCulture.Name;
      set
      {
        if (Culture != value)
        {
          var js = (IJSInProcessRuntime)JSRuntime;
          js.InvokeVoid("blazorCulture.set", value);
          var culture = new CultureInfo(value);
          CultureInfo.DefaultThreadCurrentCulture = culture;
          CultureInfo.DefaultThreadCurrentUICulture = culture;
          // Force the page to reload
          NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
        }
      }
    }
  }
}

using I10nBlazorServer.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace I10nBlazorServer.Shared
{
  public partial class LanguagePicker
  {
    [Inject]
    public IConfiguration Configuration { get; set; }

    [Inject]
    public IStringLocalizer<LanguagePicker> Localizer { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private string selectedCulture = CultureInfo.CurrentUICulture.Name;

    private Dictionary<string, string> cultures;

    protected override void OnInitialized() => this.cultures = Configuration.GetCulturesSection();

    // Navigate to the CultureController,
    // passing new culture and redirecturi back to this page
    private void RequestCultureChange()
    {
      if (string.IsNullOrWhiteSpace(this.selectedCulture))
      {
        return;
      }
      string uri = new Uri(NavigationManager.Uri)
              .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
      string query = $"?culture={Uri.EscapeDataString(this.selectedCulture)}&redirectUri={Uri.EscapeDataString(uri)}";
      NavigationManager.NavigateTo($"/Culture/SetCulture/{query}", forceLoad: true);
    }
  }
}

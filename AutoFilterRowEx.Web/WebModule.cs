using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace AutoFilterRowEx.Web
{
  [ToolboxItemFilter("Xaf.Platform.Web")]
  public sealed partial class AutoFilterRowExAspNetModule : ModuleBase
  {
    public AutoFilterRowExAspNetModule()
    {
      InitializeComponent();
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
      return ModuleUpdater.EmptyModuleUpdaters;
    }
  }
}

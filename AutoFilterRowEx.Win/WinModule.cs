using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace AutoFilterRowEx.Win
{
  [ToolboxItemFilter("Xaf.Platform.Win")]
  public sealed partial class AutoFilterRowExWindowsFormsModule : ModuleBase
  {
    public AutoFilterRowExWindowsFormsModule()
    {
      InitializeComponent();
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
      return ModuleUpdater.EmptyModuleUpdaters;
    }
  }
}

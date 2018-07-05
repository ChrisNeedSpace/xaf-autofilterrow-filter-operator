using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace SampleProject.Module
{
  public sealed partial class SampleProjectModule : ModuleBase
  {
    public SampleProjectModule()
    {
      InitializeComponent();
      BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
      ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
      return new ModuleUpdater[] { updater };
    }
    
    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
      base.CustomizeTypesInfo(typesInfo);
      CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }
  }
}

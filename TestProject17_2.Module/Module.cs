using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace TestProject17_2.Module
{
  public sealed partial class TestProject17_2Module : ModuleBase
  {
    public TestProject17_2Module()
    {
      InitializeComponent();
      BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
      ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
      return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application)
    {
      base.Setup(application);
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
      base.CustomizeTypesInfo(typesInfo);
      CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }

    /// <summary>
    /// Register our own model extender interfaces.
    /// </summary>
    public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
    {
      base.ExtendModelInterfaces(extenders);

      // Auto Filter Row --------------------------------------------------------
      extenders.Add<IModelMember, IModelMemberAutoFilterRow>();
    }
  }
}

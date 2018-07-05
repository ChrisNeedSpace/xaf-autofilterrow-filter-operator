using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace AutoFilterRowEx
{
  public sealed partial class AutoFilterRowExModule : ModuleBase
  {
    public AutoFilterRowExModule()
    {
      InitializeComponent();
      BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
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

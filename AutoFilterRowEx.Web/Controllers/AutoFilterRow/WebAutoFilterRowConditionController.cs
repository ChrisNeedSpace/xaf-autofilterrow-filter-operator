using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace AutoFilterRowEx.Web.Controllers
{
  /// <summary>
  /// Defines a default AutoFilterRow filtering Condition.
  /// See <see cref="IModelMemberAutoFilterRow"/>, <see cref="AutoFilterRowConditionAttribute"/>..
  /// See also <seealso href="http://www.devexpress.com/Support/Center/p/S131144.aspx" />.
  /// </summary>
  public class WebAutoFilterRowConditionController : ViewController
  {
    #region ctor

    public WebAutoFilterRowConditionController()
    {
      TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
    }

    #endregion

    #region OnActivated

    protected override void OnActivated()
    {
      base.OnActivated();
      if (this.View is ListView)
      {
        (this.View as ListView).Editor.ModelApplied += Editor_ModelApplied;
        (this.View as ListView).Editor.ModelSaved += Editor_ModelSaved;
      }
    }

    #endregion

    #region OnDeactivated

    protected override void OnDeactivated()
    {
      if (this.View is ListView)
      {
        (this.View as ListView).Editor.ModelApplied -= Editor_ModelApplied;
        (this.View as ListView).Editor.ModelSaved -= Editor_ModelSaved;
      }
      base.OnDeactivated();
    }

    #endregion

    #region Editor_ModelSaved

    private void Editor_ModelSaved(object sender, EventArgs e)
    {
      // Commented out. It saves default values as if they were user edits, which wipes out XAF default value if it will change in future... (not recommended, IMO)
      //if (sender is ASPxGridListEditor)
      //{
      //  foreach (DevExpress.ExpressApp.Editors.ColumnWrapper columnWrapper in ((ASPxGridListEditor)sender).Columns)
      //  {
      //    ASPxGridViewColumnWrapper gridColumnWrapper = columnWrapper as ASPxGridViewColumnWrapper;
      //    if (gridColumnWrapper != null)
      //    {
      //      IModelColumn modelColumn = (this.View as ListView)?.Model.Columns[gridColumnWrapper.PropertyName];
      //      IModelMemberAutoFilterRow modelMember = modelColumn?.ModelMember as IModelMemberAutoFilterRow;
      //      if (modelMember != null)
      //        modelMember.AutoFilterRowCondition = TransformFromAutoFilterCondition(gridColumnWrapper.Column.Settings.AutoFilterCondition);
      //    }
      //  }
      //}
    }

    #endregion

    #region Editor_ModelApplied

    private void Editor_ModelApplied(object sender, EventArgs e)
    {
      if (sender is ASPxGridListEditor)
      {
        foreach (DevExpress.ExpressApp.Editors.ColumnWrapper columnWrapper in ((ASPxGridListEditor)sender).Columns)
        {
          ASPxGridViewColumnWrapper gridColumnWrapper = columnWrapper as ASPxGridViewColumnWrapper;
          if (gridColumnWrapper != null)
          {
            IModelColumn modelColumn = (this.View as ListView)?.Model.Columns[gridColumnWrapper.PropertyName];
            IModelMemberAutoFilterRow modelMember = modelColumn?.ModelMember as IModelMemberAutoFilterRow;
            if (modelMember != null && modelMember.AutoFilterRowCondition.HasValue)
              gridColumnWrapper.Column.Settings.AutoFilterCondition = TransformToAutoFilterCondition(modelMember.AutoFilterRowCondition.Value);
          }
        }
      }
    }

    #endregion

    //#region OnViewControlsCreated

    ////Alternative implementation
    //protected override void OnViewControlsCreated()
    //{
    //  base.OnViewControlsCreated();

    //  ASPxGridListEditor listEditor = ((ListView)View).Editor as ASPxGridListEditor;
    //  if (listEditor != null)
    //  {
    //    foreach (ASPxGridViewColumnWrapper columnWrapper in listEditor.Columns)
    //    {
    //      IModelColumn modelColumn = (this.View as ListView)?.Model.Columns[columnWrapper.PropertyName];
    //      IModelMemberAutoFilterRow modelMember = modelColumn?.ModelMember as IModelMemberAutoFilterRow;
    //      if (modelMember != null && modelMember.AutoFilterRowCondition.HasValue)
    //        columnWrapper.Column.Settings.AutoFilterCondition = TransformToAutoFilterCondition(modelMember.AutoFilterRowCondition.Value);
    //    }
    //  }
    //}

    //#endregion

    #region TransformToAutoFilterCondition

    private DevExpress.Web.AutoFilterCondition TransformToAutoFilterCondition(AutoFilterRowCondition filterType)
    {
      switch (filterType)
      {
        case AutoFilterRowCondition.Default: return DevExpress.Web.AutoFilterCondition.Default;

        case AutoFilterRowCondition.Like: return DevExpress.Web.AutoFilterCondition.Like;

        case AutoFilterRowCondition.Equals: return DevExpress.Web.AutoFilterCondition.Equals;

        case AutoFilterRowCondition.Contains: return DevExpress.Web.AutoFilterCondition.Contains;

        case AutoFilterRowCondition.BeginsWith: return DevExpress.Web.AutoFilterCondition.BeginsWith;

        case AutoFilterRowCondition.EndsWith: return DevExpress.Web.AutoFilterCondition.EndsWith;

        case AutoFilterRowCondition.DoesNotContain: return DevExpress.Web.AutoFilterCondition.DoesNotContain;

        case AutoFilterRowCondition.DoesNotEqual: return DevExpress.Web.AutoFilterCondition.NotEqual;

        case AutoFilterRowCondition.Greater: return DevExpress.Web.AutoFilterCondition.Greater;

        case AutoFilterRowCondition.GreaterOrEqual: return DevExpress.Web.AutoFilterCondition.GreaterOrEqual;

        case AutoFilterRowCondition.Less: return DevExpress.Web.AutoFilterCondition.Less;

        case AutoFilterRowCondition.LessOrEqual: return DevExpress.Web.AutoFilterCondition.LessOrEqual;

        // not supported in Web. So fallback to Default.
        case AutoFilterRowCondition.NotLike: return DevExpress.Web.AutoFilterCondition.Default;

        default: throw new UserFriendlyException($"Auto Filter Row Condition {filterType} was not recognised.");
      }
    }

    #endregion

    #region TransformFromAutoFilterCondition

    private AutoFilterRowCondition TransformFromAutoFilterCondition(DevExpress.Web.AutoFilterCondition filterType)
    {
      switch (filterType)
      {
        case DevExpress.Web.AutoFilterCondition.Default: return AutoFilterRowCondition.Default;

        case DevExpress.Web.AutoFilterCondition.Like: return AutoFilterRowCondition.Like;

        case DevExpress.Web.AutoFilterCondition.Equals: return AutoFilterRowCondition.Equals;

        case DevExpress.Web.AutoFilterCondition.Contains: return AutoFilterRowCondition.Contains;

        case DevExpress.Web.AutoFilterCondition.BeginsWith: return AutoFilterRowCondition.BeginsWith;

        case DevExpress.Web.AutoFilterCondition.EndsWith: return AutoFilterRowCondition.EndsWith;

        case DevExpress.Web.AutoFilterCondition.DoesNotContain: return AutoFilterRowCondition.DoesNotContain;

        case DevExpress.Web.AutoFilterCondition.NotEqual: return AutoFilterRowCondition.DoesNotEqual;

        case DevExpress.Web.AutoFilterCondition.Greater: return AutoFilterRowCondition.Greater;

        case DevExpress.Web.AutoFilterCondition.GreaterOrEqual: return AutoFilterRowCondition.GreaterOrEqual;

        case DevExpress.Web.AutoFilterCondition.Less: return AutoFilterRowCondition.Less;

        case DevExpress.Web.AutoFilterCondition.LessOrEqual: return AutoFilterRowCondition.LessOrEqual;

        default: throw new UserFriendlyException($"Auto Filter Condition {filterType} was not recognised.");
      }
    }

    #endregion
  }
}
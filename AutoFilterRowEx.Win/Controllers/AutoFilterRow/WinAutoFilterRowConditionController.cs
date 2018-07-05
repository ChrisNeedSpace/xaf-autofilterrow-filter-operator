using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace AutoFilterRowEx.Win.Controllers
{
  /// <summary>
  /// Defines a default AutoFilterRow filtering Condition.
  /// See <see cref="IModelMemberAutoFilterRow"/>, <see cref="AutoFilterRowConditionAttribute"/>..
  /// See also <seealso href="http://www.devexpress.com/Support/Center/p/S131144.aspx" />.
  /// </summary>
  public class WinAutoFilterRowConditionController : ViewController
  {
    #region ctor

    public WinAutoFilterRowConditionController()
    {
      TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
    }

    #endregion

    #region OnViewControlsCreated

    protected override void OnViewControlsCreated()
    {
      base.OnViewControlsCreated();

      ListView listView = this.View as ListView;
      GridListEditor gridListEditor = listView?.Editor as GridListEditor;
      if (gridListEditor != null)
      {
        GridView gridView = gridListEditor.GridView;
        if (gridView != null && gridView.Columns.Count > 0)
          foreach (GridColumn column in gridView.Columns)
          {
            IModelColumn modelColumn = gridListEditor.Model.Columns[column.Name];
            IModelMemberAutoFilterRow modelMember = modelColumn?.ModelMember as IModelMemberAutoFilterRow;
            if (modelMember != null && modelMember.AutoFilterRowCondition.HasValue)
            {
              //if (column.ColumnType == typeof(string))
              column.OptionsFilter.AutoFilterCondition = TransformToAutoFilterCondition(modelMember.AutoFilterRowCondition.Value);
            }
          }
      }
    }

    #endregion

    // Alternative implementation with saving the changes in model. BUT it saves also default operators, which wipes out XAF default operator... (not recommended, IMO)

    //#region OnActivated & OnDeactivated

    //protected override void OnActivated()
    //{
    //  base.OnActivated();
    //  if (this.View is ListView)
    //  {
    //    (this.View as ListView).Editor.ModelApplied += Editor_ModelApplied;
    //    (this.View as ListView).Editor.ModelSaved += Editor_ModelSaved;
    //  }
    //}

    //protected override void OnDeactivated()
    //{
    //  if (this.View is ListView)
    //  {
    //    (this.View as ListView).Editor.ModelApplied -= Editor_ModelApplied;
    //    (this.View as ListView).Editor.ModelSaved -= Editor_ModelSaved;
    //  }
    //  base.OnDeactivated();
    //}

    //#endregion

    //#region Editor_ModelSaved & Editor_ModelApplied

    //private void Editor_ModelSaved(object sender, EventArgs e)
    //{
    //  if (sender is GridListEditor)
    //  {
    //    foreach (XafGridColumnWrapper columnWrapper in ((GridListEditor)sender).Columns)
    //    {
    //      IModelMemberAutoFilterRow modelMemberAutoFilterRow = columnWrapper.GridColumnInfo?.Model.ModelMember as IModelMemberAutoFilterRow;
    //      if (modelMemberAutoFilterRow != null)
    //        modelMemberAutoFilterRow.AutoFilterRowCondition = TransformFromAutoFilterCondition(columnWrapper.Column.OptionsFilter.AutoFilterCondition);
    //    }
    //  }
    //}

    //private void Editor_ModelApplied(object sender, EventArgs e)
    //{
    //  if (sender is GridListEditor)
    //  {
    //    foreach (XafGridColumnWrapper columnWrapper in ((GridListEditor)sender).Columns)
    //    {
    //      AutoFilterRowCondition? filterCondition = (columnWrapper.GridColumnInfo.Model.ModelMember as IModelMemberAutoFilterRow)?.AutoFilterRowCondition;
    //      if (filterCondition.HasValue)
    //        columnWrapper.Column.OptionsFilter.AutoFilterCondition = TransformToAutoFilterCondition(filterCondition.GetValueOrDefault());
    //    }
    //  }
    //}

    //#endregion


    #region TransformToAutoFilterCondition

    private DevExpress.XtraGrid.Columns.AutoFilterCondition TransformToAutoFilterCondition(AutoFilterRowCondition filterType)
    {
      switch (filterType)
      {
        case AutoFilterRowCondition.Default: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Default;

        case AutoFilterRowCondition.Like: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;

        case AutoFilterRowCondition.Equals: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;

        case AutoFilterRowCondition.Contains: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;

        case AutoFilterRowCondition.BeginsWith: return DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;

        case AutoFilterRowCondition.EndsWith: return DevExpress.XtraGrid.Columns.AutoFilterCondition.EndsWith;

        case AutoFilterRowCondition.DoesNotContain: return DevExpress.XtraGrid.Columns.AutoFilterCondition.DoesNotContain;

        case AutoFilterRowCondition.DoesNotEqual: return DevExpress.XtraGrid.Columns.AutoFilterCondition.DoesNotEqual;

        case AutoFilterRowCondition.Greater: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Greater;

        case AutoFilterRowCondition.GreaterOrEqual: return DevExpress.XtraGrid.Columns.AutoFilterCondition.GreaterOrEqual;

        case AutoFilterRowCondition.Less: return DevExpress.XtraGrid.Columns.AutoFilterCondition.Less;

        case AutoFilterRowCondition.LessOrEqual: return DevExpress.XtraGrid.Columns.AutoFilterCondition.LessOrEqual;

        case AutoFilterRowCondition.NotLike: return DevExpress.XtraGrid.Columns.AutoFilterCondition.NotLike;

        default: throw new UserFriendlyException($"Auto Filter Row Condition {filterType} was not recognised.");
      }
    }

    #endregion

    #region TransformFromAutoFilterCondition

    private AutoFilterRowCondition TransformFromAutoFilterCondition(DevExpress.XtraGrid.Columns.AutoFilterCondition filterType)
    {
      switch (filterType)
      {
        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Default: return AutoFilterRowCondition.Default;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Like: return AutoFilterRowCondition.Like;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals: return AutoFilterRowCondition.Equals;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains: return AutoFilterRowCondition.Contains;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith: return AutoFilterRowCondition.BeginsWith;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.EndsWith: return AutoFilterRowCondition.EndsWith;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.DoesNotContain: return AutoFilterRowCondition.DoesNotContain;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.DoesNotEqual: return AutoFilterRowCondition.DoesNotEqual;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Greater: return AutoFilterRowCondition.Greater;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.GreaterOrEqual: return AutoFilterRowCondition.GreaterOrEqual;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.Less: return AutoFilterRowCondition.Less;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.LessOrEqual: return AutoFilterRowCondition.LessOrEqual;

        case DevExpress.XtraGrid.Columns.AutoFilterCondition.NotLike: return AutoFilterRowCondition.NotLike;

        default: throw new UserFriendlyException($"Auto Filter Condition {filterType} was not recognised.");
      }
    }

    #endregion
  }
}
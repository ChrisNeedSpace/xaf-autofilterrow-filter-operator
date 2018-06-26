using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace TestProject17_2.Module.Win.Controllers
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

      #endregion
    }
  }
}
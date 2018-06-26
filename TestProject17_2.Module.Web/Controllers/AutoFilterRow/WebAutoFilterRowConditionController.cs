using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;

namespace TestProject17_2.Module.Web.Controllers
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

    #region OnViewControlsCreated

    protected override void OnViewControlsCreated()
    {
      base.OnViewControlsCreated();

      ASPxGridListEditor listEditor = ((ListView)View).Editor as ASPxGridListEditor;
      if (listEditor != null)
      {
        ASPxGridView gridView = listEditor.Grid;
        foreach (GridViewDataColumn dataColumn in gridView.DataColumns)
        {
          string columnName = dataColumn.Name;  // this seems to be empty in Web
          if (string.IsNullOrEmpty(columnName))
          {
            columnName = dataColumn.FieldName; // FieldName does not work for reference properties as it returns e.g. "AccountType.Name"
            int dotIndex = columnName?.IndexOf('.') ?? -1;
            if (dotIndex > -1)
              columnName = columnName?.Substring(0, dotIndex);  // a bodge to drop ".Name" portion.
          }
          IModelColumn modelColumn = listEditor.Model.Columns[columnName];
          IModelMemberAutoFilterRow modelMember = modelColumn?.ModelMember as IModelMemberAutoFilterRow;
          if (modelMember != null && modelMember.AutoFilterRowCondition.HasValue)
          {
            dataColumn.Settings.AutoFilterCondition = TransformToAutoFilterCondition(modelMember.AutoFilterRowCondition.Value);
          }
        }
      }
    }

    #endregion

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
      
      #endregion
    }
  }
}
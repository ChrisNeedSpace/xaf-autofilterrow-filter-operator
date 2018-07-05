using System.ComponentModel;

namespace AutoFilterRowEx
{
  /// <summary>
  /// Defines a default AutoFilterRow filtering Condition.
  /// See <see cref="AutoFilterRowConditionAttribute"/>.
  /// See also <seealso href="http://www.devexpress.com/Support/Center/p/S131144.aspx" />.
  /// </summary>
  public interface IModelMemberAutoFilterRow
  {
    [Category("Behavior")]
    [Description("Specifies the AutoFilterRow's condition.")]
    AutoFilterRowCondition? AutoFilterRowCondition { get; set; }
  }

  // Uncomment if we will want to specify it per view.
  ///// <summary>
  ///// See <see href="http://www.devexpress.com/Support/Center/p/S131144.aspx" />
  ///// </summary>
  //public interface IModelColumnAutoFilterRow
  //{
  //  [Category("Behavior")]
  //  bool AutoFilterRow { get; set; }
  //}


  //// Logic

  // Obsolete. Replaced with the ModelExportedValuesAttribute logic
  //[DomainLogic(typeof(IModelMemberAutoFilterRow))]
  //public static class ModelMemberAutoFilterRowLogic
  //{
  //  public static AutoFilterRowCondition? Get_AutoFilterRowCondition(IModelMember modelMember)
  //  {
  //    AutoFilterRowConditionAttribute attribute = modelMember?.MemberInfo?.FindAttribute<AutoFilterRowConditionAttribute>();
  //    if (attribute != null)
  //      return attribute.AutoFilterCondition;
  //    else
  //      return null;
  //  }
  //}

  // Uncomment if we will want to specify it per view.
  //[DomainLogic(typeof(IModelColumnAutoFilterRow))]
  //public static class ModelColumnAutoFilterRowLogic
  //{
  //  public static bool Get_AutoFilterRow(IModelColumn modelColumn)
  //  {
  //    if (modelColumn != null && modelColumn.ModelMember != null)
  //    {
  //      IModelMemberAutoFilterRow modelMemberAutoFilterRow = modelColumn.ModelMember as IModelMemberAutoFilterRow;
  //      if (modelMemberAutoFilterRow != null)
  //        return modelMemberAutoFilterRow.AutoFilterRow;
  //    }
  //    return false;// ((IModelMemberAutoFilterRow)modelColumn.ModelMember).AutoFilterRow;
  //  }
  //}

}

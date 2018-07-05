using System;
using System.Collections.Generic;
using DevExpress.Persistent.Base;

namespace AutoFilterRowEx
{
  /// <summary>
  /// Defines a default AutoFilterRow filtering Condition for particular columns.
  /// See <see cref="IModelMemberAutoFilterRow"/>.
  /// See also <seealso href="http://www.devexpress.com/Support/Center/p/S131144.aspx" />.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
  public class AutoFilterRowConditionAttribute : ModelExportedValuesAttribute
  {
    #region Structor(s)

    public AutoFilterRowConditionAttribute(AutoFilterRowCondition condition)
    {
      AutoFilterCondition = condition;
    }

    #endregion

    #region AutoFilterCondition

    public AutoFilterRowCondition AutoFilterCondition { get; set; }

    #endregion

    #region FillValues

    public override void FillValues(Dictionary<string, object> values)
    {
      values.Add(nameof(IModelMemberAutoFilterRow.AutoFilterRowCondition), AutoFilterCondition);
    }

    #endregion
  }

  /// <summary>
  /// A platform agnostic enum for Auto Filter Row filtering type. Used by <see cref="AutoFilterRowConditionAttribute"/>.
  /// See for Win: DevExpress.XtraGrid.Columns.AutoFilterCondition. 
  /// See for Web: DevExpress.Web.AutoFilterCondition.
  /// </summary>
  public enum AutoFilterRowCondition
  {
    /// <summary>
    ///   Win:
    ///     For columns being filtered by their display text (see DevExpress.XtraGrid.Columns.GridColumn.FilterMode),
    ///     the Default option acts identically to the Like option.
    ///     The Default option acts like the Equals option for the columns that have any
    ///     of the following in-place editors or any of their descendants: DevExpress.XtraEditors.CheckEdit,
    ///     DevExpress.XtraEditors.LookUpEditBase or DevExpress.XtraEditors.ImageComboBoxEdit.
    ///     For other columns, the Default option acts identically to the Like option.
    ///   Web:
    ///     For the string columns and columns that are filtered by display text - the same
    ///     as the BeginsWith value. For other columns - the Equals value.
    /// </summary>
    Default = 0,

    /// <summary>
    ///     The Like comparison operator selects records whose values in the corresponding
    ///     column match the entered string. 
    ///     Two wildcard symbols are supported: 
    ///       %  substitutes zero or more characters;
    ///       _  substitutes a single character.
    ///     For the columns that use DevExpress.XtraEditors.CheckEdit, DevExpress.XtraEditors.LookUpEditBase
    ///     or DevExpress.XtraEditors.ImageComboBoxEdit in-place editors, the Equals operator
    ///     is always used, unless these columns are filtered by display text (see DevExpress.XtraGrid.Columns.GridColumn.FilterMode).
    /// </summary>
    Like = 1,

    /// <summary>
    ///     The Equals comparison operator selects records whose values in the corresponding column match the entered value.
    /// </summary>
    Equals = 2,

    /// <summary>
    ///     The Contains operator selects records whose values in the corresponding column contain the entered string.
    /// </summary>
    Contains = 3,

    /// <summary>
    ///     Selects records that start with the entered string.
    ///     Equal to the DevExpress.XtraGrid.Columns.AutoFilterCondition.Like clause with the "%" wildcard after the searched string.
    ///     For example, the [Name] BeginsWith 'A' and [Name] Like 'A%' filtering expressions are equal.
    /// </summary>
    BeginsWith = 4,

    /// <summary>
    ///     Selects records that end with the entered string. Equal to the DevExpress.XtraGrid.Columns.AutoFilterCondition.Like
    ///     clause with the "%" wildcard before the searched string.
    ///     For example, the [Name] EndsWith 'A' and [Name] Like '%A' filtering expressions are equal.
    /// </summary>
    EndsWith = 5,

    /// <summary>
    ///     Selects records that do not contain the entered string. Equal to the DevExpress.XtraGrid.Columns.AutoFilterCondition.NotLike
    ///     clause with the "%" wildcard before and after the searched string.
    ///     For example, the [Name] DoesNotContain 'AA' and [Name] NotLike '%AA%' filtering
    ///     expressions are equal.
    /// </summary>
    DoesNotContain = 6,

    /// <summary>
    ///     Selects records that do not equal the entered string. This clause acts as an
    ///     opposite to the DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals clause.
    /// </summary>
    DoesNotEqual = 7,

    /// <summary>
    ///     Selects records that are greater than the entered value.
    ///     For text records, "greater" values are those that would lie below the entered
    ///     value in an alphabetically sorted list. For example, in a list with Latin characters,
    ///     all letters from "N" to "Z" are greater than the letter "M".
    /// </summary>
    Greater = 8,

    /// <summary>
    ///     Selects records that are greater than the entered value or equal to it.
    ///     For text records, "greater" values are those that would lie below the entered
    ///     value in an alphabetically sorted list. For example, in a list with Latin characters,
    ///     all letters from "M" to "Z" are greater or equal to the letter "M".
    /// </summary>
    GreaterOrEqual = 9,

    /// <summary>
    ///     Selects records that are less than the entered value.
    ///     For text records, "less" values are those that would lie above the entered value
    ///     in an alphabetically sorted list. For example, in a list with Latin characters,
    ///     all letters from "A" to "L" are less than the letter "M".
    /// </summary>
    Less = 10,

    /// <summary>
    ///     Selects records that are less than the entered value or equal to it.
    ///     For text records, "less" values are those that would lie above the entered value
    ///     in an alphabetically sorted list. For example, in a list with Latin characters,
    ///     all letters from "A" to "L" are less than the letter "M".
    /// </summary>
    LessOrEqual = 11,

    /// <summary>
    ///   Win only (not supported in Web).
    ///     Selects records that do not match the entered string. Acts as an opposite to
    ///     the DevExpress.XtraGrid.Columns.AutoFilterCondition.Like clause.
    ///     For example, from a list with month names the [Name] Like 'J%y' filter expression
    ///     will return the "January" and "July" records. The [Name] Not Like 'J%y' expression
    ///     will return the names of remaining ten months.
    /// </summary>
    NotLike = 12
  }
}

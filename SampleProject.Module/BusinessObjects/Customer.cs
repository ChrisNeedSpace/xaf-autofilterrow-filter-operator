using AutoFilterRowEx;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace SampleProject.Module.BusinessObjects
{
  [DefaultClassOptions]
  [Persistent]
  public class Customer : BaseObject
  { 
    public Customer(Session session)
        : base(session)
    {
    }

    private string _name;
    [AutoFilterRowCondition(AutoFilterRowCondition.EndsWith)]
    public string Name
    {
      get { return _name; }
      set { SetPropertyValue(nameof(Name), ref _name, value); }
    }

    [Association, Aggregated]
    public XPCollection<SalesOrder> SalesOrders
    {
      get { return GetCollection<SalesOrder>(nameof(SalesOrders)); }
    }

    [Association, Aggregated]
    public XPCollection<SalesReturn> SalesReturns
    {
      get { return GetCollection<SalesReturn>(nameof(SalesReturns)); }
    }
  }
}
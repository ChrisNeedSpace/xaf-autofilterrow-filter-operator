using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace TestProject17_2.Module.BusinessObjects
{
  [DefaultClassOptions]
  [MapInheritance(MapInheritanceType.ParentTable)]
  public class SalesOrder : SalesTransactionShippableHeaderBase
  { 
    public SalesOrder(Session session)
        : base(session)
    {
    }

    public override void AfterConstruction()
    {
      base.AfterConstruction();
      this.DocumentNumber = "SO-00" + GenerateSomeSillyNumber().ToString("0000");
    }

    private Customer _customer;
    [Association]
    public Customer Customer
    {
      get { return _customer; }
      set { SetPropertyValue(nameof(Customer), ref _customer, value); }
    }

  }
}